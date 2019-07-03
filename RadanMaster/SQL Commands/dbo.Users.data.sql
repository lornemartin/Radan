SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (1, N'admin', N'please')
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (2, N'lorne', N'lorne')
SET IDENTITY_INSERT [dbo].[Users] OFF
