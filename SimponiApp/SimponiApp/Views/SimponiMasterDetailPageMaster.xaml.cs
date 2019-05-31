using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimponiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimponiMasterDetailPageMasterMaster : ContentPage
    {
        public ListView ListView;

        public SimponiMasterDetailPageMasterMaster()
        {
            InitializeComponent();

            BindingContext = new SimponiMasterDetailPageMasterMasterViewModel();
            ListView = MenuItemsListView;
        }

        class SimponiMasterDetailPageMasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SimponiMasterDetailPageMenuItemMenuItem> MenuItems { get; set; }

            public SimponiMasterDetailPageMasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<SimponiMasterDetailPageMenuItemMenuItem>(new[]
                {
                    new SimponiMasterDetailPageMenuItemMenuItem { Id = 0, Title = "Lowongan",
                        TargetType = typeof(LowonganPage) },
                    new SimponiMasterDetailPageMenuItemMenuItem { Id = 1, Title = "Tracer Study",
                        TargetType= typeof(TracerStudyPage)},
                    new SimponiMasterDetailPageMenuItemMenuItem { Id = 2, Title = "Page 3" },
                    new SimponiMasterDetailPageMenuItemMenuItem { Id = 3, Title = "Page 4" },
                    new SimponiMasterDetailPageMenuItemMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}