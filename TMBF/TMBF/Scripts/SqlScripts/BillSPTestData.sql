INSERT INTO [dbo].[Country] ([ID], [Name]) VALUES (1, N'USA')
INSERT INTO [dbo].[Country] ([ID], [Name]) VALUES (2, N'Canada')
INSERT INTO [dbo].[Country] ([ID], [Name]) VALUES (123, N'NotTanzania')
GO

INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (0, N'admin', N'Admin', N'Babu', N'admin', 0)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (1, N'sales', N'Dinesh', N'Rahul', N'sales', 2)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234509, NULL, N'Nohn', N'Hoe', NULL, 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234569, NULL, N'John', N'Doe', NULL, 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234579, N'usr1', N'Kohn', N'Eoe', N'customer1', 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234589, NULL, N'Lohn', N'Foe', NULL, 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234599, N'usr2', N'Mohn', N'Goe', N'customer2', 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234509, NULL, N'Nohn', N'Hoe', NULL, 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234569, NULL, N'John', N'Doe', NULL, 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234579, NULL, N'Kohn', N'Eoe', NULL, 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234589, NULL, N'Lohn', N'Foe', NULL, 1)
INSERT INTO [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234599, NULL, N'Mohn', N'Goe', NULL, 1)
GO

INSERT INTO [dbo].[SalesRep] ([ID], [Discriminator]) VALUES (0, N'Admin')
INSERT INTO [dbo].[SalesRep] ([ID], [Discriminator]) VALUES (1, N'SalesRep')
GO

SET IDENTITY_INSERT [dbo].[Service] ON
INSERT INTO [dbo].[Service] ([ID], [Name], [PeekRate], [OffPeekRate], [RateEffectiveDate], [RateEndDate], [PeekRateStartTime], [OffPeekRateStartTime], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (1, N'Spectra', 5, 2.5, N'2010-01-14 00:00:00', N'2010-12-12 00:00:00', 800, 1700, 2, 1)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO

INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234509, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234509', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234569, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234569', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234579, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234579', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234589, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234589', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234599, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234599', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234509, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234509', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234569, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234569', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234579, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234579', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234589, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234589', 123, 1, 1)
INSERT INTO [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234599, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234599', 123, 1, 1)
GO

SET IDENTITY_INSERT [dbo].[Call] ON
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (1, N'2010-10-10 00:00:00', 2211, 300, N'7421234599', 6421234599, 2, 1)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (2, N'2010-10-11 00:00:00', 1111, 300, N'7421234599', 6421234599, 2, 1)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (3, N'2010-10-10 00:00:00', 2211, 300, N'7421234599', 6421234579, 2, 1)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (4, N'2010-10-11 00:00:00', 1111, 300, N'7421234599', 6421234579, 2, 1)
INSERT INTO [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (5, N'2010-10-12 00:00:00', 2211, 300, N'7421234599', 6421234579, 2, 1)
SET IDENTITY_INSERT [dbo].[Call] OFF
GO