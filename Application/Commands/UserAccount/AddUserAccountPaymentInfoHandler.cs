using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.UserAccount
{
    internal class AddUserAccountPaymentInfoHandler : IRequestHandler<AddUserAccountPaymentInfoCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public AddUserAccountPaymentInfoHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result> Handle(AddUserAccountPaymentInfoCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByIdAsync(request.IdUserAccount);

            if (userAccount == null)
                return Result.Failure($"User account with ID {request.IdUserAccount} was not found");

            Domain.Aggregates.UserAggregate.Entities.UserAccountPaymentInfo paymentInfo = new(request.CardNumber, request.CardHolderName, 
                request.ExpirationCardMonth, request.ExpirationCardYear, request.CVV);

            await _userAccountRepository.AddUserAccountPaymentCardInfoAsync(request.IdUserAccount, paymentInfo);

            return Result.Success();
        }
    }
}
