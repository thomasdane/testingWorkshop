namespace TestingWorkshop.Unit
{
    public class LoginManager
    {
        private readonly IDatabase _database;

        public LoginManager(IDatabase database)
        {
            _database = database;
        }

        public bool HasFailedLogin(int userId)
        {
            var maxFailedLoginCount = 5;

            var userFailedLoginCount = _database.GetFailedLoginCount(userId);

            return maxFailedLoginCount >= userFailedLoginCount;
        }
    }
}
