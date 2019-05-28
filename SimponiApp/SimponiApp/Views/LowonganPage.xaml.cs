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
    public partial class LowonganPage : ContentPage
    {
        private LowonganService _myService;
        public List<Lowongan> ListLowongan { get; set; }
        public LowonganPage()
        {
            _myService = new LowonganService();
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lvLowongan.ItemsSource = await _myService.GetAllData();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Kesalahan", ex.Message, "OK");
            }
            
        }
    }
}