namespace TestingWorkshop.Fundamentals
{
    public class LoginManager
    {
        private readonly IConfiguration _configuration;

        public LoginManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool HasLoginFailedAsync(int userFailedLoginCount)
        {
            var maxFailedLoginCount = _configuration.MaxFailedLoginCount;
            return userFailedLoginCount >= maxFailedLoginCount;
        }

        public bool HasSessionTimedOutAsync(int userSessionDuration)
        {
            var maxSessionDuration = _configuration.MaxSessionDuration;
            return userSessionDuration >= maxSessionDuration;
        }
    }
}
