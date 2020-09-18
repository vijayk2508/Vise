using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace VISE.Web
{
    public class CNAME
    {
        public static string ResolveURL(string URL)
        {
            Page page = HttpContext.Current.Handler as Page;
            return page.ResolveUrl(URL);
        }

        public static string CSS(string URL)
        {
            return string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>",
                ResolveURL(URL));
        }

        public static string JS(string URL)
        {
            return string.Format("<script src='{0}' type='text/javascript'></script>",
                ResolveURL(URL));
        }
    }
}
