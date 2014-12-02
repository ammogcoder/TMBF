using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TMBF.Business
{
    public class CallsDataAccess
    {
        public static Boolean insertCalls(DateTime CallDate, double CallTime, double Duration, string ReceiverNo, double CustomerID, double SourceCountry_ID, double DestinationCountry_ID)
        {
            int ret = 0;
            string sql = @"INSERT [Call] ([CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) 
VALUES (CAST(@CallDate AS DateTime), @CallTime, @Duration, @ReceiverNo, @CustomerID,@DestinationCountry_ID, @SourceCountry_ID)";

            SqlConnection connection = ConnectionManager.GetTMConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CallDate", CallDate);
            command.Parameters.AddWithValue("@CallTime", (int)CallTime);
            command.Parameters.AddWithValue("@Duration", (int)Duration);
            command.Parameters.AddWithValue("@ReceiverNo", ReceiverNo);
            command.Parameters.AddWithValue("@CustomerID", (long)CustomerID);
            command.Parameters.AddWithValue("@DestinationCountry_ID", (int)DestinationCountry_ID);
            command.Parameters.AddWithValue("@SourceCountry_ID", (int)SourceCountry_ID);
            try
            {
                ret = command.ExecuteNonQuery();
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                if (ret > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException e)
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                    return false;
            }
           
        }

    }
}