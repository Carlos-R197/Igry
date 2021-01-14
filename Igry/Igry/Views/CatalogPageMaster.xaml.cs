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
            public IList<Genre> GenreList { get; set; }
            IGetGenresApiService apiService = new GetGenresApiService();
            ObservableCollection<CatalogPageMasterMenuItem> GenreMenuItems;

            public CatalogPageMasterViewModel()
            {
                for (int i = 0; i < GenreList.Count; i++)
                {
                    GenreMenuItems.Add(new CatalogPageMasterMenuItem { Id = GenreList[i].Id, Title = GenreList[i].Name });
                }
                MenuItems = GenreMenuItems;
                //    new ObservableCollection<CatalogPageMasterMenuItem>(new[]
                //{
                    
                //    new CatalogPageMasterMenuItem { Id = 0, Title = "Accion" },
                //    new CatalogPageMasterMenuItem { Id = 1, Title = "Aventura" },
                //    new CatalogPageMasterMenuItem { Id = 2, Title = "Blah" },
                //    new CatalogPageMasterMenuItem { Id = 3, Title = "Page 4" },
                //    new CatalogPageMasterMenuItem { Id = 4, Title = "Page 5" },
                //});
            }
            public async void LoadGenres(int page)
            {
                var genreList = await apiService.GetGenres();
                GenreList = genreList;
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