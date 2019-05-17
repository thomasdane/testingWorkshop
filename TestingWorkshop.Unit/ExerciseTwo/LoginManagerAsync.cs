using System.Threading.Tasks;

namespace TestingWorkshop.Unit
{
    public class LoginManagerAsync
    {
        private readonly IDatabase _database;

        public LoginManagerAsync(IDatabase database)
        {
            _database = database;
        }

        public async Task<bool> HasFailedLogin(int userId)
        {
            var maxFailedLoginCount = 5;
            var userFailedLoginCount = await _database.GetUserFailedLoginCountAsync(userId);

            return userFailedLoginCount >= maxFailedLoginCount;
        }

        public async Task<bool> HasSessionTimedOut(int userId)
        {
            var maxSessionDuration = 3600;
            var userSessionDuration = await _database.GetUserFailedLoginCountAsync(userId);

            return userSessionDuration >= maxSessionDuration;
        }
    }
}
