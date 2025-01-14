using Application.Services.Interfaces;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.UserAccount
{
    public class UploadUserAccountAvatarHandler : IRequestHandler<UploadUserAccountAvatarCommand, bool>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IFileStorageService _fileStorageService;

        public UploadUserAccountAvatarHandler(IUserAccountRepository userAccountRepository, IFileStorageService fileStorageService)
        {
            _userAccountRepository = userAccountRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<bool> Handle(UploadUserAccountAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _userAccountRepository.GetUserAccountByIdAsync(request.UserId);

            if (user == null)
                return false;

            var fileExtension = Path.GetExtension(request.AvatarFile.FileName);

            if (string.IsNullOrWhiteSpace(fileExtension))
                return false;
            var folder = "avatars";
            var avatarFileName = $"{user.Id}{fileExtension}";

            await _fileStorageService.DeleteFileAsync(folder, user.UserAccountInfo.Avatar);

            var avatarFilePath = await _fileStorageService.SaveFileAsync(folder, avatarFileName, request.AvatarFile);
            if (string.IsNullOrWhiteSpace(avatarFilePath))
                return false;
            user.UserAccountInfo.Avatar = avatarFilePath;
            await _userAccountRepository.SaveUserAccountAsync();

            return true;
        }
    }
}
