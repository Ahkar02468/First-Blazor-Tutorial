using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKSB.Components
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        public void show()
        {
            ShowConfirmation = true;
        }
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
    }
}
