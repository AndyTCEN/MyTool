-------�ಾ���---------
select * into [dbo].[sEmailList_Backup]  from [dbo].[sEmailList] order by varCategory
Go

-------�M�ŭ���---------
Truncate table [sEmailList]
Go

---------�s�WSid���ѧO---------
ALTER TABLE [dbo].[sEmailList] ADD  sEmailList_Sid int IDENTITY(1,1);
Go


---------����-----------------
Insert into [sEmailList]
(
varCategory
      ,varEmail
      ,varEmpNo
      ,varName
      ,varModifyEmpNo
      ,dtModifyDate
    
)

select 
varCategory
,varEmail
,varEmpNo
,varName
,varModifyEmpNo
,dtModifyDate
 from [sEmailList_Backup];
 Go


-----------�M��PK_sEmailList PK-------------

ALTER TABLE [dbo].[sEmailList]
DROP CONSTRAINT PK_sEmailList
GO


 -----------�]�wsid��PK-------------
ALTER TABLE [dbo].[sEmailList] Add CONSTRAINT [PK_sEmailList] PRIMARY KEY  (sEmailList_Sid) 
Go

---------�ק�varCategory������--------
ALTER TABLE [dbo].[sEmailList]
ALTER COLUMN [varCategory] varchar(3) NOT NULL
GO

-----------�]�wvarCategory��FK-------------
ALTER TABLE [dbo].[sEmailList] Add CONSTRAINT FK_sEmailCategory FOREIGN KEY  (varCategory)
REFERENCES [dbo].[sEmailCategory]([varCategoryId])
Go


-----------�M�ųƥ�-------------
Drop Table [dbo].[sEmailList_Backup]
Go
