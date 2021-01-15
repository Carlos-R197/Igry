using Igry.ViewModels;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Igry.Views
{
    class SettingsViewModel : BaseViewModel
    {

        public SettingsViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
        }
    }
}
