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
    public partial class TracerStudyPage : ContentPage
    {
        private TracerStudyService _myService;
        public TracerStudyPage()
        {
            InitializeComponent();
            _myService = new TracerStudyService();
            lvTracerStudy.ItemSelected += LvTracerStudy_ItemSelected;
        }

        private async void LvTracerStudy_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TracerAlumni item = (TracerAlumni)e.SelectedItem;
            if (item.TIPE_JAWABAN == "T")
            {
                JawabTPage jawabTPage = new JawabTPage(item);
                await Navigation.PushAsync(jawabTPage);
            }else {

            }

            /*await DisplayAlert(
                "Keterangan", 
                $"ID Pertanyaan: {item.ID_PERTANYAAN} - Tipe:{item.TIPE_JAWABAN}", "OK");*/
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string idalumni = Application.Current.Properties["idalumni"].ToString();
            try
            {
                lvTracerStudy.ItemsSource = await _myService.GetAll(idalumni);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"Kesalahan: {ex.Message}", "OK");
            }
        }
    }
}