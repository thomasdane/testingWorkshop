using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class LoginManagerWithConfigTests
    {
        private readonly int maxFailedLoginCount = 5;
        private readonly int userId = 1337;

        [Theory]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, true)]
        public async Task HasLoginFailedAsyncTests(int userFailedLoginCount, bool expected)
        {
            //Arrange
            var databaseMock = GetDatabaseMock(userFailedLoginCount);
            var configurationMock = GetConfigurationMock();
            var loginManager = new LoginManagerWithConfig(configurationMock, databaseMock);

            //Act
            var actual = await loginManager.HasLoginFailedAsync(userId);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IConfiguration GetConfigurationMock()
        {
            var databaseMock = new Mock<IConfiguration>();
            databaseMock.Setup(mock => mock.MaxFailedLoginCount).Returns(maxFailedLoginCount);
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
