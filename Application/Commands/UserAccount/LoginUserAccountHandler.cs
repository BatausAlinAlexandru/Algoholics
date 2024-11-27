using Application.Services.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.UserAccount
{
    public class LoginUserAccountHandler : IRequestHandler<LoginUserAccountCommand, Result<string>>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserAccountHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<string>> Handle(LoginUserAccountCommand request, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.LoginAsync(request.Email, request.Password);
            return Result.Success(token);
        }
    }
}
