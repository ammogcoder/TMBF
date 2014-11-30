CREATE  PROCEDURE [dbo].GetCustomerBill
	@customerID bigint,
	@month int,
	@year int
AS
	--phone number, length of call, time of call, cost of call
SELECT ReceiverNo as PhoneNo, Duration as Length, CallDate, Cast(CallTime as nvarchar), Cast(0 as float) as Cost
		from Call	
		where CustomerID = @customerID