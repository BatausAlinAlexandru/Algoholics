using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccount : BaseEntity,  IAggregateRoot
    {
        public UserAccountCredentials UserAccountCredentials { get; set; }
        public UserAccountSettings UserAccountSettings { get; set; }
        public UserAccountInfo UserAccountInfo { get; set; }


        public UserAccount() : base() { }
      
        public void AddUserAccountCredentials(UserAccountCredentials userAccountCredentials)
        {
            this.UserAccountCredentials = userAccountCredentials;
            this.UserAccountCredentials.Id = this.Id;
        }

        public void AddUserAccountCredentials(string email, string passowrd)
        {
            this.UserAccountCredentials = new UserAccountCredentials(email, passowrd);
            this.UserAccountCredentials.Id = this.Id;
        }

        public void AddUserAccountSettings(UserAccountSettings userAccountSettings)
        {
            this.UserAccountSettings = userAccountSettings;
            this.UserAccountSettings.Id = this.Id;
        }

        public void AddUserAccountSettings(bool emailNotifications, bool smsNotifications)
        {
            this.UserAccountSettings = new UserAccountSettings(emailNotifications, smsNotifications);
            this.UserAccountSettings.Id = this.Id;
        }

        public void AddUserAccountInfo(UserAccountGender userAccountGender, string alias)
        {
            this.UserAccountInfo = new UserAccountInfo(userAccountGender, alias);
            this.UserAccountInfo.Id = this.Id;
        }

        public void AddUserAccountInfo(UserAccountInfo userAccountInfo)
        {
            this.UserAccountInfo = userAccountInfo;
            this.UserAccountInfo.Id = this.Id;
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