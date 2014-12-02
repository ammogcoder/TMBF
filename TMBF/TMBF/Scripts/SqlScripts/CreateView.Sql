CREATE VIEW CustomerBill
	AS 
	SELECT '' as PhoneNo, 0 as Length, Cast('2000/01/01' as DateTime) CallDate, '14:30' CallTime, Cast(0 as Float) as Cost

	Go
------------------
Create  VIEW SummarySalesRepCommision
	AS
	SELECT  'Mike Tyson' as SalesRepName, Cast(0.123456 as float) as Commission

GO
Create  View GetTrafficSummary
AS
SELECT  'Spectra' as ServiceName, 'VietNam' as  FromCountryName, 'Nepal' as ToCountryName, 12345 as Duration
