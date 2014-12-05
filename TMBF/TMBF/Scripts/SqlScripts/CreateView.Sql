CREATE VIEW CustomerBill
	AS 
	SELECT '' as PhoneNo, 0 as Length, Cast('2000/01/01' as DateTime) CallDate, '14:30' CallTime, Cast(0 as Float) as Cost

	Go
------------------
Create  VIEW SummarySalesRepCommision
	AS
	SELECT  'Mike Tyson' as SalesRepName, Cast(0.123456 as float) as Commission

GO
Create  View TrafficSummary
AS
SELECT  'Spectra' as ServiceName, 'VietNam' as  FromCountryName, 'Nepal' as ToCountryName, 12345 as Duration

GO
create  View Rate
AS
SELECT  1000 As CountryID, 'Brazin' as DestinationCountryName, Cast( 123.4567 as Float) as  PeekRate, Cast( 123.4567 as Float)  as OffPeekRate

