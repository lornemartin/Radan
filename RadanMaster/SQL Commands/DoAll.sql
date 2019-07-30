EXEC sp_MSForEachTable 'DISABLE TRIGGER ALL ON ?'
GO
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO
EXEC sp_MSForEachTable 'DELETE FROM ?'
GO
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
GO
EXEC sp_MSForEachTable 'ENABLE TRIGGER ALL ON ?'
GO

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (1, N'admin', N'please')
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (2, N'lorne', N'lorne')
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Privileges] ON
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (1, N'btnAllProduction', 1, 1)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (2, N'btnAddOperation', 1, 1)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (3, N'btnRemoveOperation', 1, 1)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (4, N'btnRecordOp', 1, 1)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (5, N'btnAllProduction', 1, 2)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (6, N'btnAddOperation', 0, 2)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (7, N'btnRemoveOperation', 0, 2)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (8, N'btnRecordOp', 1, 2)
INSERT INTO [dbo].[Privileges] ([ID], [buttonName], [HasAccess], [User_UserID]) VALUES (9, N'btnNesting', 1, 1)
SET IDENTITY_INSERT [dbo].[Privileges] OFF