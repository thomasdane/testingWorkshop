namespace TestingWorkshop.Unit
{
    public interface IConfiguration
    {
        int MaxFailedLoginCount { get; }
    }

    public class Configuration : IConfiguration
    {
        public int MaxFailedLoginCount => 5;
    }
}
