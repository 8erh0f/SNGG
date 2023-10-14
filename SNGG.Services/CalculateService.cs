using Microsoft.EntityFrameworkCore;
using SNGG.DataAccess;
using SNGG.Models.Dto;
using SNGG.Models.Entities;
using System.Text.RegularExpressions;
using System.Threading;

namespace SNGG.Services
{
    public interface ICalculateService
    {
        Task<List<GuessesPerDigitCountDto>> CalculateAverageGuessesPerDigitCountAsync();
        Task<List<GuessesPerDigitCountDto>> CalculateMeanGuessesPerDigitCountAsync();
        Task<List<GuessesPerDigitCountDto>> CalculateMinGuessesPerDigitCountAsync();
        Task<List<GuessesPerDigitCountDto>> CalculateMaxGuessesPerDigitCountAsync();
        int CalculateAverageEntrySpeed();
        int CalculateMeanEntrySpeed();
        int CalculateMinEntrySpeed();
        int CalculateMaxEntrySpeed();
        int CalculateRankingPerGuesses();
        int CalculateRankingPerSolutionTime();
    }
    public class CalculateService : ICalculateService
    {
        private readonly SNGGContext _context;

        public CalculateService(SNGGContext context)
        {
            _context = context;
        }

        private static string GetSqlString(string action)
        {
            var sql = @$"SELECT	{action}(GU.aantal) Guesses	
                        ,		NrOfDigits DigitCount
                        FROM	[dbo].[Games] GA
                        ,
		                        (
		                        SELECT	COUNT(Id) aantal
		                        ,		[GameId]
		                        FROM	[dbo].[Guesses]
		                        GROUP BY [GameId]
		                        ) GU
                        WHERE	GU.GameId = Ga.Id 
                        GROUP BY NrOfDigits";

            return sql;
        }

        public async Task<List<GuessesPerDigitCountDto>> CalculateAverageGuessesPerDigitCountAsync()
        {
            var retVal = await _context.GuessesPerDigitCountDtos.FromSqlRaw(GetSqlString("AVG")).ToListAsync();
            return retVal;
        }

        public async Task<List<GuessesPerDigitCountDto>> CalculateMeanGuessesPerDigitCountAsync()
        {
            //var retVal = await _context.GuessesPerDigitCountDtos.FromSqlRaw(GetSqlString("MEAN")).ToListAsync();
            //return retVal;
            return default;
        }

        public async Task<List<GuessesPerDigitCountDto>> CalculateMinGuessesPerDigitCountAsync()
        {
            var retVal = await _context.GuessesPerDigitCountDtos.FromSqlRaw(GetSqlString("MIN")).ToListAsync();
            return retVal;
        }

        public async Task<List<GuessesPerDigitCountDto>> CalculateMaxGuessesPerDigitCountAsync()
        {
            var retVal = await _context.GuessesPerDigitCountDtos.FromSqlRaw(GetSqlString("MAX")).ToListAsync();
            return retVal;
        }

        public int CalculateAverageEntrySpeed()
        {
            return 0;
        }

        public int CalculateMeanEntrySpeed()
        {
            return 0;
        }

        public int CalculateMinEntrySpeed()
        {
            return 0;
        }

        public int CalculateMaxEntrySpeed()
        {
            return 0;
        }

        public int CalculateRankingPerGuesses()
        {
            return 0;
        }

        public int CalculateRankingPerSolutionTime()
        {
            return 0;
        }
    }
}