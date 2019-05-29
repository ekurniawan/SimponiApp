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
    public partial class JawabTPage : ContentPage
    {
        private TracerAlumni _tracerAlumni;
        public JawabTPage(TracerAlumni traceralumni)
        {
            InitializeComponent();
            _tracerAlumni = traceralumni;
            lblPertanyaan.Text = traceralumni.PERTANYAAN;
        }

        public JawabTPage()
        {
            InitializeComponent();
        }

    }
}