namespace TestingWorkshop.Fundamentals
{
    public class LoginManager
    {
        private readonly IConfiguration _configuration;

        public LoginManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool HasLoginFailed(int userFailedLoginCount)
        {
            var maxFailedLoginCount = _configuration.MaxFailedLoginCount;
            return userFailedLoginCount >= maxFailedLoginCount;
        }

        public bool HasSessionTimedOut(int userSessionDuration)
        {
            var maxSessionDuration = _configuration.MaxSessionDuration;
            return userSessionDuration >= maxSessionDuration;
        }
    }
}
