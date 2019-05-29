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
    public partial class JawabSPage : ContentPage
    {
        private TracerAlumni _tracerAlumni;
        public List<JawabanTracerAlumni> JawabTracerAlumni { get; set; }
        private string pilihan;
        public JawabSPage(TracerAlumni traceralumni)
        {
            InitializeComponent();
            _tracerAlumni = traceralumni;
            lblPertanyaan.Text = traceralumni.PERTANYAAN;
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