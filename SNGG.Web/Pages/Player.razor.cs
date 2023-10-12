using Microsoft.AspNetCore.Components;
using SNGG.Services;

namespace SNGG.Web.Pages
{
    public partial class Player
    {
        [Inject]
        protected ICheckGuessService CheckGuessService { get; set; }
    }
}
