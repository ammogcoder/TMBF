﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TMBF.Models;
using TMBF.Report;

namespace TMBF.DAL
{
    public class ReportDAL
    {
        public IList<CustomerBill> GetCustomerBill(long customerID, int month, int year)
        {
            IList<CustomerBill> list = null;
            using (TelecomContext context = new TelecomContext())
            {
                using (var ctx = new  TelecomContext())
                {
                    var pCustomerID = new SqlParameter
                    {
                        ParameterName = "customerID",
                        Value = customerID
                    };
                    var pMonth = new SqlParameter
                    {
                        ParameterName = "month",
                        Value = month
                    }; var pYear = new SqlParameter
                    {
                        ParameterName = "year",
                        Value = year
                    };
                    list = ctx.Database.SqlQuery<CustomerBill>("exec GetCustomerBill @customerID, @month, @year ", pCustomerID, pMonth, pYear).ToList<CustomerBill>();
                }       

            }
            return list;
        }

        public double GetSalesRepCommission(long salesRepID, int month, int year)
        {
            double  Commission = 0;
            using (TelecomContext context = new TelecomContext())
            {
                using (var ctx = new TelecomContext())
                {
                    var pSalesRepID = new SqlParameter
                    {
                        ParameterName = "salesRepID",
                        Value = salesRepID
                    };
                    var pMonth = new SqlParameter
                    {
                        ParameterName = "month",
                        Value = month
                    }; var pYear = new SqlParameter
                    {
                        ParameterName = "year",
                        Value = year
                    };
                    Commission= ctx.Database.SqlQuery<double>("exec GetSalesRepCommission @salesRepID, @month, @year ", pSalesRepID, pMonth, pYear).FirstOrDefault<double>();
                }

            }
            return Commission;
        }
      
    }
}