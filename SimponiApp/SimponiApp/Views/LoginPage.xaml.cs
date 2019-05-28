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

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var data = await _myService.GetLogin(entryUsernameAlumni.Text, 
                    entryPasswordAlumni.Text);
                if (data != null)
                {
                    Application.Current.Properties["alumni"] = data;
                    await Navigation.PushAsync(new LowonganPage());
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
    }
}