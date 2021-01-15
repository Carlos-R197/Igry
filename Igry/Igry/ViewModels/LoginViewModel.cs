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
using Igry.Constants;

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

                    await navigationService.NavigateAsync($"/{PageName.HomeTabbedPage}");
                }
                else
                    await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.InvalidCredentials, AlertButtonMessages.Dismiss);
            }
        }

        private async Task<bool> EntriesMeetRequirementsAsync()
        {
            bool entriesMeetRequirements = false;

            if (string.IsNullOrWhiteSpace(Password.Value) || string.IsNullOrWhiteSpace(Email.Value))
                await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.EmptyEntries, AlertButtonMessages.Dismiss);
            else if (!Email.IsValid())
                await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.InvalidEmail, AlertButtonMessages.Dismiss);
            else if (!Password.IsValid())
                await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.InvalidPassword, AlertButtonMessages.Dismiss);
            else
                entriesMeetRequirements = true;

            return entriesMeetRequirements;
        }
    }
}
