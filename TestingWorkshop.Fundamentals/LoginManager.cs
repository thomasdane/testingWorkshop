using System.Threading.Tasks;

namespace TestingWorkshop.Fundamentals
{
    public class LoginManager
    {
        private readonly IConfiguration _configuration;
        private readonly IDatabase _database;

        public LoginManager(IConfiguration configuration, IDatabase database)
        {
            _configuration = configuration;
            _database = database;
        }

        public async Task<bool> HasFailedLoginAsync(int userId)
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
