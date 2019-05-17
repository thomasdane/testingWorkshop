using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class LoginManagerTests
    {
        [Theory]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, true)]
        public async Task HasFailedLoginAsyncTests(int userFailedLoginCount, bool expected)
        {
            //Arrange
            var databaseMock = GetDatabaseMock(userFailedLoginCount);
            var configMock = GetConfigurationMock();
            var loginManager = new LoginManager(configMock, databaseMock);

            //Act
            var actual = await loginManager.HasFailedLoginAsync(1);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IDatabase GetDatabaseMock(int userFailedLoginCount)
        {
            var databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(mock => mock.GetUserFailedLoginCountAsync(It.IsAny<int>())).ReturnsAsync(userFailedLoginCount);
            return databaseMock.Object;
        }

        private IConfiguration GetConfigurationMock()
        {
            var configMock = new Mock<IConfiguration>();
            configMock.Setup(mock => mock.MaxFailedLoginCount).Returns(5);
            return configMock.Object;
        }
    }
}
