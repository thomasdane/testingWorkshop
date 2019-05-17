using System.Threading.Tasks;

namespace TestingWorkshop.Unit
{
    public interface IDatabase
    {
        Task<int> GetUserFailedLoginCountAsync(int userId);
        Task<int> GetUserSessionDurationAsync(int userId);
    }

    public class Database : IDatabase
    {
        public async Task<int> GetUserFailedLoginCountAsync(int userId)
        {
            return await Task.Run(() => 5);
        }

        public async Task<int> GetUserSessionDurationAsync(int userId)
        {
            return await Task.Run(() => 3600);
        }
    }
}
