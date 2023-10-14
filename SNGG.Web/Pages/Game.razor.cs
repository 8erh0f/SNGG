using Microsoft.AspNetCore.Components;
using SNGG.Models.Entities;
using SNGG.Services;

namespace SNGG.Web.Pages
{
    public partial class GameComponent : ComponentBase
    {
        [Inject]
        protected ICheckGuessService CheckGuessService { get; set; }

        [Inject]
        protected ISNGGContextService SNGGContextService { get; set; }

        //[Parameter]
        //public PlayerGameDataDto PlayerGameData { get; set; } = new();
        [Parameter]
        public string PlayerName { get; set; }
        [Parameter]
        public string DateOfBirth { get; set; }
        [Parameter]
        public int NrOfDigits { get; set; }
        [Parameter]
        public int GameId { get; set; }

        protected int ships;
        protected int buoys;
        protected DateTime entryTime;
        protected DateTime previousEntryTime;

        protected bool success;

        protected Dictionary<int, string> ActualNumbers { get; set; } = new();
        protected Dictionary<int, string> GuessedNumbers { get; set; } = new();

        protected override void OnInitialized()
        {
            // TODO?
        }

        protected override void OnParametersSet()
        {
            previousEntryTime = DateTime.Now;

            InitActualNumbers();
            InitGuessedNumbers();

            //if (PlayerGameData is not null)
            //{
            //    ActualNumbers = new();
            //    GuessedNumbers = new();

            //    PlayerName = PlayerGameData.PlayerName;
            //    DateOfBirth = PlayerGameData.DateOfBirth.ToString("dd-MM-yyyy");
            //    for (int i = 1; i < PlayerGameData.NrOfDigits + 1; i++)
            //    {
            //        ActualNumbers.Add(i, GetRandomNumberAsString());
            //        GuessedNumbers.Add(i, "");
            //    }
            //}
        }

        private void InitActualNumbers()
        {
            ActualNumbers = new();
            for (int i = 1; i < NrOfDigits + 1; i++)
            {
                ActualNumbers.Add(i, GetRandomNumberAsString());
            }
        }

        private void InitGuessedNumbers()
        {
            GuessedNumbers = new();
            for (int i = 1; i < NrOfDigits + 1; i++)
            {
                GuessedNumbers.Add(i, "");
            }
        }

        private Dictionary<int, string> CloneDictionary(Dictionary<int, string> toCloneDict)
        {
            var retVal = new Dictionary<int, string>();
            foreach (var item in toCloneDict)
            {
                retVal.Add(item.Key, item.Value);
            }
            return retVal;
        }

        protected void CheckGuess()
        {
            entryTime = DateTime.Now;
            //var EntrySpeed = (entryTime - previousEntryTime).TotalMilliseconds;
            var EntrySpeed = entryTime.Subtract(previousEntryTime).TotalMilliseconds;
            previousEntryTime = entryTime;
            var result = CheckGuessService?.CheckGuessed(CloneDictionary(GuessedNumbers), ActualNumbers);
            if (result is not null)
            {
                ships = result.Item1;
                buoys = result.Item2;
            }
            if (ships == NrOfDigits)
                success = true;

            var newGuess = new Guess
            {
                Buoys = buoys,
                Ships = ships,
                GameId = GameId,
                GuessTime = EntrySpeed
            };
            SNGGContextService.AddGuess(newGuess);

            //StateHasChanged();
        }

        private static string GetRandomNumberAsString()
        {
            var r = new Random();
            int rInt = r.Next(0, 9);
            return rInt.ToString();
        }

        //protected void OnInputDigit(ChangeEventArgs args, int index)
        //{
        //    GuessedNumbers[index] = args.Value.ToString();
        //}
    }
}
