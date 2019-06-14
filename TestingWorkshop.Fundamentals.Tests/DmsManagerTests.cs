using System.Threading.Tasks;
using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class DmsManagerTests
    {
        [Fact]
        public async Task Get_WhenSuccess_ShouldReturnDocument()
        {
            //Arrange
            var expected = "Test Document";
            var dmsManger = new DmsManager();

            //Act
            var actual = await dmsManger.Get(1);

            //Assert
            //Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Get_WhenFailure_ShouldReturnError()
        {
            //Arrange
            var expected = "Error";
            var dmsManger = new DmsManager();

            //Act
            var actual = await dmsManger.Get(1);

            //Assert
            //Assert.Equal(expected, actual);
        }
    }
}
