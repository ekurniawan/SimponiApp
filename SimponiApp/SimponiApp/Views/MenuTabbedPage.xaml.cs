using SimponiApp.Models;
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
    public partial class MenuTabbedPage : TabbedPage
    {
        public MenuTabbedPage()
        {
            InitializeComponent();
            btnHal1.Clicked += BtnHal1_Clicked;
        }

        private async void BtnHal1_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties["alumni"] != null)
            {
                var data = Application.Current.Properties["alumni"];
                await DisplayAlert("Keterangan", $"Nama: {data}", "OK");
            }
        }
    }
}