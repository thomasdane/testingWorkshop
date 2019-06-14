using Moq;
using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class LoginManagerTests
    {
        [Theory]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, true)]
        public void HasLoginFailedAsyncTests(int userFailedLoginCount, bool expected)
        {
            //Arrange
            var configurationMock = GetConfiguration();
            var loginManager = new LoginManager(configurationMock);

            //Act
            var actual = loginManager.HasLoginFailed(userFailedLoginCount);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IConfiguration GetConfiguration()
        {
            var databaseMock = new Mock<IConfiguration>();
            databaseMock.Setup(mock => mock.MaxFailedLoginCount).Returns(5);
            return databaseMock.Object;
        }
    }
}
