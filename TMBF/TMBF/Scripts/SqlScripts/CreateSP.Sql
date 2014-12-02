CREATE  PROCEDURE [dbo].GetCustomerBill
	@customerID bigint,
	@month int,
	@year int
AS	
SELECT CallDate, Concat(Concat(Cast((CallTime/100) as nvarchar),':'),Cast((CallTime%100) as nvarchar)) as TimeOfDay, 
       ReceiverNo as PhoneNo, Concat(Concat(Concat(Cast((Duration/60) as nvarchar),' min. '),Cast((Duration%60) as nvarchar)),' sec. ') as CallDuration,
	   (   (Duration/60)*
		   (SELECT  CASE 
						WHEN CallTime>=s.PeekRateStartTime AND CallTime<s.OffPeekRateStartTime THEN s.PeekRate 
						ELSE s.OffPeekRate
					END
					FROM Service s
					WHERE s.ID = (SELECT DISTINCT cust.ServiceID from Call c INNER JOIN Customer cust ON c.CustomerID=cust.ID)
					AND year(s.RateEffectiveDate)<=@year
					AND month(s.RateEffectiveDate)<=@month
					AND year(s.RateEndDate)>=@year
					AND month(s.RateEndDate)>=@month
					AND SourceCountry_ID=s.SourceCountry_ID
					AND DestinationCountry_ID=s.DestinationCountry_ID
			)
		)
		as cost	        
	   --Cast(0 as float) as Cost
		from Call	
		where CustomerID = @customerID AND 
			  year(CallDate) = @year AND 
			  month(CallDate) = @month
GO

CREATE  PROCEDURE [dbo].GetSalesRepCommission
	@salesRepID bigint,
	@month int,
	@year int
AS

SELECT Cast(0.56 as float) as Commission

GO

CREATE  PROCEDURE [dbo].GetAllSalesRepCommission
	@month int,
	@year int
AS

SELECT  'SP1' as SalesRep, Cast(0.56 as float) as Commission
