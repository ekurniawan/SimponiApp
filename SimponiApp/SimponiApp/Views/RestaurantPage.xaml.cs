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
    public partial class RestaurantPage : ContentPage
    {
        private RestaurantServices _myService;
        public RestaurantPage()
        {
            InitializeComponent();
            _myService = new RestaurantServices();
            lvRestaurant.ItemSelected += LvRestaurant_ItemSelected;
           
        }

        private async void LvRestaurant_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Restaurant)e.SelectedItem;
            DetailRestaurant detailResto = new DetailRestaurant();
            detailResto.BindingContext = item;
            await Navigation.PushAsync(detailResto);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lvRestaurant.ItemsSource = await _myService.GetAll();
        }
    }
}