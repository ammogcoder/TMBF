using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TMBF.Models;

namespace TMBF.DAL
{
    public class TelecomInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<TelecomContext>
    {
        protected override void Seed(TelecomContext context)
        {
            var service = new Service { ID = 1, SourceCountry = 1, DestinationCountry = 2, Name = "Spectra", OffPeekRate = 2.5, PeekRate = 5.0, RateEffectiveDate = DateTime.Parse("2014-12-14"), RateEndDate = DateTime.Parse("2015-1-12") };
            context.Services.Add(service);
            
            context.SaveChanges();
            

            var salesRep = new SalesRep {ID=1,Name="Dinesh",Password="sales"};
            context.SalesReps.Add(salesRep);
            
            context.SaveChanges();
            
            
            var customers = new List<Customer>
            {
                new Customer{ID=6421234569,Name="Tuan",Password="Dang",Commision2Representative=5,City="Fairfield",Country=123,State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1},
                new Customer{ID=6421234579,Name="Uuan",Password="Dang",Commision2Representative=5,City="Fairfield",Country=123,State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1},
                new Customer{ID=6421234589,Name="Vuan",Password="Dang",Commision2Representative=5,City="Fairfield",Country=123,State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1},
                new Customer{ID=6421234599,Name="Wuan",Password="Dang",Commision2Representative=5,City="Fairfield",Country=123,State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1},
                new Customer{ID=6421234509,Name="Xuan",Password="Dang",Commision2Representative=5,City="Fairfield",Country=123,State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1}
            };
            customers.ForEach(c => context.Customers.Add(c));

            context.SaveChanges();
            
        }
    }
}