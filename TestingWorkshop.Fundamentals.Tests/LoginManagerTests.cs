using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class LoginManagerTests
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
            var loginManager = new LoginManager(databaseMock);

            //Act
            var actual = await loginManager.HasLoginFailedAsync(userId, maxFailedLoginCount);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IDatabase GetDatabaseMock(int userFailedLoginCount)
        {
            var databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(mock => mock.GetUserFailedLoginCountAsync(It.IsAny<int>())).ReturnsAsync(userFailedLoginCount);
            return databaseMock.Object;
        }
    }
}
