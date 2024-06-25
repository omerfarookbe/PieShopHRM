using Microsoft.AspNetCore.Components;
using PieShopHRM.State;

namespace PieShopHRM.Components.Widgets
{
    public partial class InboxWidget
    {

        [Inject]
        public ApplicationState applicationState {  get; set; }
        public int MessageCount { get; set; } = 0;

        protected override void OnInitialized()
        {
            MessageCount = applicationState.NumberOfMessages;
        }
    }
}
