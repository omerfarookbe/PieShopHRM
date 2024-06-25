using Microsoft.AspNetCore.Components;
using PieShopHRM.State;

namespace PieShopHRM.Components
{
    public partial class InboxCounter
    {
        [Inject]
        public ApplicationState applicationState {  get; set; }

        private int MessageCount;

        protected override void OnInitialized()
        {
            MessageCount = new Random().Next(10);
            applicationState.NumberOfMessages = MessageCount;
        }
    }
}
