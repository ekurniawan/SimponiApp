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
    public partial class LoginPage : ContentPage
    {
        private LoginService _myService;
        public LoginPage()
        {
            InitializeComponent();
            _myService = new LoginService();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.Properties.ContainsKey("alumni"))
            {
                await Navigation.PushAsync(new MenuTabbedPage());
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var data = await _myService.GetLogin(entryUsernameAlumni.Text, 
                    entryPasswordAlumni.Text);
                if (data != null)
                {
                    Application.Current.Properties["alumni"] = data.NAMA_MHS;
                    Application.Current.Properties["idalumni"] = data.ID_ALUMNI;
                    await Application.Current.SavePropertiesAsync();
                    await Navigation.PushAsync(new MenuTabbedPage());
                }
                else
                {
                    await DisplayAlert("Keterangan", "Login Gagal","OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Keterangan", ex.Message, "OK");
            }
        }

        private async void BtnCekSession_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("alumni"))
            {
                var data = Application.Current.Properties["alumni"];
                await DisplayAlert("Keterangan", $"Nama {data}", "OK");
            }
            else
            {
                await DisplayAlert("Keterangan", "Tidak Ditemukan", "OK");
            }
        }
    }
}