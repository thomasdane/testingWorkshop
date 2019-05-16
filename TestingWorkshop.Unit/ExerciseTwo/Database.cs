using System.Threading.Tasks;

namespace TestingWorkshop.Unit
{
    public interface IDatabase
    {
        Task<int> GetFailedLoginCountAsync(int userId);
    }

    public class Database : IDatabase
    {
        public async Task<int> GetFailedLoginCountAsync(int userId)
        {
            //In real life, call database with userId
            return await Task.Run(() => 5);
        }
    }
}
