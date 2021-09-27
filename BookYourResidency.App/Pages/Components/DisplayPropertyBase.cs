using BookYourResidency.App.Custom;
using BookYourResidency.App.Services;
using BookYourResidency.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.App.Pages.Components
{
    public class DisplayPropertyBase : ComponentBase
    {
        [Inject]
        private IPropertyServices propertyServices { get; set; }
        [Inject]
        private NavigationManager navManager { get; set; }
        [Parameter]
        public Property Property { get; set; } = new Property();
        [Parameter]
        public bool ShowFooter { get; set; }
        protected ConfirmModal DeleteConfirmation { get; set; }
        public List<string> ImagesDataUrl { get; set; } = new List<string>();
        protected override void OnInitialized()
        {
            if(Property.Images != null)
            {
                var format = "Image/jpg";
                foreach (var item in Property.Images)
                {
                    var buffer = item.Filse;
                    var imgurl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                    ImagesDataUrl.Add(imgurl);
                }
            }
        }
        protected async Task DeleteAsync()
        {
            DeleteConfirmation.Show();
        }
        protected async Task ConfirmDelete(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await propertyServices.DeleteProperty(Property.PropertyId);
                navManager.NavigateTo("/yourproperties", forceLoad: true);
            }
        }
    }
}
