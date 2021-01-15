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
using Igry.Services;
using Igry.Models;

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
            public IList<Genre> GenresList { get; set; }
            IGetGenresApiService apiService = new GetGenresApiService();

            public CatalogPageMasterViewModel()
            {
               LoadGenres();
               //MenuItems = new ObservableCollection<CatalogPageMasterMenuItem>();
               //for (int i = 0; i < 19; i++)
               //{                   
               //     CatalogPageMasterMenuItem menuItem = new CatalogPageMasterMenuItem { Id = GenresList[i].Id, Title = GenresList[i].Name};
               //     MenuItems.Add(menuItem);
               //}

                //    new ObservableCollection<CatalogPageMasterMenuItem>(new[]
                //{

                //        new CatalogPageMasterMenuItem { Id = 0, Title = "Accion" },
                //        new CatalogPageMasterMenuItem { Id = 1, Title = "Aventura" },
                //        new CatalogPageMasterMenuItem { Id = 2, Title = "Blah" },
                //        new CatalogPageMasterMenuItem { Id = 3, Title = "Page 4" },
                //        new CatalogPageMasterMenuItem { Id = 4, Title = "Page 5" },
                //    });
            }
            public async void LoadGenres()
            {
                var genreList = await apiService.GetGenres();
                GenresList = genreList;
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