using MediatR;
using CSharpFunctionalExtensions;
using Application.Services.Interfaces;

namespace Application.Commands.UserAccount
{
    public class RegisterUserAccountHandler : IRequestHandler<RegisterUserAccountCommand, Result>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserAccountHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result> Handle(RegisterUserAccountCommand request, CancellationToken cancellationToken)
        {
            await _authenticationService.RegisterAsync(request.Email, request.Password);
            return Result.Success();
        }
    }
}
