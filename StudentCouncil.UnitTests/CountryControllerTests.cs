using System.Threading.Tasks;
using Xunit;
using Moq;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Models;
using Microsoft.Extensions.Logging;
using StudentCouncil.Api.Controllers;
using System;
using Microsoft.AspNetCore.Mvc;

namespace StudentCouncil.UnitTests
{
    public class CountryControllerTests
    {
        [Fact]
        public async Task GetCountryAsync_WithUnexistingCountry_ReturnsNotFound()
        {
            //Arrange
            var repositoryStub = new Mock<ICountryRepository>();
            repositoryStub.Setup(repo=>repo.GetAsync(It.IsAny<int>())).ReturnsAsync((Country)null);
            var loggerStub = new Mock<ILogger<CountryController>>();

            var controller = new CountryController(repositoryStub.Object, loggerStub.Object);
            //Act
            var rnd = new Random();
            var result = await controller.GetCountryAsync(rnd.Next(0, int.MaxValue));
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}