using BlazorInputFile;
using BookYourResidency.Shared;
using BookYourResidency.Web.Model;
using BookYourResidency.Web.Services;
using Microsoft.AspNetCore.Components;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace BookYourResidency.Web.Pages
{
    public class PostPropertyBase : ComponentBase
    {

        [Inject]
        private IPropertyServices propertyServices { get; set; }
        [Inject]
        private IOtherServices otherServices { get; set; }
        [Inject]
        public IAddressServices addressServices { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<State> States { get; set; } = new List<State>();
        public List<City> Cities { get; set; } = new List<City>();
        public List<Locality> Localities { get; set; } = new List<Locality>();
        public Property Property { get; set; } = new Property();
        public PropertyInputModel PropertyInputModel { get; set; } = new PropertyInputModel();
        public List<TenantsType> TenantsTypes { get; set; } = new List<TenantsType>();
        public List<PropertyType> PropertyTypes { get; set; } = new List<PropertyType>();

        public List<string> imageDataUrls = new List<string>();
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        protected override async Task OnInitializedAsync()
        {
            PropertyInputModel.UserId = 1;
            TenantsTypes = (await otherServices.GetTenantsTypes()).ToList();
            PropertyTypes = (await otherServices.GetPropertyTypes()).ToList();
            Countries = (await addressServices.GetCountries()).ToList();
        }
        public async Task OnFileInputChangeAsync(IFileListEntry[] files)
        {
            var format = "image/png";
            foreach (var img in files)
            {
                var imageInfo = new Image();
                var resizedImageFile = await img.RequestImageFileAsync(format, 100, 100);
                var buffer = new byte[resizedImageFile.Size];
            }
        }
        protected async Task CountryHasChanged(int countryId)
        {
            PropertyInputModel.StateId = 0;
            PropertyInputModel.CityId = 0;
            PropertyInputModel.LocalityId = 0;
            PropertyInputModel.CountryId = countryId;
            if (countryId == 0)
            {
                States.Clear();
                Cities.Clear();
                Localities.Clear();
            }
            else
            {
                await LoadStates(countryId);
            }
        }
        protected async Task StateHasChanged(int stateId)
        {
            PropertyInputModel.CityId = 0;
            PropertyInputModel.LocalityId = 0;
            PropertyInputModel.StateId = stateId;
            if (stateId == 0)
            {
                Cities.Clear();
                Localities.Clear();
            }
            else
            {
                await LoadCities(stateId);
            }
        }
        protected async Task CityHasChanged(int cityId)
        {
            PropertyInputModel.LocalityId = 0;
            PropertyInputModel.CityId = cityId;
            if (cityId == 0)
            {
                Localities.Clear();
            }
            else
            {
                await LoadLocalities(cityId);
            }
        }
        protected async Task LoadStates(int countryId)
        {
            States = (await addressServices.GetStates(countryId)).ToList();
        }
        protected async Task LoadCities(int stateId)
        {
            Cities = (await addressServices.GetCities(stateId)).ToList();
        }
        protected async Task LoadLocalities(int cityId)
        {
            Localities = (await addressServices.GetLocalities(cityId)).ToList();
        }
        public async Task SubmitHandledAsync()
        {
            Property.UserId = PropertyInputModel.UserId;
            Property.Images = PropertyInputModel.Images;
            Property.Message = PropertyInputModel.Message;
            Property.Phone = PropertyInputModel.Phone;
            Property.RentRate = PropertyInputModel.RentRate;
            Property.SaleRate = PropertyInputModel.SaleRate;
            Property.Negotiable = PropertyInputModel.Negotiable;
            Property.Availability = PropertyInputModel.Availability;
            Property.ForSale = PropertyInputModel.ForSale;
            Property.ForRent = PropertyInputModel.ForRent;
            Property.Location.Country = await addressServices.GetCountry(PropertyInputModel.CountryId);
            Property.Location.State = await addressServices.GetState(PropertyInputModel.StateId);
            Property.Location.City = await addressServices.GetCity(PropertyInputModel.CityId);
            Property.Location.Locality = await addressServices.GetLocality(PropertyInputModel.LocalityId);
            Property.PropertyType = await otherServices.GetPropertyTypeById(PropertyInputModel.PropertyTypeId);
            Property.TenantsId = await otherServices.GetTenantsTypeById(PropertyInputModel.TenantsTypeId);
            var Response = await propertyServices.CreateProperty(Property);
            ErrorMessage = Response.ReasonPhrase;
            Success = Response.IsSuccessStatusCode;
        }
    }
    public enum Availability
    {
        Available,
        Booked
    }
}
