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
            var userFailedLoginCount = await _database.GetFailedLoginCountAsync(userId);

            return maxFailedLoginCount >= userFailedLoginCount;
        }
    }
}
