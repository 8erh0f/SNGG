using Microsoft.AspNetCore.Components;
using SNGG.Models.Dto;
using SNGG.Services;

namespace SNGG.Web.Pages
{
    public partial class Game
    {
        [Inject]
        protected ICheckGuessService? CheckGuessService { get; set; }

        [Parameter]
        public PlayerGameDataDto? PlayerGameData { get; set; }

        protected int ships;
        protected int buoys;
        protected DateTime entryTime;
        protected DateTime previousEntryTime;
        protected string? playerName;
        protected string? dateOfBirth;
        protected bool success;

        protected Dictionary<int, string> actualNumbers = new();

        protected override void OnInitialized()
        {
            // TODO?
        }

        protected override void OnParametersSet()
        {
            previousEntryTime = DateTime.Now;
            // TODO: voor testen
            PlayerGameData ??= new PlayerGameDataDto { DateOfBirth = new DateOnly(1969, 12, 24), NrOfDigits = 4, PlayerName = "Hans" };

            if (PlayerGameData is not null)
            {
                playerName = PlayerGameData.PlayerName;
                dateOfBirth = PlayerGameData.DateOfBirth.ToString("dd-MM-yyyy");
                for (int i = 1; i < PlayerGameData.NrOfDigits + 1; i++)
                {
                    actualNumbers.Add(i, GetRandomNumberAsString());
                }
            }
        }

        protected void CheckGuess()
        {
            entryTime = DateTime.Now;
            var EntrySpeed = (previousEntryTime - entryTime).TotalMilliseconds;
            previousEntryTime = entryTime;
            // TODO: hier uit scherm vullen
            var quessedNumbers = new Dictionary<int, string> { { 1, "9" }, { 2, "5" }, { 3, "8" }, { 4, "1" } };

            var result = CheckGuessService?.CheckGuessed(quessedNumbers, actualNumbers);
            if (result is not null)
            {
                ships = result.Item1;
                buoys = result.Item2;
            }
            if (ships == PlayerGameData?.NrOfDigits)
                success = true;

            StateHasChanged();
        }

        private static string GetRandomNumberAsString()
        {
            var r = new Random();
            int rInt = r.Next(0, 9);
            return rInt.ToString();
        }
    }
}
