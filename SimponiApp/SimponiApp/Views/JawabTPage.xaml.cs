using Newtonsoft.Json;
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
    public partial class JawabTPage : ContentPage
    {
        private TracerStudyService _myService;
        private TracerAlumni _tracerAlumni;
        public JawabTPage(TracerAlumni traceralumni)
        {
            InitializeComponent();
            _tracerAlumni = traceralumni;
            _myService = new TracerStudyService();
            lblPertanyaan.Text = traceralumni.PERTANYAAN;
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
                    INSERT_DATE = "2019-05-22",
                    JAWABAN = edJawaban.Text,
                    IP_ADDRESS=""
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

        public JawabTPage()
        {
            InitializeComponent();
        }

    }
}