using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace VISE.Core
{
    public class SqlAPI : SqlDTO
    {
        #region Global Variable
        private static SqlConnection sqlConnection;
        private static Collection<DataRow> collectionDataRow;
        #endregion

        /// <summary>
        /// Get Count Without having DataReader
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        #region GetCount
        public static int GetCount(string sQuery)
        {
            try
            {
                sqlConnection = objSqlConnection;
                objSqlCommand = new SqlCommand(sQuery, sqlConnection);
                sqlConnection.Open();
                Count = Convert.ToInt32(objSqlCommand.ExecuteScalar());
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return string.IsNullOrWhiteSpace(sQuery) ? 0 : Count;
        }
        #endregion

        /// <summary>
        /// This function is Use for Crud Operation
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        #region SqlCrud
        public static int SqlCrud(string sQuery)
        {
            sqlConnection = objSqlConnection;
            objSqlCommand = new SqlCommand(sQuery, sqlConnection);

            try
            {
                sqlConnection.Open();
                Result = objSqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return Result;
        }
        #endregion

        /// <summary>
        /// This function is use for Executing the Query
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        #region ExecuteQuery
        public static int ExecuteQuery(string sQuery)
        {
            return string.IsNullOrEmpty(sQuery) ? 0 : SqlCrud(sQuery);
        }
        #endregion

        /// <summary>
        /// This  function is used to Store Datatable row into Collection 
        /// </summary>
        /// <param name="sSelectQuery"></param>
        /// <returns></returns>
        #region GetCollection
        public static Collection<DataRow> GetAll(string sSelectQuery)
        {
            sqlConnection = objSqlConnection;
            DataTable objDataTable = new DataTable();
            try
            {
                objSqlCommand = new SqlCommand(sSelectQuery, sqlConnection);
                sqlConnection.Open();
                objSqlDataReader = objSqlCommand.ExecuteReader();
                objDataTable.Load(objSqlDataReader);
                //IEnumerable<DataRow> sequence = objDataTable.AsEnumerable();//working well
                collectionDataRow = new Collection<DataRow>(objDataTable.Select());
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return collectionDataRow;
        }
        #endregion

        /// <summary>
        /// This function is use check the data in the database and then perform Save and Update operation 
        /// </summary>
        /// <param name="sInsertQuery"></param>
        /// <param name="sUpdateQuery"></param>
        #region Save & Update
        public static void SaveAndUpdate(string sInsertQuery, string sUpdateQuery)
        {
            Count = ExecuteQuery(sUpdateQuery);

            Result = Count > 0 ? ExecuteQuery(sUpdateQuery) : ExecuteQuery(sInsertQuery);

           // Console.Write(Result > 0 ? (Count > 0 ? @"Update Successfully" : @"Save Succcesfully") : @"Error");
        }
        #endregion

        /// <summary>
        /// This function is Used for Save
        /// </summary>
        /// <param name="sQuery"></param>
        #region Save
        public static int Save(string sQuery)
        {
            return Result = ExecuteQuery(sQuery);
          //  Console.Write(Result > 0 ? "Save Succcesfully" : @"Error");
        }
        #endregion

        /// <summary>
        /// This function is Used for Save
        /// </summary>
        /// <param name="sDeleteQuery"></param>
        #region Delete
        public static int Delete(string sDeleteQuery)
        {
            Count = ExecuteQuery(sDeleteQuery);

           return Result = Count > 0 ? ExecuteQuery(sDeleteQuery) : 0;

         //   Console.Write(Result > 0 ? (Count > 0 ? @"Delete Succesfully" : @"Sorry data is not exist") : "Error");
        }
        #endregion
    }
}
