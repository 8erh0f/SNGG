using Microsoft.AspNetCore.Components;
using SNGG.Models.Dto;
using SNGG.Services;

namespace SNGG.Web.Pages
{
    public partial class PlayerComponent : ComponentBase
    {
        [Inject]
        protected ICheckGuessService CheckGuessService { get; set; }

        [Inject]
        protected ISNGGContextService SNGGContextService { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        public PlayerGameDataDto PlayerGameData { get; set; } = new();

        protected void PlayGame()
        {
            // save player info
            var player = new Models.Entities.Player
            {
                PlayerName = PlayerGameData.PlayerName,
                DateOfBirth = PlayerGameData.DateOfBirth
            };
            SNGGContextService.AddPlayer(player);
            // save game
            var gameId = SNGGContextService.AddGame(new Models.Entities.Game 
            { 
                NrOfDigits = PlayerGameData.NrOfDigits,
                //Player = player,
                PlayerId = player.Id
            });

            UriHelper.NavigateTo($"/game/{gameId}/{PlayerGameData.NrOfDigits}/{PlayerGameData.PlayerName}/{PlayerGameData.DateOfBirth}");
        }
    }
}
