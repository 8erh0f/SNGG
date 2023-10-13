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
        protected NavigationManager UriHelper { get; set; }

        public PlayerGameDataDto PlayerGameData { get; set; } = new();

        public string PlayerName { get; set; }

        protected void PlayGame()
        {
            UriHelper.NavigateTo($"/game/{PlayerGameData.NrOfDigits}/{PlayerGameData.PlayerName}/{PlayerGameData.DateOfBirth}");
        }
    }
}
