using System;
using System.Collections.Generic;
using System.Text;

using Igry.Services;
using Igry.Models;
using Prism.Commands;
using System.Windows.Input;
using Prism.Navigation.Xaml;
using Prism.Navigation;
using Prism.Services;

namespace Igry.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        public DelegateCommand LogInCommand { get; set; }

        INavigationService navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            LogInCommand = new DelegateCommand(LogIn);
            this.navigationService = navigationService;
        }

        private async void LogIn()
        {
            await navigationService.NavigateAsync("/NavigationPage/HomeTabbedPage");
        }
    }
}
