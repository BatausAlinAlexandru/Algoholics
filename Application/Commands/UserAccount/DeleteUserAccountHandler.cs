using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.UserAccount
{
    public class DeleteUserAccountHandler : IRequestHandler<DeleteUserAccountCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public DeleteUserAccountHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result> Handle(DeleteUserAccountCommand request, CancellationToken cancellationToken)
        {
            var success = await _userAccountRepository.DeleteUserAccountAsync(request.IdUserAccount);
            if (success.IsFailure)
                return Result.Failure("Failed to delete user account");

            return Result.Success();
        }
    }
}
