using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class ManyDependencyTests
    {
        [Theory]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, true)]
        public async Task HasLoginFailedAsyncTests(int userFailedLoginCount, bool expected)
        {
            //Arrange
            var dependencies = new Dependencies(userFailedLoginCount);
            var loginManager = new LoginManagerAsync(dependencies.Configuration, dependencies.Database);

            //Act
            var actual = await loginManager.HasLoginFailedAsync(1337);

            //Assert
            Assert.Equal(expected, actual);
        }
    }

    internal class Dependencies
    {
        public IDatabase Database { get; }
        public IConfiguration Configuration { get; }

        public Dependencies(int userFailedLoginCount)
        {
            Database = GetDatabaseMock(userFailedLoginCount);
            Configuration = GetConfigurationMock();
        }

        private IConfiguration GetConfigurationMock()
        {
            var databaseMock = new Mock<IConfiguration>();
            databaseMock.Setup(mock => mock.MaxFailedLoginCount).Returns(5);
            return databaseMock.Object;
        }

        private IDatabase GetDatabaseMock(int userFailedLoginCount)
        {
            var databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(mock => mock.GetUserFailedLoginCountAsync(It.IsAny<int>())).ReturnsAsync(userFailedLoginCount);
            return databaseMock.Object;
        }
    }
}
