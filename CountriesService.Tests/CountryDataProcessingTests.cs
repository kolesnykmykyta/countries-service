﻿using Autofac.Extras.Moq;
using CountriesService.ApiDataAccess;
using CountriesService.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            CountryModel expected = TestData.ExpectedModelsForCountryCode[code.ToLower()];

            CountryModel actual = await processor.GetCountryInfoByCodeAsync(code);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public async Task GetCountryInfoByCodeAsync_NullEmptyOrWhitespaceCode_ThrowsArgumentException(string? code)
        {
            CountryDataProcessing processor = new CountryDataProcessing(null);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByCodeAsync(code));
        }

        [Fact]
        public async Task GetCountryInfoByCodeAsync_InvalidCode_ThrowsHttpRequestException()
        {
            var apiMock = new Mock<IApiRequest>();
            apiMock.Setup(x => x.GetJsonFromApiAsync(It.IsAny<string>()))
                .ReturnsAsync(TestData.InvalidRequest);
            CountryDataProcessing processor = new CountryDataProcessing(apiMock.Object);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByCodeAsync("invalid"));
        }

        [Theory]
        [InlineData("ukraine")] // Full common country name
        [InlineData("deutschland")] // Full common country name in native language
        [InlineData("egyp")] // Incomplete country name
        public async Task GetCountryInfoByNameAsync_ValidName_ReturnsCorrectCountryInfo(string name)
        {
            var apiMock = new Mock<IApiRequest>();
            apiMock.Setup(x => x.GetJsonFromApiAsync(It.IsAny<string>()))
                .ReturnsAsync(TestData.MockJsonForCountryName[name]);
            CountryDataProcessing processor = new CountryDataProcessing(apiMock.Object);
            CountryModel expected = TestData.ExpectedModelsForCountryName[name];

            CountryModel actual = await processor.GetCountryInfoByNameAsync(name);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public async Task GetCountryInfoByNameAsync_NullEmptyOrWhitespaceName_ThrowsArgumentException(string name)
        {
            CountryDataProcessing processor = new CountryDataProcessing(null);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByNameAsync(name));
        }

        [Fact]
        public async Task GetCountryInfoByNameAsync_InvalidName_ThrowsArgumentException()
        {
            var apiMock = new Mock<IApiRequest>();
            apiMock.Setup(x => x.GetJsonFromApiAsync(It.IsAny<string>()))
                .ReturnsAsync(TestData.InvalidRequest);
            CountryDataProcessing processor = new CountryDataProcessing(apiMock.Object);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByNameAsync("invalid"));
        }

        [Theory]
        [InlineData("tallin")]
        [InlineData("lond")]
        [InlineData("warsaw")]
        public async Task GetCountryInfoByCapitalAsync_ValidCapital_ReturnsCorrectCountryModel(string capital)
        {
            var apiMock = new Mock<IApiRequest>();
            apiMock.Setup(x => x.GetJsonFromApiAsync(It.IsAny<string>()))
                .ReturnsAsync(TestData.MockJsonForCountryCapital[capital]);
            CountryDataProcessing processor = new CountryDataProcessing(apiMock.Object);
            CountryModel expected = TestData.ExpectedModelsForCountryCapital[capital];

            CountryModel actual = await processor.GetCountryInfoByNameAsync(capital);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public async Task GetCountryInfoByCapitalAsync_NullEmptyOrWhitespaceCapital_ThrowsArgumentException(string capital)
        {
            CountryDataProcessing processor = new CountryDataProcessing(null);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByNameAsync(capital));
        }

        [Fact]
        public async Task GetCountryInfoByCapitalAsync_InvalidCapital_ThrowsArgumentException()
        {
            var apiMock = new Mock<IApiRequest>();
            apiMock.Setup(x => x.GetJsonFromApiAsync(It.IsAny<string>()))
                .ReturnsAsync(TestData.InvalidRequest);
            CountryDataProcessing processor = new CountryDataProcessing(apiMock.Object);

            _ = await Assert.ThrowsAsync<ArgumentException>(() => processor.GetCountryInfoByCapitalAsync("invalid"));
        }
    }
}
