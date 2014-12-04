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
        private static Boolean CheckToInsert(DateTime CallDate, double CallTime, double Duration, string ReceiverNo, double CustomerID, double SourceCountry_ID, double DestinationCountry_ID)
        {
            bool isOk = true;
            TelecomContext db = new TelecomContext();

            //check Customer exists
            Customer customer = db.Customers.Where(c => c.ID == CustomerID).FirstOrDefault();
            isOk = customer != null;
            if (isOk)
            {
                //check Call exists
                Call call = db.Calls.Where(c => c.CustomerID == CustomerID && c.ReceiverNo == ReceiverNo &&
                    c.CallDate == CallDate && c.CallTime == CallTime).FirstOrDefault();
                isOk = call == null;
            }

            return isOk;
        }
        public static Boolean insertCalls(DateTime CallDate, double CallTime, double Duration, string ReceiverNo, double CustomerID, double SourceCountry_ID, double DestinationCountry_ID)
        {
            //Check if CallExist, by tuandang
            if (!CheckToInsert(CallDate, CallTime, Duration, ReceiverNo, CustomerID, SourceCountry_ID, DestinationCountry_ID))
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