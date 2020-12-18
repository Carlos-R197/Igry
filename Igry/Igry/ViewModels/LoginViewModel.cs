using System;
using System.Collections.Generic;
using System.Text;

using Igry.Services;
using Igry.Models;
using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation.Xaml;

namespace Igry.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LogInCommand => new Command(LogIn);

        private void LogIn()
        {
            
        }
    }
}
