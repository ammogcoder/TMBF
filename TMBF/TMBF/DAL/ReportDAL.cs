using System;
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
                using (var ctx = new TelecomContext())
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
            double Commission = 0;
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
                    Commission = ctx.Database.SqlQuery<double>("exec GetSalesRepCommission @salesRepID, @month, @year ", pSalesRepID, pMonth, pYear).FirstOrDefault<double>();
                }

            }
            return Commission;
        }
        public IList<SummarySalesRepCommision> GetSummarySalesRepCommission(int month, int year)
        {
            IList<SummarySalesRepCommision> list = null;
            using (TelecomContext context = new TelecomContext())
            {
                using (var ctx = new TelecomContext())
                {
                    var pMonth = new SqlParameter
                    {
                        ParameterName = "month",
                        Value = month
                    }; var pYear = new SqlParameter
                    {
                        ParameterName = "year",
                        Value = year
                    };
                    list = ctx.Database.SqlQuery<SummarySalesRepCommision>("exec GetSummarySalesRepCommission @month, @year ", pMonth, pYear).ToList();
                }

            }
            return list;
        }
        public IList<TrafficSummary> GetTrafficSummary(int month, int year)
        {
            IList<TrafficSummary> list = null;
            using (TelecomContext context = new TelecomContext())
            {
                using (var ctx = new TelecomContext())
                {
                    var pMonth = new SqlParameter
                    {
                        ParameterName = "month",
                        Value = month
                    }; var pYear = new SqlParameter
                    {
                        ParameterName = "year",
                        Value = year
                    };
                    list = ctx.Database.SqlQuery<TrafficSummary>("exec GetTrafficSummary @month, @year ", pMonth, pYear).ToList();
                }

            }
            return list;
        }
        public IList<Rate> GetRate(long serviceID, long sourceCountryID, int month, int year)
        {
            IList<Rate> list = null;
            using (TelecomContext context = new TelecomContext())
            {
                using (var ctx = new TelecomContext())
                {
                    var pServiceID = new SqlParameter
                    {
                        ParameterName = "serviceID",
                        Value = serviceID
                    };
                    var pSourceCountryID = new SqlParameter
                    {
                        ParameterName = "sourceCountryID",
                        Value = sourceCountryID
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
                    list = ctx.Database.SqlQuery<Rate>("exec GetRate @serviceID, @sourceCountryID, @month, @year ", pServiceID, pSourceCountryID, pMonth, pYear).ToList<Rate>();
                }

            }
            return list;
        }

    }
}