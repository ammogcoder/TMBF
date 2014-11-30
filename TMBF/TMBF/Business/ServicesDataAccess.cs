using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TMBF.Business
{
    public class ServicesDataAccess
    {
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
        }
    }
}