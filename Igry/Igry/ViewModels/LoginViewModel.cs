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

        private User currentUser;

        public Email Email { get; set; } = new Email();
        public Password Password { get; set; } = new Password();
        public DelegateCommand LogInCommand => logInCommand;


        public LoginViewModel(Database database, INavigationService navigationService, IPageDialogService dialogService, User user)
        {
            this.database = database;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            logInCommand = new DelegateCommand(LogIn);
            currentUser = user;
        }

        private async void LogIn()
        {
            if (await EntriesMeetRequirementsAsync())
            {
                User user = await database.GetUserAsync(Email.Value, Password.Value);
                if (user != null)
                {
                    currentUser.Email = user.Email;
                    currentUser.Name = user.Name;
                    currentUser.Password = user.Password;
                    currentUser.Favorites = user.Favorites;

                    await navigationService.NavigateAsync("/HomeTabbedPage");
                }
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
