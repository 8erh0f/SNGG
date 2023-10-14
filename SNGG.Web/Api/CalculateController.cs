using Microsoft.AspNetCore.Mvc;
using SNGG.Models.Dto;
using SNGG.Services;

namespace SNGG.Web.Api
{
    public class CalculateController : ApiControllerBase
    {
        private readonly ICalculateService _calculateService;

        public CalculateController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        [HttpGet("/AverageGuessesPerDigitCount")]
        public async Task<IActionResult> GetAverageGuessesPerDigitCountAsync()
        {
            var retVal = new List<GuessesPerDigitCountDto>();
            try
            {
                retVal = await _calculateService.CalculateAverageGuessesPerDigitCountAsync();
                //retVal = new List<GuessesPerDigitCountDto> // TODO: moet nog weg
                //{
                //    new GuessesPerDigitCountDto{DigitCount = 4, Guesses = 100 },
                //    new GuessesPerDigitCountDto{DigitCount = 5, Guesses = 250 },
                //    new GuessesPerDigitCountDto{DigitCount = 6, Guesses = 315 },
                //};
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetAverageGuessesPerDigitCountAsync)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/MaxGuessesPerDigitCount")]
        public async Task<IActionResult> GetMaxGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();
            try
            {
                retVal = await _calculateService.CalculateMaxGuessesPerDigitCountAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetMaxGuessesPerDigitCount)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/MinGuessesPerDigitCount")]
        public async Task<IActionResult>  GetMinGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();
            try
            {
                retVal = await _calculateService.CalculateMinGuessesPerDigitCountAsync();
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
