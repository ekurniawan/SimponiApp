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
    public partial class JawabSPage : ContentPage
    {
        private TracerAlumni _tracerAlumni;
        private TracerStudyService _myService;
        public List<JawabanTracerAlumni> JawabTracerAlumni { get; set; }
        private string _pilihan = string.Empty;
        public JawabSPage(TracerAlumni traceralumni)
        {
            InitializeComponent();
            _tracerAlumni = traceralumni;
            lblPertanyaan.Text = traceralumni.PERTANYAAN;
            _myService = new TracerStudyService();
            lvJawaban.ItemSelected += LvJawaban_ItemSelected;
            btnSubmit.Clicked += BtnSubmit_Clicked;
        }

        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newJawab = new TambahTracerAlumni
                {
                    ID_ALUMNI = Application.Current.Properties["idalumni"].ToString(),
                    ID_PERTANYAAN = _tracerAlumni.ID_PERTANYAAN,
                    ID_SURVEY = _tracerAlumni.ID_SURVEY,
                    USERNAME = Application.Current.Properties["alumni"].ToString(),
                    INSERT_DATE = DateTime.Now.ToShortDateString(),
                    JAWABAN = _pilihan,
                    IP_ADDRESS = ""
                };
                SimpanTracerAlumni result = await _myService.Insert(newJawab);
                //await DisplayAlert("Keterangan", $"{JsonConvert.SerializeObject(newJawab)} - result {result.STATUS} - content: {result.CONTENT}","OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", ex.Message, "OK");
            }
        }

        private void LvJawaban_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            JawabanTracerAlumni pilihan = (JawabanTracerAlumni)e.SelectedItem;
            _pilihan = pilihan.PILIHAN;
            btnSubmit.IsEnabled = true;
        }

        public JawabSPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvJawaban.ItemsSource = JawabTracerAlumni;
        }
    }
}