using System.Threading.Tasks;

namespace TestingWorkshop.Fundamentals
{
    public class LoginManagerWithConfig
    {
        private readonly IDatabase _database;
        private readonly IConfiguration _configuration;

        public LoginManagerWithConfig(IDatabase database, IConfiguration configuration)
        {
            _database = database;
            _configuration = configuration;
        }

        public async Task<bool> HasLoginFailedAsync(int userId)
        {
            var maxFailedLoginCount = _configuration.MaxFailedLoginCount;
            var userFailedLoginCount = await _database.GetUserFailedLoginCountAsync(userId);
            return userFailedLoginCount >= maxFailedLoginCount;
        }

        public async Task<bool> HasSessionTimedOutAsync(int userId)
        {
            var maxSessionDuration = _configuration.MaxSessionDuration;
            var userSessionDuration = await _database.GetUserFailedLoginCountAsync(userId);
            return userSessionDuration >= maxSessionDuration;
        }
    }
}
