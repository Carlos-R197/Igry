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
using Prism.Commands;

namespace Igry.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogPageMaster : ContentPage
    {   
        public CatalogPageMaster()
        {
            InitializeComponent();

            BindingContext = new CatalogPageMasterViewModel();
        }

        class CatalogPageMasterViewModel : INotifyPropertyChanged
        {
            IGetGenresApiService apiService = new GetGenresApiService();

            public event PropertyChangedEventHandler PropertyChanged;

            public ObservableCollection<CatalogPageMasterMenuItem> MenuItems { get; set; }
            public IList<Genre> GenresList { get; set; }
            public IList<Genre> SelectedGenres { get; set; }
            public DelegateCommand FilterCommand => new DelegateCommand(Filter);
            public DelegateCommand AddGenreToListCommand => new DelegateCommand(AddGenreToList);

            public CatalogPageMasterViewModel()
            {
               LoadGenres();
                SelectedGenres = new List<Genre>();
            }
            public async void LoadGenres()
            {
                var genreList = await apiService.GetGenres();
                GenresList = genreList;
            }
            public void Filter()
            {
                if (SelectedGenres.Count!=0)
                {
                    var num = SelectedGenres.Count;
                }
            }
            public void AddGenreToList()
            {

            }

            //#region INotifyPropertyChanged Implementation
            //public event PropertyChangedEventHandler PropertyChanged;
            //void OnPropertyChanged([CallerMemberName] string propertyName = "")
            //{
            //    if (PropertyChanged == null)
            //        return;

            //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}
            //#endregion
        }
    }
}