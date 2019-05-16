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

        public bool HasFailedLogin(int userFailedLoginCount)
        {
            var maxFailedLoginCount = _configuration.MaxFailedLoginCount;

            return maxFailedLoginCount >= userFailedLoginCount;
        }
    }
}
