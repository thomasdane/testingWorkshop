namespace TestingWorkshop.Fundamentals
{
    public interface IConfiguration
    {
        int MaxFailedLoginCount { get; }
        int MaxSessionDuration { get; }
    }

    public class Configuration : IConfiguration
    {
        public int MaxFailedLoginCount => 6;
        public int MaxSessionDuration => 3600;
    }
}
