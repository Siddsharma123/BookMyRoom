using BookYourResidency.App.Services;
using BookYourResidency.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.App.Pages
{
    public class YourPropertiesBase : ComponentBase
    {
        [Inject]
        private IPropertyServices propertyServices { get; set; }
        //[Parameter]
        //public string Id { get; set; }
        public List<Property> Properties { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Properties = (await propertyServices.GetPropertiesByUserId(1)).ToList();
        }
    }
}
