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

        [HttpGet("/MeanGuessesPerDigitCount")]
        public async Task<IActionResult> GetMeanGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();
            try
            {
                //
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetMaxGuessesPerDigitCount)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/AverageEntrySpeedPerUser")]
        public async Task<IActionResult> GetAverageEntrySpeedPerUserAsync()
        {
            var retVal = new List<EntrySpeedPerUserDto>();
            try
            {
                retVal = await _calculateService.CalculateAverageEntrySpeedPerUserAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetAverageGuessesPerDigitCountAsync)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/MaxEntrySpeedPerUser")]
        public async Task<IActionResult> GetMaxEntrySpeedPerUserAsync()
        {
            var retVal = new List<EntrySpeedPerUserDto>();
            try
            {
                retVal = await _calculateService.CalculateMaxEntrySpeedPerUserAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetMaxGuessesPerDigitCount)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/MinEntrySpeedPerUser")]
        public async Task<IActionResult> GetMinEntrySpeedPerUserAsync()
        {
            var retVal = new List<EntrySpeedPerUserDto>();
            try
            {
                retVal = await _calculateService.CalculateMinEntrySpeedPerUserAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout in {nameof(GetMaxGuessesPerDigitCount)}, {ex.Message}");
            }
            return Json(retVal);
        }

        [HttpGet("/MeanEntrySpeedPerUser")]
        public async Task<IActionResult> GetMeanEntrySpeedPerUserAsync()
        {
            var retVal = new List<EntrySpeedPerUserDto>();
            try
            {
                //
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
