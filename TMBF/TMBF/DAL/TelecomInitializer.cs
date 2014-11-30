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
            var tanzania = new Country { ID = 123, Name = "Tanzania" };
            context.Countries.Add(tanzania);
            var usa = new Country { ID = 1, Name = "USA" };
            context.Countries.Add(usa);
            var canada = new Country { ID = 2, Name = "Canada" };
            context.Countries.Add(canada);
            context.SaveChanges();

            var admin = new Admin { ID = 0, FirstName = "Admin", LastName = "Babu", Password = "admin", role = User.Role.Admin };
            context.Admins.Add(admin);
            context.SaveChanges();

            var service = new Service { ID = 1, SourceCountry = usa, DestinationCountry = canada, Name = "Spectra", OffPeekRate = 2.5, PeekRate = 5.0, RateEffectiveDate = DateTime.Parse("2014-12-14"), RateEndDate = DateTime.Parse("2015-1-12") };
            context.Services.Add(service);
            context.SaveChanges();

            var salesRep = new SalesRep { ID = 1, FirstName = "Dinesh", LastName = "Rahul", Password = "sales", role = User.Role.SalesRep };
            context.SalesReps.Add(salesRep);
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer{ID=6421234569,FirstName="John",LastName="Doe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234569", role = User.Role.Customer },
                new Customer{ID=6421234579,FirstName="Kohn",LastName="Eoe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234579", role = User.Role.Customer },
                new Customer{ID=6421234589,FirstName="Lohn",LastName="Foe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234589", role = User.Role.Customer },
                new Customer{ID=6421234599,FirstName="Mohn",LastName="Goe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234599", role = User.Role.Customer },
                new Customer{ID=6421234509,FirstName="Nohn",LastName="Hoe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234509", role = User.Role.Customer },
                new Customer{ID=7421234569,FirstName="John",LastName="Doe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234569", role = User.Role.Customer },
                new Customer{ID=7421234579,FirstName="Kohn",LastName="Eoe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234579", role = User.Role.Customer },
                new Customer{ID=7421234589,FirstName="Lohn",LastName="Foe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234589", role = User.Role.Customer },
                new Customer{ID=7421234599,FirstName="Mohn",LastName="Goe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234599", role = User.Role.Customer },
                new Customer{ID=7421234509,FirstName="Nohn",LastName="Hoe",CommisionForSalesRep=5,City="Fairfield",State="IA",StreetAddress="100N",ZipCode=123,ServiceID=1,SalesRepID=1,CountryID=123,PhoneNo="6421234509", role = User.Role.Customer }
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var calls = new List<Call>
            {
                new Call{CustomerID=6421234599,SourceCountry=tanzania,DestinationCountry=usa,ReceiverNo="7421234599",CallDate=DateTime.Parse("2010-10-10"),CallTime=2211,Duration=30},
                new Call{CustomerID=6421234599,SourceCountry=tanzania,DestinationCountry=usa,ReceiverNo="7421234599",CallDate=DateTime.Parse("2010-01-10"),CallTime=2211,Duration=30},
                new Call{CustomerID=6421234579,SourceCountry=tanzania,DestinationCountry=usa,ReceiverNo="7421234599",CallDate=DateTime.Parse("2010-11-10"),CallTime=2211,Duration=30},
                new Call{CustomerID=6421234579,SourceCountry=tanzania,DestinationCountry=usa,ReceiverNo="7421234599",CallDate=DateTime.Parse("2010-02-10"),CallTime=2211,Duration=30},
                new Call{CustomerID=6421234579,SourceCountry=tanzania,DestinationCountry=usa,ReceiverNo="7421234599",CallDate=DateTime.Parse("2010-12-10"),CallTime=2211,Duration=30}
            };
            calls.ForEach(c => context.Calls.Add(c));
            context.SaveChanges();


 
        }
    }
}