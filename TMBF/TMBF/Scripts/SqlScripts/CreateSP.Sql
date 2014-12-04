-- add Disc to SaleRep
-- delete key constrain with User in Admin

-- drop all SP
DROP PROCEDURE GetCustomerBill
Go
DROP PROCEDURE GetSalesRepCommission
Go
DROP PROCEDURE GetSummarySalesRepCommission
Go
DROP PROCEDURE GetTrafficSummary
Go
DROP PROCEDURE GetRate
Go

-- create new SP

CREATE  PROCEDURE [dbo].GetCustomerBill
	@customerID bigint,
	@month int,
	@year int
AS	
	--phone number, length of call, time of call, cost of call
SELECT ReceiverNo as PhoneNo, Ceiling( Cast(Duration as Float) /60) as Length, CallDate, 
	Cast( CallTime/100 as varchar) + ':' + Cast( CallTime%100 as varchar) as CallTime, 
	Ceiling( Cast(Duration as Float) /60) * (Case WHEN CallTime>=s.PeekRateStartTime AND CallTime<s.OffPeekRateStartTime THEN s.PeekRate 
				ELSE s.OffPeekRate End) as Cost
	from Call left join Service s on Call.SourceCountry_ID = s.SourceCountry_ID and Call.DestinationCountry_ID = s.DestinationCountry_ID
	where CustomerID = @customerID
		and Month(CallDate)= @month and Year(CallDate) = @year 

Go


CREATE PROCEDURE [dbo].GetSalesRepCommission
	@salesRepID bigint,
	@month int,
	@year int
AS
DECLARE @commission float
SET @commission = (Select Sum(	Duration * (Case WHEN CallTime>=s.PeekRateStartTime AND CallTime<s.OffPeekRateStartTime THEN s.PeekRate 
	ELSE s.OffPeekRate End)*c.CommisionForSalesRep /100)  as Commission
from Call inner join Customer c on Call.CustomerID = c.ID inner join SalesRep sr on sr.ID = c.SalesRepID inner join 
[User] u on sr.ID = u.ID inner join Service s on Call.SourceCountry_ID = s.SourceCountry_ID and Call.DestinationCountry_ID = s.DestinationCountry_ID
where sr.ID= @salesRepID 
	and Month(CallDate)= @month and Year(CallDate) = @year 
	and Month( s.RateEffectiveDate) = @month and Year(s.RateEffectiveDate) = @year 
	and CallDate >= s.RateEffectiveDate and CallDate <= s.RateEndDate )


if @commission is null
	Set @commission = 0
Select  @commission as Commission
GO



Create  PROCEDURE [dbo].GetSummarySalesRepCommission
	@month int,
	@year int
AS

--SELECT  'Mike Tyson' as SalesRepName, Cast(0.123456 as float) as Commission
Select u.FirstName + ' ' + u.LastName as SalesRepName, Sum(	Duration * (Case WHEN CallTime>=s.PeekRateStartTime AND CallTime<s.OffPeekRateStartTime THEN s.PeekRate 
	ELSE s.OffPeekRate End)*c.CommisionForSalesRep /100)  as Commission
from Call inner join Customer c on Call.CustomerID = c.ID inner join SalesRep sr on sr.ID = c.SalesRepID inner join 
[User] u on sr.ID = u.ID inner join Service s on Call.SourceCountry_ID = s.SourceCountry_ID and Call.DestinationCountry_ID = s.DestinationCountry_ID
where Month(CallDate)= @month and Year(CallDate) = @year 
	and Month( s.RateEffectiveDate) = @month and Year(s.RateEffectiveDate) = @year 
	and CallDate >= s.RateEffectiveDate and CallDate <= s.RateEndDate 
Group by  u.FirstName + ' ' + u.LastName
Go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[GetTrafficSummary]
 @month int,
 @year int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT Service.Name As 'ServiceName', (select name from Country where ID=Call.SourceCountry_ID) As 'FromCountryName', 
(select name from Country where ID=Call.DestinationCountry_ID) As 'ToCountryName' , SUM(Duration)/60 As 'Duration'
from [dbo].[Service] Inner Join [dbo].[Customer] ON Service.ID=ServiceID 
Inner Join [dbo].[Call] on Call.CustomerID=Customer.PhoneNo
where DATEDIFF(month,CallDate,DATEFROMPARTS (@year, @month, 1))<=0
Group By Call.SourceCountry_ID,Call.DestinationCountry_ID,Service.Name




END

GO


-- –service name–from country name –to country name –total minutes of calls
SELECT  'Spectra' as ServiceName, 'VietNam' as  FromCountryName, 'Nepal' as ToCountryName, 12345 as Duration

GO
CREATE  PROCEDURE [dbo].GetRate
	@serviceName nvarchar (MAX),
	@countryID bigint,
	@month int,
	@year int
AS
Print @serviceName
--SELECT  'Brazin' as DestinationCountryName, 0.123 as  PeekRate, 0.987 as OffPeekRate
SELECT Country.Name as DestinationCountryName, Service.PeekRate, Service.OffPeekRate FROM Country INNER JOIN Service On Country.ID = Service.DestinationCountry_ID  
WHERE month(Service.RateEffectiveDate) = @month AND year(Service.RateEffectiveDate) = @year 
and Service.SourceCountry_ID = @countryID and  Service.Name=  @serviceName

-- for commission

select Duration, c.CommisionForSalesRep, c.SalesRepID,
	Case WHEN CallTime>=s.PeekRateStartTime AND CallTime<s.OffPeekRateStartTime THEN s.PeekRate 
	ELSE s.OffPeekRate End as Rate,
	Duration * (Case WHEN CallTime>=s.PeekRateStartTime AND CallTime<s.OffPeekRateStartTime THEN s.PeekRate 
	ELSE s.OffPeekRate End)*c.CommisionForSalesRep /100  as Commission
from Call inner join Customer c on Call.CustomerID = c.ID 
inner join Service s on Call.SourceCountry_ID = s.SourceCountry_ID and Call.DestinationCountry_ID = s.DestinationCountry_ID
where Month(CallDate)= 12 and Year(CallDate) = 2013 and c.SalesRepID  = 1 
	and Month( s.RateEffectiveDate) = 12 and Year(s.RateEffectiveDate) = 2013 
	and CallDate >= s.RateEffectiveDate and CallDate <= s.RateEndDate

