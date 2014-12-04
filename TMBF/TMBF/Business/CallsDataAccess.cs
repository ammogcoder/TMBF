using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TMBF.DAL;
using TMBF.Models;

namespace TMBF.Business
{
    public class CallsDataAccess
    {
        //Check if CallExist, by tuandang
        private static Boolean CallExists(DateTime CallDate, double CallTime, double Duration, string ReceiverNo, double CustomerID, double SourceCountry_ID, double DestinationCountry_ID)
        {
            TelecomContext db = new TelecomContext();
            Call call = db.Calls.Where(c => c.CustomerID == CustomerID && c.ReceiverNo == ReceiverNo &&
                c.CallDate == CallDate && c.CallTime == CallTime).FirstOrDefault();
            return call != null;
        }
        internal static bool insertCallTable(System.Data.DataTable dt)
        {
            SqlConnection connection = ConnectionManager.GetTMConnection();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = "dbo.Call";

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

        public static Boolean insertCalls(DateTime CallDate, double CallTime, double Duration, string ReceiverNo, double CustomerID, double SourceCountry_ID, double DestinationCountry_ID)
        {
            //Check if CallExist, by tuandang
            if (CallExists(CallDate, CallTime, Duration, ReceiverNo, CustomerID, SourceCountry_ID,  DestinationCountry_ID))
                return true;
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