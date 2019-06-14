using Moq;
using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class LoginManagerTests
    {
        private readonly int maxFailedLoginCount = 5;

        [Theory]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, true)]
        public void HasLoginFailedAsyncTests(int userFailedLoginCount, bool expected)
        {
            //Arrange
            var configurationMock = GetConfigurationMock();
            var loginManager = new LoginManager(configurationMock);

            //Act
            var actual = loginManager.HasLoginFailedAsync(userFailedLoginCount);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IConfiguration GetConfigurationMock()
        {
            var databaseMock = new Mock<IConfiguration>();
            databaseMock.Setup(mock => mock.MaxFailedLoginCount).Returns(maxFailedLoginCount);
            return databaseMock.Object;
        }
    }
}
