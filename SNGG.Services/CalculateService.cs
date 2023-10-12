using SNGG.Models.Dto;

namespace SNGG.Services
{
    public interface ICalculateService
    {
        List<GuessesPerDigitCountDto> CalculateAverageGuessesPerDigitCount();
        List<GuessesPerDigitCountDto> CalculateMeanGuessesPerDigitCount();
        List<GuessesPerDigitCountDto> CalculateMinGuessesPerDigitCount();
        List<GuessesPerDigitCountDto> CalculateMaxGuessesPerDigitCount();
        int CalculateAverageEntrySpeed();
        int CalculateMeanEntrySpeed();
        int CalculateMinEntrySpeed();
        int CalculateMaxEntrySpeed();
        int CalculateRankingPerGuesses();
        int CalculateRankingPerSolutionTime();
    }
    public class CalculateService : ICalculateService
    {
        public List<GuessesPerDigitCountDto> CalculateAverageGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();

            return retVal;
        }

        public List<GuessesPerDigitCountDto> CalculateMeanGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();

            return retVal;
        }

        public List<GuessesPerDigitCountDto> CalculateMinGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();

            return retVal;
        }

        public List<GuessesPerDigitCountDto> CalculateMaxGuessesPerDigitCount()
        {
            var retVal = new List<GuessesPerDigitCountDto>();

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