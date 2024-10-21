using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccount : BaseEntity,  IAggregateRoot
    {
        public UserAccountCredentials UserAccountCredentials { get; set; }

        public UserAccountRole UserAccountRole { get; set; } = UserAccountRole.User;

        public UserAccount() : base() { }
        public UserAccount(string email, string password): base() 
        {
            this.UserAccountCredentials = new UserAccountCredentials(email, password);
        }

        public UserAccount(UserAccountCredentials userAccountCredentials)
        {
            UserAccountCredentials = new UserAccountCredentials(userAccountCredentials.Email, userAccountCredentials.Password);
        }

        public void AddUserAccountCredentials(UserAccountCredentials userAccountSettings)
        {
            this.UserAccountCredentials = userAccountSettings;
        }

        public void AddUserAccountCredentials(string email, string password)
        {
            this.UserAccountCredentials = new UserAccountCredentials(email, password);
        }

        public void UpdateUserAccountCredentialEmail(string email)
        {
            this.UserAccountCredentials.Email = email;
        }

        public void UpdateUserAccountCredentialPassowrd(string passowrd)
        {
            this.UserAccountCredentials.Password = passowrd;
        }

        public void UpdateUserAccountRole(UserAccountRole role)
        {
            this.UserAccountRole = role;
        }
    }
}

// The wizard frog protects this code from malicious threats.
// Do not delete the wizard frog.
//
//                              .-----.
//                             /7  .  (
//                            /   .-.  \
//                           /   /   \  \
//                          / `  )   (   )
//                         / `   )   ).  \
//                       .'  _.   \_/  . |
//      .--.           .' _.' )`.        |
//     (    `---...._.'   `---.'_)    ..  \
//      \            `----....___    `. \  |
//       `.           _ ----- _   `._  )/  |
//         `.       /"  \   /"  \`.  `._   |
//           `.    ((O)` ) ((O)` ) `.   `._\
//             `-- '`---'   `---' )  `.    `-.
//                /                  ` \      `-.
//              .'                      `.       `.
//             /                     `  ` `.       `-.
//      .--.   \ ===._____.======. `    `   `. .___.--`     .''''.
//     ' .` `-. `.                )`. `   ` ` \          .' . '  8)
//    (8  .  ` `-.`.               ( .  ` `  .`\      .'  '    ' /
//     \  `. `    `-.               ) ` .   ` ` \  .'   ' .  '  /
//      \ ` `.  ` . \`.    .--.     |  ` ) `   .``/   '  // .  /
//       `.  ``. .   \ \   .-- `.  (  ` /_   ` . / ' .  '/   .'
//         `. ` \  `  \ \  '-.   `-'  .'  `-.  `   .  .'/  .'
//           \ `.`.  ` \ \    ) /`._.`       `.  ` .  .'  /
//            |  `.`. . \ \  (.'               `.   .'  .'
//         __/  .. \ \ ` ) \                     \.' .. \__
//  .-._.-'     '"  ) .-'   `.                   (  '"     `-._.--.
// (_________.-====' / .' /\_)`--..__________..-- `====-. _________)
//                  (.'(.'