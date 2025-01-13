using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccount : BaseEntity,  IAggregateRoot
    {
        public UserAccountInfo UserAccountInfo { get; set; }
        public UserAccountSettings UserAccountSettings { get; set; }
        public UserAccountCredentials UserAccountCredentials { get; set; }

        public UserAccount() : base() 
        {
            UserAccountInfo = new UserAccountInfo();
            UserAccountSettings = new UserAccountSettings();
            UserAccountCredentials = new UserAccountCredentials();
        }

        public void UpdateUserAccountInfo(UserAccountInfo newUserAccountInfo)
        {
            UserAccountInfo = newUserAccountInfo;
        }

        public void UpdateUserAccountSettings(UserAccountSettings newUserAccountSettings)
        {
            UserAccountSettings = newUserAccountSettings;
        }

        public void UpdateUserAccountCredentials(UserAccountCredentials newUserAccountCredentials)
        {
            UserAccountCredentials = newUserAccountCredentials;
        }

        public void UpdateUserAccount(UserAccount newUserAccount)
        {
            UserAccountInfo = newUserAccount.UserAccountInfo;
            UserAccountSettings = newUserAccount.UserAccountSettings;
            UserAccountCredentials = newUserAccount.UserAccountCredentials;
        }   
      
        public void AddUserAccountCredentials(UserAccountCredentials userAccountCredentials)
        {
            UserAccountCredentials = userAccountCredentials;
            UserAccountCredentials.Id = Id;
        }
        public void AddUserAccountCredentials(string email, string passowrd)
        {
            UserAccountCredentials = new UserAccountCredentials(email, passowrd);
            UserAccountCredentials.Id = Id;
        }

        public void AddUserAccountSettings(UserAccountSettings userAccountSettings)
        {
            UserAccountSettings = userAccountSettings;
            UserAccountSettings.Id = Id;
        }
        public void AddUserAccountSettings(bool emailNotifications, bool smsNotifications)
        {
            UserAccountSettings = new UserAccountSettings(emailNotifications, smsNotifications);
            UserAccountSettings.Id = Id;
        }

        public void AddUserAccountInfo(UserAccountGender userAccountGender, string alias)
        {
            UserAccountInfo = new UserAccountInfo(userAccountGender, alias);
            UserAccountInfo.Id = Id;
        }

        public void AddUserAccountInfo(UserAccountInfo userAccountInfo)
        {
            UserAccountInfo = userAccountInfo;
            UserAccountInfo.Id = Id;
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