using System.Configuration;

namespace VISE.Core
{
    public static class SqlGetConnectionString
    {
        public static string GetConnectionString() => SqlDTO.DbConnectionString = ConfigurationManager.ConnectionStrings["DbConnect"].ToString();
    }
}