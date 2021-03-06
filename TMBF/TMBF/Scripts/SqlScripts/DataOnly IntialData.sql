Print('Jai Guru Dev')

Delete from [dbo].[Call]
Delete from [dbo].[Service]
Delete from [dbo].[Customer]
Delete from [dbo].[Country]
Delete from [dbo].[SalesRep]
Delete from [dbo].[User]

USE [TMBF]
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (0, N'Admin', N'Admin', N'Babu', N'admin', 0)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (1, N'SalesRep', N'Dinesh', N'Rahul', N'SalesRep', 2)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234509, N'Customer', N'Nohn', N'Hoe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234569, N'Customer2', N'John', N'Doe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234579, N'Customer3', N'Kohn', N'Eoe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234589, N'Customer4', N'Lohn', N'Foe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (6421234599, N'Customer5', N'Mohn', N'Goe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234509, N'Customer6', N'Nohn', N'Hoe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234569, N'Customer7', N'John', N'Doe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234579, N'Customer8', N'Kohn', N'Eoe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234589, N'Customer9', N'Lohn', N'Foe', N'Customer', 1)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7421234599, N'Customer10', N'Mohn', N'Goe', N'Customer', 1)
INSERT [dbo].[SalesRep] ([ID], [Discriminator]) VALUES (1, N'SalesRep')
INSERT [dbo].[Country] ([ID], [Name]) VALUES (1, N'USA')
INSERT [dbo].[Country] ([ID], [Name]) VALUES (2, N'Canada')
INSERT [dbo].[Country] ([ID], [Name]) VALUES (123, N'Tanzania')
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ID], [Name], [PeekRate], [OffPeekRate], [RateEffectiveDate], [RateEndDate], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (1, N'Spectra', 5, 2.5, CAST(0x0000A40100000000 AS DateTime), CAST(0x0000A41E00000000 AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[Service] OFF
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234509, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234509', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234569, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234569', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234579, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234579', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234589, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234589', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (6421234599, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234599', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234509, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234509', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234569, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234569', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234579, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234579', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234589, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234589', 123, 1, 1)
INSERT [dbo].[Customer] ([ID], [StreetAddress], [City], [State], [ZipCode], [CommisionForSalesRep], [PhoneNo], [CountryID], [ServiceID], [SalesRepID]) VALUES (7421234599, N'100N', N'Fairfield', N'IA', 123, 5, N'6421234599', 123, 1, 1)
SET IDENTITY_INSERT [dbo].[Call] ON 

INSERT [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (1, CAST(0x00009E0B00000000 AS DateTime), 2211, 30, N'7421234599', 6421234599, 1, 123)
INSERT [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (2, CAST(0x00009CFA00000000 AS DateTime), 2211, 30, N'7421234599', 6421234599, 1, 123)
INSERT [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (3, CAST(0x00009E2A00000000 AS DateTime), 2211, 30, N'7421234599', 6421234579, 1, 123)
INSERT [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (4, CAST(0x00009D1900000000 AS DateTime), 2211, 30, N'7421234599', 6421234579, 1, 123)
INSERT [dbo].[Call] ([ID], [CallDate], [CallTime], [Duration], [ReceiverNo], [CustomerID], [DestinationCountry_ID], [SourceCountry_ID]) VALUES (5, CAST(0x00009E4800000000 AS DateTime), 2211, 30, N'7421234599', 6421234579, 1, 123)
SET IDENTITY_INSERT [dbo].[Call] OFF