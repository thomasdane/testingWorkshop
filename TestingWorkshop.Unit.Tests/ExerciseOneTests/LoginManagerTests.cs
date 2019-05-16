using Xunit;
using Moq;

namespace TestingWorkshop.Unit.Tests
{
    public class LoginManagerTests
    {
        [Theory]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        public void HasFailedLoginTests(int userFailedLoginCount, bool expected)
        {
            //Arrange
            var configurationMock = GetConfigurationMock();
            var loginManager = new LoginManager(configurationMock);

            //Act
            var actual = loginManager.HasFailedLogin(userFailedLoginCount);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IConfiguration GetConfigurationMock()
        {
            var maxFailedLoginCount = 5;
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.SetupGet(mock => mock.MaxFailedLoginCount).Returns(maxFailedLoginCount);
            return configurationMock.Object;
        }
    }
}
