using System;
using System.Collections.Generic;
using System.Text;

using Igry.Services;
using Igry.Models;
using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation.Xaml;
using Prism.Navigation;

namespace Igry.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        public ICommand LogInCommand => new Command(LogIn);
        public INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
        }

        private async void LogIn()
        {
            await _navigationService.NavigateAsync("HomeTabbedPage");
        }
    }
}
