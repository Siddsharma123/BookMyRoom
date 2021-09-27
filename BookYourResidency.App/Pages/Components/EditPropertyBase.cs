using BookYourResidency.Api.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.App.Pages.Components
{
    public class EditPropertyBase : ComponentBase
    {
        [Inject]
        private IPropertyServices propertyServices { get; set; }

        [Parameter]
        public string id { get; set; }





    }
}
