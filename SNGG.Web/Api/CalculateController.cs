using Microsoft.AspNetCore.Mvc;
using SNGG.Models.Dto;
using SNGG.Services;

namespace SNGG.Web.Api
{
    // [Authorize(AuthenticationSchemes = "API_Key")]
    public class CalculateController : ApiControllerBase
    {
        private readonly ICalculateService _calculateService;

        public CalculateController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        [HttpGet("/AverageGuessesPerDigitCount")]
        public IActionResult GetAverageGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();
            try
            {
                retVal = _calculateService.CalculateAverageGuessesPerDigitCount();
                retVal = new List<GuessesPerDigitCountDto> // TODO: moet nog weg
                {
                    new GuessesPerDigitCountDto{DigitCount = 4, Guesses = 100 },
                    new GuessesPerDigitCountDto{DigitCount = 5, Guesses = 250 },
                    new GuessesPerDigitCountDto{DigitCount = 6, Guesses = 315 },
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetAverageGuessesPerDigitCount)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/MaxGuessesPerDigitCount")]
        public IActionResult GetMaxGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();
            try
            {
                retVal = _calculateService.CalculateMaxGuessesPerDigitCount();
                retVal = new List<GuessesPerDigitCountDto> // TODO: moet nog weg
                {
                    new GuessesPerDigitCountDto{DigitCount = 4, Guesses = 1000 },
                    new GuessesPerDigitCountDto{DigitCount = 5, Guesses = 2500 },
                    new GuessesPerDigitCountDto{DigitCount = 6, Guesses = 3150 },
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetMaxGuessesPerDigitCount)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/MinGuessesPerDigitCount")]
        public IActionResult GetMinGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();
            try
            {
                retVal = _calculateService.CalculateMinGuessesPerDigitCount();
                retVal = new List<GuessesPerDigitCountDto> // TODO: moet nog weg
                {
                    new GuessesPerDigitCountDto{DigitCount = 4, Guesses = 50 },
                    new GuessesPerDigitCountDto{DigitCount = 5, Guesses = 150 },
                    new GuessesPerDigitCountDto{DigitCount = 6, Guesses = 201 },
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetMaxGuessesPerDigitCount)}, {ex.Message}");
            }
            return Json(retVal);
        }

        // TODO: rest
    }
}
