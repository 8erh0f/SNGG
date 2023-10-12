using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SNGG.Models.Dto;
using SNGG.Services;
using SNGG.Web.Api;

namespace SNGG.Web.Tests
{
    [TestClass]
    public class CalculateControllerTests
    {
        [TestMethod]
        public void ShouldGetAverageGuessesPerDigitCount()
        {
            var calculateService = new CalculateService();
            var controller = new CalculateController(calculateService);
            var result = (JsonResult)controller.GetAverageGuessesPerDigitCount();
            Assert.IsNotNull(result);
            if (result is not null)
            {
                var guessesPerDigitCountDtoList = result.Value as List<GuessesPerDigitCountDto>;
                if (guessesPerDigitCountDtoList is not null)
                {

                }
            }
                
        }
    }
}