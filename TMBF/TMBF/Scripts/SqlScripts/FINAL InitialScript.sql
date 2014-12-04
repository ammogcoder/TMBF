Delete from [dbo].[__MigrationHistory]
Delete from [dbo].[Call]
Delete from [dbo].[Service]
Delete from [dbo].[Customer]
Delete from [dbo].[Country]
Delete from [dbo].[SalesRep]
Delete from [dbo].[Admin]
Delete from [dbo].[User]


USE [TMBF]


GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (0, N'admin', N'admin', N'admin', N'admin', 0)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (1, N'SalesRep', N'Nico', N'Nico', N'SalesRep', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (2, N'Salesrep2', N'sales', N'rep2', N'salesrep', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (12, N'salesrep12', N'salesrep12', N'salesrep12', N'salesrep12', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (14, N'salesrep14', N'salesrep14', N'salesrep14', N'salesrep14', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (15, N'salesrep15', N'salesrep15', N'salesrep15', N'salesrep15', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (17, N'salesrep17', N'salesrep17', N'salesrep17', N'salesrep17', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (18, N'salesrep18', N'salesrep18', N'salesrep18', N'salesrep18', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (19, N'salesrep19', N'salesrep19', N'salesrep19', N'salesrep19', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (22, N'salesrep22', N'salesrep22', N'salesrep22', N'salesrep22', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (23, N'salesrep23', N'salesrep23', N'salesrep23', N'salesrep23', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (24, N'salesrep24', N'salesrep24', N'salesrep24', N'salesrep24', 2)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (2129695507, N'cust3', N'Thomas', N'Tripp', N'cust3', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (2158144236, N'cust9', N'Mike  ', N'Tucker', N'cust9', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (3194932947, N'cust10', N'Conrad  ', N'Nolte', N'cust10', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (3442024502, N'cust13', N'Alfred  ', N'Kalmbach', N'cust13', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (3732023454, N'cust14', N'Anna  ', N'Stein', N'cust14', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (4012933377, N'cust5', N'Robert  ', N'McCracken', N'cust5', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (4154715025, N'cust4', N'Mary', N'Manning', N'cust4', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (4423401033, N'cust20', N'Adam  ', N'Smith', N'cust20', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (5573013399, N'cust11', N'Robert  ', N'Olden', N'cust11', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (5623401075, N'cust15', N'Emil  ', N'Aston', N'cust15', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (5921541145, N'cust16', N'Ewald  ', N'Reynolds', N'cust16', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7139375437, N'cust1', N'Randy ', N'Jones', N'cust1', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7206840649, N'cust8', N'William  ', N'Thurston', N'cust8', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7413134451, N'cust18', N'Rudolf  ', N'Torpini', N'cust18', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7739866739, N'cust7', N'Harold  ', N'Simpson', N'cust7', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7863858400, N'cust6', N'Dale  ', N'Malone', N'cust6', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (7923411130, N'cust19', N'Alberto  ', N'Russo', N'cust19', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (8606643148, N'cust2', N'David', N'Stephenson', N'cust2', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (8634204255, N'cust17', N'Helga  ', N'Stover', N'cust17', 1)
GO
INSERT [dbo].[User] ([ID], [UserName], [FirstName], [LastName], [Password], [role]) VALUES (9124429540, N'cust12', N'Theresa  ', N'Palm', N'cust12', 1)
GO
INSERT INTO [dbo].[Admin] ([ID]) VALUES (0)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (1 )
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (2 )
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (12)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (14)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (15)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (17)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (18)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (19)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (22)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (23)
GO
INSERT [dbo].[SalesRep] ([ID]) VALUES (24)
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (1, N'USA')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (7, N'Russia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (20, N'Egypt')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (27, N'South Africa')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (30, N'Greece ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (31, N'Netherlands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (32, N'Belgium')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (33, N'France')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (34, N'Spain')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (36, N'Hungary ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (39, N'Italy ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (40, N'Romania')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (41, N'Switzerland')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (43, N'Austria')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (44, N'United Kingdom')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (45, N'Denmark')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (46, N'Sweden')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (47, N'Norway ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (48, N'Poland')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (49, N'Germany')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (51, N'Peru')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (52, N'Mexico')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (53, N'Cuba')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (54, N'Argentina')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (55, N'Brazil ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (56, N'Chile ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (57, N'Colombia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (58, N'Venezuela')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (60, N'Malaysia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (61, N'Australia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (62, N'Indonesia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (63, N'Philippines')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (64, N'New Zealand')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (65, N'Singapore')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (66, N'Thailand')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (81, N'Japan ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (82, N'Korea (South)')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (84, N'Vietnam')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (86, N'China (PRC)')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (90, N'Turkey')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (91, N'India')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (92, N'Pakistan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (93, N'Afghanistan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (94, N'Sri Lanka')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (95, N'Myanmar')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (98, N'Iran')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (212, N'Morocco')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (213, N'Algeria')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (216, N'Tunisia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (218, N'Libya')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (220, N'Gambia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (221, N'Senegal ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (222, N'Mauritania')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (223, N'Mali Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (224, N'Guinea')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (225, N'Côte d''Ivoire (Ivory Coast)')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (226, N'Burkina Faso ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (227, N'Niger')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (228, N'Togolese Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (229, N'Benin')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (230, N'Mauritius')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (231, N'Liberia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (232, N'Sierra Leone')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (233, N'Ghana ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (234, N'Nigeria')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (235, N'Chad ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (236, N'Central African Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (237, N'Cameroon')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (238, N'Cape Verde Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (239, N'São Tomé and Principe')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (240, N'Equatorial Guinea')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (241, N'Gabonese Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (242, N'Congo')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (243, N'"Congo, Dem. Rep. of "')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (244, N'Angola ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (245, N'Guinea-Bissau ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (246, N'Diego Garcia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (247, N'Ascension')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (248, N'Seychelles Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (249, N'Sudan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (250, N'Rwandese Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (251, N'Ethiopia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (252, N'Somali Democratic Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (253, N'Djibouti')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (254, N'Kenya')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (255, N'Tanzania')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (256, N'Uganda')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (257, N'Burundi')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (258, N'Mozambique')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (260, N'Zambia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (261, N'Madagascar')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (262, N'Réunion Island')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (263, N'Zimbabwe ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (264, N'Namibia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (265, N'Malawi ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (266, N'Lesotho')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (267, N'Botswana ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (268, N'Swaziland')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (269, N'Comoros')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (290, N'St. Helena')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (291, N'Eritrea')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (297, N'Aruba')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (298, N'Faroe Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (299, N'Greenland ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (350, N'Gibraltar ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (351, N'Portugal')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (352, N'Luxembourg')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (353, N'Ireland')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (354, N'Iceland')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (355, N'Albania')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (356, N'Malta')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (357, N'Cyprus')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (358, N'Finland')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (359, N'Bulgaria')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (370, N'Lithuania ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (371, N'Latvia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (372, N'Estonia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (373, N'Moldova ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (374, N'Armenia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (375, N'Belarus')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (376, N'Andorra ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (377, N'Monaco')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (378, N'San Marino')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (379, N'Vatican City')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (380, N'Ukraine')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (381, N'Serbia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (382, N'Montenegro')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (385, N'Croatia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (386, N'Slovenia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (387, N'Bosnia & Herzegovina ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (389, N'Macedonia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (420, N'Czech Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (421, N'Slovak Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (423, N'Liechtenstein')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (500, N'Falkland Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (501, N'Belize')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (502, N'Guatemala ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (503, N'El Salvador')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (504, N'Honduras')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (505, N'Nicaragua')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (506, N'Costa Rica')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (507, N'Panama')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (508, N'St. Pierre & Miquelon')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (509, N'Haiti ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (590, N'Guadeloupe')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (591, N'Bolivia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (592, N'Guyana')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (593, N'Ecuador ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (594, N'French Guiana')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (595, N'Paraguay')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (596, N'Martinique')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (597, N'Suriname ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (598, N'Uruguay')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (599, N'Curaçao')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (670, N'East Timor')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (672, N'Antarctica')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (673, N'Brunei Darussalam')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (674, N'Nauru')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (675, N'Papua New Guinea')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (676, N'Tonga Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (677, N'Solomon Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (678, N'Vanuatu')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (679, N'Fiji Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (680, N'Palau')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (681, N'Wallis and Futuna Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (682, N'Cook Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (683, N'Niue')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (685, N'Samoa')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (686, N'Kiribati ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (687, N'New Caledonia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (688, N'Tuvalu')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (689, N'French Polynesia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (690, N'Tokelau')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (691, N'Micronesia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (692, N'Marshall Islands')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (808, N'Wake Island')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (850, N'Korea (North)')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (852, N'Hong Kong')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (853, N'Macao')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (855, N'Cambodia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (856, N'Laos')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (880, N'Bangladesh')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (886, N'Taiwan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (960, N'Maldives')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (961, N'Lebanon')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (962, N'Jordan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (963, N'Syria')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (964, N'Iraq')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (965, N'Kuwait ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (966, N'Saudi Arabia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (967, N'Yemen')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (968, N'Oman')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (971, N'United Arab Emirates')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (972, N'Israel ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (973, N'Bahrain')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (974, N'Qatar')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (975, N'Bhutan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (976, N'Mongolia ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (977, N'Nepal ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (992, N'Tajikistan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (993, N'Turkmenistan ')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (994, N'Azerbaijan')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (995, N'Georgia')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (996, N'Kyrgyz Republic')
GO
INSERT [dbo].[Country] ([ID], [Name]) VALUES (998, N'Uzbekistan')
GO
