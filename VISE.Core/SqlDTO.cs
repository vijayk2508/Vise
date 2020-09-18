using System.Data.SqlClient;

namespace VISE.Core
{
    public class SqlDTO
    {
        #region Global
        private static bool mbStatus = false;

        private static int mCount = -1;
        private static int mResult = -1;

        private static string mDbConnectionString = string.Empty;
        private static string mObjSqlQuery = string.Empty;

        private static SqlConnection mObjSqlConnection = null;
        private static SqlCommand mObjSqlCommand;
        private static SqlDataReader mObjSqlDataReader = null;
        #endregion

        #region Property
        public static bool bStatus { get => mbStatus; set => mbStatus = value; }

        public static int Count { get => mCount; set => mCount = value; }
        public static int Result { get => mResult; set => mResult = value; }

        public static string DbConnectionString { get => mDbConnectionString; set => mDbConnectionString = value; }
        public static string query { get => mObjSqlQuery; set => mObjSqlQuery = value; }

        public static SqlConnection objSqlConnection { get => new SqlConnection(SqlGetConnectionString.GetConnectionString()); set => mObjSqlConnection = value; }
        public static SqlCommand objSqlCommand { get => mObjSqlCommand; set => mObjSqlCommand = value; }
        public static SqlDataReader objSqlDataReader { get => mObjSqlDataReader; set => mObjSqlDataReader = value; }
        #endregion
    }
}