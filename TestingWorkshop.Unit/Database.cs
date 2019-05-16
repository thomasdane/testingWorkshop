namespace TestingWorkshop.Unit
{
    public interface IDatabase
    {
        int GetFailedLoginCount(int userId);
    }

    public class Database : IDatabase
    {
        public int GetFailedLoginCount(int userId)
        {
            //In real life, call database with userId
            return 5;
        }
    }
}
