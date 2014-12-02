using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TMBF.Business
{
    public class ServicesDataAccess
    {
        /// <summary>
        /// sets ALL the records that end in the year 3015 to the supplied date
        /// </summary>
        /// <param name="endDate">endate for the records with time in the future</param>
        /// <returns></returns>
        public static Boolean capEndDate(DateTime RateEndDate)
        { 
        int ret = 0;
            
            string sql = "UPDATE Service SET RateEndDate = @RateEndDate WHERE year(RateEndDate) = 3015";
            SqlConnection connection = ConnectionManager.GetTMConnection();
            SqlCommand command = new SqlCommand(sql, connection);
                       
            command.Parameters.AddWithValue("@RateEndDate", RateEndDate);
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
        

        public static Boolean insertService(string name, float PeekRate, float OffPeekRate, DateTime RateEffectiveDate, DateTime RateEndDate, int SourceCountry_ID, int DestinationCountry_ID)
        {
            int ret = 0;
            string sql = "INSERT INTO Service (Name,PeekRate,OffPeekRate,RateEffectiveDate ,RateEndDate ,DestinationCountry_ID ,SourceCountry_ID) VALUES (@Name,@PeekRate,@OffPeekRate,@RateEffectiveDate ,@RateEndDate ,@DestinationCountry_ID ,@SourceCountry_ID )";
            SqlConnection connection = ConnectionManager.GetTMConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@ID", 0);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@PeekRate", PeekRate);
            command.Parameters.AddWithValue("@OffPeekRate", OffPeekRate);
            command.Parameters.AddWithValue("@RateEffectiveDate", RateEffectiveDate);
            command.Parameters.AddWithValue("@RateEndDate", RateEndDate);
            command.Parameters.AddWithValue("@DestinationCountry_ID", DestinationCountry_ID);
            command.Parameters.AddWithValue("@SourceCountry_ID", SourceCountry_ID);
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
        }//InsertService



        internal static bool insertServiceTable(System.Data.DataTable dt)
        {
            SqlConnection connection = ConnectionManager.GetTMConnection();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = "dbo.Service";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}