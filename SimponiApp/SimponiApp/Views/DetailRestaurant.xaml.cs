using SimponiApp.Models;
using SimponiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimponiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailRestaurant : ContentPage
    {
        private RestaurantServices _myService;
        public DetailRestaurant()
        {
            InitializeComponent();
            _myService = new RestaurantServices();
            btnEdit.Clicked += BtnEdit_Clicked;
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var editResto = new Restaurant
                {
                    restaurantid = Convert.ToInt32(txtID.Text),
                    namarestaurant = txtName.Text,
                    categoryid = Convert.ToInt32(txtCategoryID.Text)
                };
                var result = await _myService.Update(editResto);
                await DisplayAlert("Keterangan", $"Data resto {editResto.namarestaurant} berhasil diedit", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex) 
            {
                await DisplayAlert("Kesalahan", ex.Message, "OK");
            }
        }
    }
}