using System.Net;
using System.Net.Http;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        #region Tests
        [Theory]
        [InlineData("http://www.10-4.com")]
        [InlineData("http://www.google.com")]
        [InlineData("https://www.apnews.com/")]
        [InlineData("https://github.com/jondspen/CorePrimeNumbers")]
        [InlineData("https://github.com/jondspen/CorePrimeNumbers1")]
        public void TestUrlStatus(string siteURL)
        {
            Assert.Equal(HttpStatusCode.OK, GetHttpStatueCode(siteURL));
        }

        [Fact]
        public void CheckFor404Status()
        {
            Assert.Equal(HttpStatusCode.NotFound, GetHttpStatueCode("https://github.com/jondspen/CorePrimeNumbers1"));
        }

        #endregion

        #region Methods
        private HttpStatusCode GetHttpStatueCode(string siteURL)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(siteURL).Result.StatusCode;
            }
        }
        #endregion
    }
}
