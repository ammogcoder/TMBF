DELETE FROM Call
DELETE FROM Customer
DELETE FROM Service
DELETE FROM Country


BULK INSERT Country
FROM 'C:\Calling_Codes.csv'
WITH
(
    FIRSTROW = 1,
    FIELDTERMINATOR = ',',  --CSV field delimiter
    ROWTERMINATOR = '\n',   --Use to shift the control to next row
    TABLOCK
)

INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role], [Discriminator]) VALUES (0, N'Admin', N'Nohn', N'Hoe', N'123', 0, N'(Undefined)')
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role], [Discriminator]) VALUES (6421234569, N'Customer', N'John', N'Doe', N'123', 1, N'(Undefined)')
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role], [Discriminator]) VALUES (1, N'SalesRep', N'Kohn', N'Eoe', N'123', 2, N'(Undefined)')
GO



/*Restore default customers*/
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234509, N'100N', N'Fairfield', N'IA', 1, 5, 1, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234569, N'100N', N'Fairfield', N'IA', 1, 5, 1, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234579, N'100N', N'Fairfield', N'IA', 1, 5, 1, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234589, N'100N', N'Fairfield', N'IA', 1, 5, 1, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234599, N'100N', N'Fairfield', N'IA', 1, 5, 1, 1, 1)

/*
/*Restore Default Calls */
SET IDENTITY_INSERT [dbo].[Call] ON
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (1, N'2010-10-10 00:00:00', 2211, N'00:00:30', 7421234599, 6421234599, 1, 123)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (2, N'2010-01-10 00:00:00', 2211, N'00:00:30', 7421234599, 6421234599, 1, 123)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (3, N'2010-11-10 00:00:00', 2211, N'00:00:30', 7421234599, 6421234579, 1, 123)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (4, N'2010-02-10 00:00:00', 2211, N'00:00:30', 7421234599, 6421234579, 1, 123)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (5, N'2010-12-10 00:00:00', 2211, N'00:00:30', 7421234599, 6421234579, 1, 123)
SET IDENTITY_INSERT [dbo].[Call] OFF
*/
