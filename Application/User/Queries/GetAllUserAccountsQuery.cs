using Application.User.DTO;
using Domain.Aggregates.UserAggregate.Value_Objects;
using MediatR;

namespace Application.User.Queries
{
    public class GetAllUserAccountsQuery : IRequest<List<UserAccountDTO>>
    {
        public GetAllUserAccountsQuery()
        {
            // Constructor logic here
        }

        // Implement the handler logic here
        public class Handler : IRequestHandler<GetAllUserAccountsQuery, List<UserAccountDTO>>
        {
            public Handler()
            {
                // Handler constructor logic here
            }

            public async Task<List<UserAccountDTO>> Handle(GetAllUserAccountsQuery request, CancellationToken cancellationToken)
            {
                // Handler logic here
                // Retrieve all user accounts from the database or any other data source
                List<UserAccountDTO> userAccounts = new List<UserAccountDTO>();

                // Add sample user accounts for demonstration purposes
                userAccounts.Add(new UserAccountDTO
                {
                    Id = Guid.NewGuid(),
                    Email = "user1@example.com",
                    Password = "password1",
                    UserAccountRole = UserAccountRole.User
                });

                userAccounts.Add(new UserAccountDTO
                {
                    Id = Guid.NewGuid(),
                    Email = "user2@example.com",
                    Password = "password2",
                    UserAccountRole = UserAccountRole.Admin
                });

                userAccounts.Add(new UserAccountDTO
                {
                    Id = Guid.NewGuid(),
                    Email = "user3@example.com",
                    Password = "password3",
                    UserAccountRole = UserAccountRole.Moderator
                });

                return userAccounts;
            }
        }
    }
}
