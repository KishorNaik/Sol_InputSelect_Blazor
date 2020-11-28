using Microsoft.AspNetCore.Components.Forms;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Pages.Demo
{
    public partial class InputSelectDemo
    {
        public InputSelectDemo()
        {
        }

        #region Private Property

        private CityModel City { get; set; }

        private List<CityModel> ListCities { get; set; }

        private String Message { get; set; }

        private bool IsLoad { get; set; }

        #endregion Private Property

        #region Private Method

        private void GetCityData()
        {
            ListCities = new List<CityModel>();
            ListCities.Add(new CityModel() { Id = 1, Name = "Mumbai" });
            ListCities.Add(new CityModel() { Id = 2, Name = "Thane" });
            ListCities.Add(new CityModel() { Id = 3, Name = "Navi Mumbai" });
        }

        private void GetCityData(int id)
        {
            City =
                 ListCities
                 .FirstOrDefault((cityModel) => cityModel.Id == id);
        }

        #endregion Private Method

        #region Ui Event Handler

        private void OnSubmit(EditContext editContext)
        {
            var flag = editContext.Validate();
            if (flag == false)
            {
                return;
            }

            GetCityData(City.Id);

            Message = $"User Select {City.Name} city and Id is {City.Id}";

            base.StateHasChanged();
        }

        #endregion Ui Event Handler

        #region Protected Method

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                this.GetCityData();
                IsLoad = true;
                City = new CityModel();

                // On Load Selected
                //City.Id = 2;

                base.StateHasChanged();
            }
        }

        #endregion Protected Method
    }
}