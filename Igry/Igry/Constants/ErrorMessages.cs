using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Igry.Views;

namespace Igry.Constants
{
    public static class ErrorMessages
    {
        public static string NoInternetAccess = "There's no internet connection, check and try again.";

        // Register Page 
        public static string ExistingEmail = "This email is already taken by another user.";
        public static string EmptyEntries = "All the entries must be filled.";
        public static string PasswordsDontMatch = "Passwords Don't Match.";
        public static string InvalidPassword = "Password doesnt meet the requirements.";
        public static string InvalidEmail = "This is not a valid Email Address.";

        // Login Page 
        public static string InvalidCredentials = "Invalid Email or Password, check and try again.";

        // GameDetail Page
        public static string NoDataForGame = "No platform data available for this game.";
        
    }
}
