using System.Threading.Tasks;

namespace TestingWorkshop.Unit
{
    public class LoginManager
    {
        private readonly IConfiguration _configuration;

        public LoginManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //combine these into a single example. Do it together. 

        public bool HasFailedLogin(int userFailedLoginCount)
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
