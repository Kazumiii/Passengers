using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
    //this class has all our errorCode
    public static class ErrorCode
    {
        public static string InvalideUserName => "Invalide username";

        public static string InvalideEmail => "Invalide email";

        public static string InvalideRole => "Invalide role";

        public static string InvalidePassword => "Invalide password";

        public static string InvalidCredential => "Invalide credentials";

        public static string EmailInUse => "Email is alredy use";

        public static string InvalidDriver => "Driver already exist";

        public static string InvalidUser => "User not found";

    }
}
