using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TMBF.Models;

namespace TMBF.DAL
{
    public class ReportDAL
    {
        public IList<ColDTO> GetCustomerBill(long customerID, int month, int year)
        {
            IList<ColDTO> list = null;
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
                    list = ctx.Database.SqlQuery<ColDTO>("exec GetCustomerBill @customerID, @month, @year ", pCustomerID, pMonth, pYear).ToList<ColDTO>();
                    //IList<Call> list2 = ctx.Database.SqlQuery<Call>("exec GetCustomerBill @customerID, @month, @year ", pCustomerID, pMonth, pYear).ToList<Call>();
                }       

            }
            return list;
        }
        public IList<Call> GetCustomerBill2(long customerID, int month, int year)
        {
            IList<Call> list = null;
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
                    list = ctx.Database.SqlQuery<Call>("exec GetCustomerBill @customerID, @month, @year ", pCustomerID, pMonth, pYear).ToList<Call>();
                    //IList<Call> list2 = ctx.Database.SqlQuery<Call>("exec GetCustomerBill @customerID, @month, @year ", pCustomerID, pMonth, pYear).ToList<Call>();

                    //Or can call SP by following way
                    //var courseList = ctx.Courses.SqlQuery("exec GetCoursesByStudentId @StudentId ", idParam).ToList<Course>();
                }

            }
            return list;
        }
    }
}