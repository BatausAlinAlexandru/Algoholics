using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.UserAccount
{
    public class UploadUserAccountAvatarCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public IFormFile AvatarFile { get; set; }

        public UploadUserAccountAvatarCommand(Guid userId, IFormFile avatarFile)
        {
            UserId = userId;
            AvatarFile = avatarFile;
        }
    }
}
