using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace Igry.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Services
        public readonly IPageDialogService dialogService;
        public readonly INavigationService navigationService;
        #endregion

        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public BaseViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;

        }
        #endregion

        #region Methods
        public bool ThereIsInternetAccess()
        {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }
        #endregion
    }
}
