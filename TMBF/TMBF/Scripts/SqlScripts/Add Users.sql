Delete from [dbo].[Customer] where [ID]=6421234569
Delete from [dbo].[Customer] where  [SalesRepID]=1
Delete from [dbo].[SalesRep] where [ID]=1
Delete from [dbo].[User] where [ID] in (1 , 6421234569 , 0)
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role], [Discriminator]) VALUES (0, N'Admin', N'Nohn', N'Hoe', N'123', 0, N'(Undefined)')
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role], [Discriminator]) VALUES (6421234569, N'Customer', N'John', N'Doe', N'123', 1, N'(Undefined)')
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role], [Discriminator]) VALUES (1, N'SalesRep', N'Kohn', N'Eoe', N'123', 2, N'(Undefined)')
GO