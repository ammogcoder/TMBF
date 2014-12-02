USE [TMBF]
GO

/****** Object:  StoredProcedure [dbo].[GetTraficSummary]    Script Date: 12/2/2014 2:09:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[GetTraficSummary]
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

