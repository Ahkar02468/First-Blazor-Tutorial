using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKSB.Components
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete Confirmation";
        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete?";
        protected async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
