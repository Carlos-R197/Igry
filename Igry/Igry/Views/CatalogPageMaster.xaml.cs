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

namespace Igry.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogPageMaster : ContentPage
    {
        public ListView ListView;

        public CatalogPageMaster()
        {
            InitializeComponent();

            BindingContext = new CatalogPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class CatalogPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<CatalogPageMasterMenuItem> MenuItems { get; set; }

            public CatalogPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<CatalogPageMasterMenuItem>(new[]
                {
                    new CatalogPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new CatalogPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new CatalogPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new CatalogPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new CatalogPageMasterMenuItem { Id = 4, Title = "Page 5" },
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