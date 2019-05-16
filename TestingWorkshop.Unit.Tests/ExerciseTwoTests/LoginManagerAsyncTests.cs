using Xunit;
using Moq;
using System.Threading.Tasks;

namespace TestingWorkshop.Unit.Tests
{
    public class LoginManagerAsyncTests
    {
        [Theory]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        public async Task HasFailedLoginAsyncTests(int userFailedLoginCount, bool expected)
        {
            //Arrange
            var userId = 1;
            var databaseMock = GetDatabaseMock(userFailedLoginCount);
            var loginManager = new LoginManagerAsync(databaseMock);

            //Act
            var actual = await loginManager.HasFailedLogin(userId);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IDatabase GetDatabaseMock(int userFailedLoginCount)
        {
            var databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(mock => mock.GetFailedLoginCountAsync(It.IsAny<int>())).ReturnsAsync(userFailedLoginCount);
            return databaseMock.Object;
        }
    }
}
