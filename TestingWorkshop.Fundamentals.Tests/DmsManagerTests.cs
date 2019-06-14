using Moq;
using System.Net;
using System.Net.Http;
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
            var response = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(expected) };
            var httpClientWrapper = GetHttpClientWrapper(response);
            var dmsManger = new DmsManager(httpClientWrapper);

            //Act
            var actual = await dmsManger.Get(1);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Get_WhenFailure_ShouldReturnError()
        {
            //Arrange
            var expected = "Error";
            var response = new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError };
            var httpClientWrapper = GetHttpClientWrapper(response);
            var dmsManger = new DmsManager(httpClientWrapper);

            //Act
            var actual = await dmsManger.Get(1);

            //Assert
            Assert.Equal(expected, actual);
        }

        private IHttpClientWrapper GetHttpClientWrapper(HttpResponseMessage expected)
        {
            var wrapper = new Mock<IHttpClientWrapper>();
            wrapper.Setup(mock => mock.GetAsync(It.IsAny<string>())).ReturnsAsync(expected);
            return wrapper.Object;
        }
    }
}
