using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Igry.Services;
using Igry.Models;
using Prism.Commands;
using System.Windows.Input;
using Prism.Navigation.Xaml;
using Prism.Navigation;
using Prism.Services;
using Igry.Objects;

namespace Igry.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly Database database;
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;
        private readonly DelegateCommand logInCommand;

        public Email Email { get; set; } = new Email();
        public Password Password { get; set; } = new Password();
        public DelegateCommand LogInCommand => logInCommand;


        public LoginViewModel(Database database, INavigationService navigationService, IPageDialogService dialogService)
        {
            this.database = database;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            logInCommand = new DelegateCommand(LogIn);
        }

        private async void LogIn()
        {
            if (await EntriesMeetRequirementsAsync())
            {
                var user = await database.GetUserAsync(Email.Value, Password.Value);
                if (user != null)
                    await navigationService.NavigateAsync("/HomeTabbedPage");
                else
                    await dialogService.DisplayAlertAsync("Error", "The user doesn't exist. Check your email and password.", "OK");
            }
        }

        private async Task<bool> EntriesMeetRequirementsAsync()
        {
            bool entriesMeetRequirements = false;

            if (string.IsNullOrWhiteSpace(Password.Value) || string.IsNullOrWhiteSpace(Email.Value))
                await dialogService.DisplayAlertAsync("Error", "The entries must be filled before attempting to login", "OK");
            else if (!Email.IsValid())
                await dialogService.DisplayAlertAsync("Error", "The email isn't valid.", "OK");
            else if (!Password.IsValid())
                await dialogService.DisplayAlertAsync("Error", "The password isn't valid", "OK");
            else
                entriesMeetRequirements = true;

            return entriesMeetRequirements;
        }
    }
}
