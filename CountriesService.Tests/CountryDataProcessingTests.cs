using Autofac.Extras.Moq;
using CountriesService.ApiDataAccess;
using CountriesService.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CountriesService.Tests
{
    public class CountryDataProcessingTests
    {
        private static string targetedApi = "https://restcountries.com/v3.1/";

        [Theory]
        [InlineData("br")] // ISO 3166-1 alpha-2 (cca2) Brazil lowercase code
        [InlineData("BR")] // ISO 3166-1 alpha-2 (cca2) Brazil uppercase code
        [InlineData("aus")] // ISO 3166-1 alpha-3 (cca3) Australia lowercase code
        [InlineData("AUS")] // ISO 3166-1 alpha-3 (cca3) Australia uppercase code
        [InlineData("100")] // ISO 3166-1 numeric (ccn3) Bulgaria code
        public async Task GetCountryInfoByCodeAsync_CorrectCode_ReturnsCorrectCountryInfo(string code)
        {
            var apiMock = new Mock<IApiRequest>();
            apiMock.Setup(x => x.GetJsonFromApiAsync(It.IsAny<string>()))
                .ReturnsAsync(TestData.MockJsonForCountryCode[code.ToLower()]);
            CountryDataProcessing processor = new CountryDataProcessing(apiMock.Object);
            CountryModel expected = TestData.ExpectedModelForCountryCode[code.ToLower()];

            CountryModel actual = await processor.GetCountryInfoByCodeAsync(code);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public async Task GetCountryInfoByCodeAsync_WhiteEmptyOrWhitespaceCode_ThrowsArgumentException(string? code)
        {
            CountryDataProcessing processor = new CountryDataProcessing(null);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByCodeAsync(code));
        }

        [Fact]
        public async Task GetCountryInfoByCodeAsync_InvalidCode_ThrowsHttpRequestException()
        {
            var apiMock = new Mock<IApiRequest>();
            apiMock.Setup(x => x.GetJsonFromApiAsync(It.IsAny<string>()))
                .ReturnsAsync(TestData.MockJsonForCountryCode["invalidRequest"]);
            CountryDataProcessing processor = new CountryDataProcessing(apiMock.Object);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByCodeAsync("invalid"));
        }
    }
}
