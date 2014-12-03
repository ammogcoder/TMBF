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

CREATE  PROCEDURE [dbo].GetCustomerBillTotal
	@customerID bigint,
	@month int,
	@year int,
	@total int out
AS	
		SET @total = ( SELECT SUM(tbl.cost) FROM
		(SELECT CUSTOMERID as aid, ((Duration/60)*
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
			from Call	
			where CustomerID = @customerID AND 
					year(CallDate) = @year AND 
					month(CallDate) = @month  )  as tbl 
			
			GROUP BY tbl.aid
					
			)

			RETURN @total

GO


CREATE  PROCEDURE [dbo].GetSalesRepCommission
	@salesRepID bigint,
	@month int,
	@year int,
	@totCommission int out
AS

	DECLARE @id bigint
	DECLARE @com_pc int
	DECLARE @totCost int
	DECLARE @runTot int
	  SET @totCost=0
	DECLARE @pass varchar(100)

	DECLARE cur CURSOR FOR SELECT c.ID, c.CommisionForSalesRep FROM Customer c 
	  WHERE c.SalesRepID = @salesRepID	
	    	  
	OPEN cur

	FETCH NEXT FROM cur INTO @id, @com_pc

	WHILE @@FETCH_STATUS = 0 
		BEGIN
			exec @runTot= GetCustomerBillTotal @id,@month,@year,0
			SET @totCost = @totCost+ @runTot * @com_pc
			FETCH NEXT FROM cur INTO @id, @com_pc
		END

	CLOSE cur    
	DEALLOCATE cur

	SET @totCommission=0.01 * @totCost

	RETURN @totCommission

GO


Create  PROCEDURE [dbo].GetSummarySalesRepCommission
	@month int,
	@year int
AS

SELECT  'Mike Tyson' as SalesRepName, Cast(0.123456 as float) as Commission
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
(select name from Country where ID=Call.DestinationCountry_ID) As 'ToCountryName' , SUM(Duration) As 'Duration'
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
