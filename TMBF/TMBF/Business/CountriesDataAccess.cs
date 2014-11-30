using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TMBF.Business
{
    public class CountriesDataAccess
    {
        /// <summary>
        /// Insert a single row into Country table
        /// </summary>
        /// <param name="ID">Country code from CallCodes.xls</param>
        /// <param name="name">Friendly country name</param>
        /// <returns></returns>
        public static bool insertCountry(long ID, string name) {
            int ret = 0;
            string sql = "INSERT INTO Country (ID, Name) VALUES (@ID,@Name)";
            SqlConnection connection = ConnectionManager.GetTMConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", name);
            
            try
            {
                ret = command.ExecuteNonQuery();
                if (connection != null) connection.Close();
                if (ret > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException e)
            {
                if (connection != null) connection.Close();
                return false;
            }
        }
        /// <summary>
        /// Reads the entire table in memory and returns it as sa DataSet
        /// </summary>
        /// <returns></returns>
        public static DataSet getAsDataset()
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = ConnectionManager.GetTMConnection())
            {
                string sql = "SELECT * FROM Country";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet, "Country");
            }
            return dataSet;

        }
    }//class
}