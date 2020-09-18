using System;

namespace VISE.Core.Library.Helper
{
    public class General
    {
        public static DateTime GetDateString(string sDate)
        {
            long.TryParse(sDate, out long nDate);
            DateTime dtDate = new DateTime(nDate);
            dtDate.ToOADate().ToString("dd/MM/yyyy");
            return dtDate;
        }
    }
}
