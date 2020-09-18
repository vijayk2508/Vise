using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VISE.Core.Library.Helper
{
    public class Validation
    {
        public static bool bStatus { get; private set; }

        public static bool EmailValidate(String sEmail)
        {
            Regex reEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@(?:(?:[a-zA-Z0-9-]+\.)?[a-zA-Z]+\.)?(gmail|yahoo|orkut)\.com$");
            if (reEmail.IsMatch(sEmail))
            {
                bStatus = true; 
            }
            return bStatus;
        }

        public static bool MobileNoValidate(String sMobileNo)
        {
            Regex reEmail = new Regex(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}");
            if (reEmail.IsMatch(sMobileNo))
            {
                bStatus = true;
            }
            return bStatus;
        }
    }
}
