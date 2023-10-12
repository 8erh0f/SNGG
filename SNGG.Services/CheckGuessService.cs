namespace SNGG.Services
{
    public interface ICheckGuessService
    {
        Tuple<int, int> CheckGuessed(Dictionary<int, string> guessedNumbers, Dictionary<int, string> actualNumbers);
    }

    public class CheckGuessService : ICheckGuessService
    {
        public Tuple<int, int> CheckGuessed(Dictionary<int, string> guessedNumbers, Dictionary<int, string> actualNumbers)
        {
            if (guessedNumbers is null)
            {
                throw new ArgumentNullException(nameof(guessedNumbers));
            }

            if (actualNumbers is null)
            {
                throw new ArgumentNullException(nameof(actualNumbers));
            }

            var ships = 0;
            var buoys = 0;

            foreach (var actualNumber in actualNumbers)
            {
                var actualKey = actualNumber.Key;
                var actualValue = actualNumber.Value; // number is een string hier
                // kijk eerst of er een match is op nummer
                if (guessedNumbers.ContainsValue(actualValue))
                {
                    buoys++;
                    // kijk dan of het nummer ook op de juiste plek staat
                    //actualNumbers.All(e => guessedNumbers.Contains(e)); // IEquatable gaat goed?

                    if (guessedNumbers.TryGetValue(actualKey, out var quessedValue))
                    {
                        if (quessedValue == actualValue)
                        {
                            ships++;
                            buoys--;
                            //guessedNumbers.Remove(actualKey); // deze niet meer gebruiken, die is goed
                        }
                    }
                    guessedNumbers.Remove(actualKey); // deze niet meer gebruiken
                }
            }
            return new Tuple<int, int>(ships, buoys);
        }
    }
}
