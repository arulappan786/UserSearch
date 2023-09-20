USE [UMS]
GO

DELETE FROM [dbo].[tbl_User] WHERE [UserId] = 105
GO

INSERT INTO [dbo].[tbl_User]
           ([UserId]
           ,[UserName]
           ,[Role]
           ,[LastLogin]
           ,[FName]
           ,[LName]
           ,[Department]
           ,[DOJ]
           ,[MgrId]
           ,[Seniority]
           ,[EmpCode])
     VALUES
           (105
           ,'Acc0185'
           ,'A/C Mgr'
           ,'2020-08-23 14:25:34'
           ,'Sanjay'
           ,'agarwal'
           ,'Accounts'
           ,'2018-05-20'
           ,78
           ,5.08
           ,'ACC0034')
GO

DELETE FROM [dbo].[tbl_User] WHERE [UserId] = 106
GO

INSERT INTO [dbo].[tbl_User]
           ([UserId]
           ,[UserName]
           ,[Role]
           ,[LastLogin]
           ,[FName]
           ,[LName]
           ,[Department]
           ,[DOJ]
           ,[MgrId]
           ,[Seniority]
           ,[EmpCode])
     VALUES
           (106
           ,'Acc0567'
           ,'Asst.'
           ,null
           ,'Amit'
           ,'Sharma'
           ,'Accounts'
           ,'2020-09-16'
           ,105
           ,8.15
           ,'ACC0598')
GO


DELETE FROM [dbo].[tbl_User] WHERE [UserId] = 428
GO

INSERT INTO [dbo].[tbl_User]
           ([UserId]
           ,[UserName]
           ,[Role]
           ,[LastLogin]
           ,[FName]
           ,[LName]
           ,[Department]
           ,[DOJ]
           ,[MgrId]
           ,[Seniority]
           ,[EmpCode])
     VALUES
           (428
           ,'Dev0476'
           ,'VP'
           ,'2020-09-19 10:45:12'
           ,'Lokesh'
           ,'Kumar'
           ,'Development'
           ,'2018-12-22'
           ,null
           ,1.05
           ,'DEV0833')
GO


DELETE FROM [dbo].[tbl_User] WHERE [UserId] = 568
GO

INSERT INTO [dbo].[tbl_User]
           ([UserId]
           ,[UserName]
           ,[Role]
           ,[LastLogin]
           ,[FName]
           ,[LName]
           ,[Department]
           ,[DOJ]
           ,[MgrId]
           ,[Seniority]
           ,[EmpCode])
     VALUES
           (568
           ,'ADM6633'
           ,'Exec'
           ,null
           ,'Naresh'
           ,null
           ,'Admin'
           ,'2011-06-06'
           ,70
           ,9.01
           ,'ADM0048')
GO


select * from [dbo].[tbl_User]
GO