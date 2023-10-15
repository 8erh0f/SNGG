using Microsoft.EntityFrameworkCore;
using SNGG.DataAccess;
using SNGG.Models.Dto;

namespace SNGG.Services
{
    public interface ICalculateService
    {
        Task<List<GuessesPerDigitCountDto>> CalculateAverageGuessesPerDigitCountAsync();
        Task<List<GuessesPerDigitCountDto>> CalculateMeanGuessesPerDigitCountAsync();
        Task<List<GuessesPerDigitCountDto>> CalculateMinGuessesPerDigitCountAsync();
        Task<List<GuessesPerDigitCountDto>> CalculateMaxGuessesPerDigitCountAsync();
        Task<List<EntrySpeedPerUserDto>> CalculateAverageEntrySpeedPerUserAsync();
        Task<List<EntrySpeedPerUserDto>> CalculateMeanEntrySpeedPerUserAsync();
        Task<List<EntrySpeedPerUserDto>> CalculateMinEntrySpeedPerUserAsync();
        Task<List<EntrySpeedPerUserDto>> CalculateMaxEntrySpeedPerUserAsync();
        //Task<List<>> CalculateRankingPerGuessesAsync();
        //Task<List<>> CalculateRankingPerSolutionTimeAsync();
    }
    public class CalculateService : ICalculateService
    {
        private readonly SNGGContext _context;

        public CalculateService(SNGGContext context)
        {
            _context = context;
        }

        public async Task<List<GuessesPerDigitCountDto>> CalculateAverageGuessesPerDigitCountAsync()
        {
            var retVal = await _context.GuessesPerDigitCountDtos.FromSqlRaw(GetPerDigitSqlString("AVG")).ToListAsync();
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
            var retVal = await _context.GuessesPerDigitCountDtos.FromSqlRaw(GetPerDigitSqlString("MIN")).ToListAsync();
            return retVal;
        }

        public async Task<List<GuessesPerDigitCountDto>> CalculateMaxGuessesPerDigitCountAsync()
        {
            var retVal = await _context.GuessesPerDigitCountDtos.FromSqlRaw(GetPerDigitSqlString("MAX")).ToListAsync();
            return retVal;
        }

        public async Task<List<EntrySpeedPerUserDto>> CalculateAverageEntrySpeedPerUserAsync()
        {
            var retVal = await _context.EntrySpeedPerUserDtos.FromSqlRaw(GetPerUserSqlString("AVG")).ToListAsync();
            return retVal;
        }

        public async Task<List<EntrySpeedPerUserDto>> CalculateMeanEntrySpeedPerUserAsync()
        {
            //var retVal = await _context.EntrySpeedPerUserDtos.FromSqlRaw(GetPerUserSqlString("")).ToListAsync();
            //return retVal;
            return default;
        }

        public async Task<List<EntrySpeedPerUserDto>> CalculateMinEntrySpeedPerUserAsync()
        {
            var retVal = await _context.EntrySpeedPerUserDtos.FromSqlRaw(GetPerUserSqlString("MIN")).ToListAsync();
            return retVal;
        }

        public async Task<List<EntrySpeedPerUserDto>> CalculateMaxEntrySpeedPerUserAsync()
        {
            var retVal = await _context.EntrySpeedPerUserDtos.FromSqlRaw(GetPerUserSqlString("MAX")).ToListAsync();
            return retVal;
        }

        public int CalculateRankingPerGuesses()
        {
            return 0;
        }

        public int CalculateRankingPerSolutionTime()
        {
            return 0;
        }

        private static string GetPerDigitSqlString(string action)
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

        private static string GetPerUserSqlString(string action)
        {
            var sql = @$"SELECT	{action}(GU.GuessTime) EntrySpeed
                        ,		PL.PlayerName
                        ,		PL.DateOfBirth
                        FROM	[dbo].[Guesses] GU
                        JOIN	[dbo].[Games] GA
		                        ON	GA.Id = GU.GameId
                        JOIN	[dbo].[Players] PL 
		                        ON	GA.PlayerId = PL.Id
                        GROUP BY PL.PlayerName, PL.DateOfBirth";

            return sql;
        }

    }
}