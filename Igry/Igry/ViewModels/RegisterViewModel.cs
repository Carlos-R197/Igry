using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Igry.Models;
using System.Threading.Tasks;
using Igry.Constants;

namespace Igry.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly Database database;
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;
        private readonly DelegateCommand registerCommand;

        public Email Email { get; set; } = new Email();
        public string Name { get; set; }
        public Password Password { get; set; } = new Password();
        public string ConfirmPassword { get; set; }

        public DelegateCommand RegisterCommand => registerCommand;

        public RegisterViewModel(Database database, INavigationService navigationService, IPageDialogService dialogService)
        {
            this.database = database;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            registerCommand = new DelegateCommand(Register);
        }

        private async void Register()
        {
            if (await EntriesMeetRequirementsAsync())
            {
                if (await database.IsEmailTaken(Email.Value))
                    await dialogService.DisplayAlertAsync("Error", ErrorMessages.ExistingEmail, "OK");
                else
                {
                    var user = new User(Email.Value, Name, Password.Value);
                    var savingUser = database.SaveUserAsync(user);
                    await dialogService.DisplayAlertAsync("Registration successful", SuccessMessages.RegistrationCompleted, "OK");
                    await savingUser;
                    await navigationService.GoBackAsync();
                }
            }
        }

        private async Task<bool> EntriesMeetRequirementsAsync()
        {
            bool EntriesMeetRequirements = false;

            if (AreEntriesEmpty())
                await dialogService.DisplayAlertAsync("Error", ErrorMessages.EmptyEntries, "OK");
            else if (Password.Value != ConfirmPassword)
                await dialogService.DisplayAlertAsync("Error", ErrorMessages.PasswordsDontMatch, "OK");
            else if (!Password.IsValid())
                await dialogService.DisplayAlertAsync("Error", ErrorMessages.InvalidPassword, "OK");
            else if (!Email.IsValid())
                await dialogService.DisplayAlertAsync("Error", ErrorMessages.InvalidEmail, "OK");
            else
                EntriesMeetRequirements = true;

            return EntriesMeetRequirements;
        }

        private bool AreEntriesEmpty()
        {
            return string.IsNullOrWhiteSpace(Email.Value) || string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Password.Value) || string.IsNullOrWhiteSpace(ConfirmPassword);
        }
    }
}
