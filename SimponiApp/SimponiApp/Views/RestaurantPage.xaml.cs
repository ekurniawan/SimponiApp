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
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lvRestaurant.ItemsSource = await _myService.GetAll();
        }
    }
}