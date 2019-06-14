using Xunit;

namespace TestingWorkshop.Fundamentals.Tests
{
    public class PureFunctionTests
    {
        [Theory]
        [InlineData(4, false)]
        [InlineData(5, false)]
        [InlineData(6, true)]
        public void GreaterThanFiveTests(int input, bool expected)
        {
            //Arrange
            var pureFunction = new PureFunction();

            //Act
            var actual = pureFunction.GreaterThanFive(input);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
