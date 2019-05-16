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
            var userId = 1;
            var databaseMock = GetDatabaseMock(userFailedLoginCount);
            var loginManager = new LoginManager(databaseMock);

            //Act
            var actual = loginManager.HasFailedLogin(userId);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IDatabase GetDatabaseMock(int userFailedLoginCount)
        {
            var databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(mock => mock.GetFailedLoginCount(It.IsAny<int>())).Returns(userFailedLoginCount);
            return databaseMock.Object;
        }
    }
}
