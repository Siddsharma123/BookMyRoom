using BlazorApp1.Services;
using BookYourResidency.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class PostPropertyBase : ComponentBase
    {
        [Inject]
        public IAddressServices addressServices { get; set; }
        public List<Country> countries { get; set; } = new List<Country>();

        protected override async Task OnInitializedAsync()
        {
            countries =(await addressServices.GetCountries()).ToList();
        }
    }
}
