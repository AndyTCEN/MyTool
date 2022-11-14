-------轉移資料---------
select * into [dbo].[sEmailList_Backup]  from [dbo].[sEmailList] order by varCategory
Go

-------清空原資料---------
Truncate table [sEmailList]
Go

---------新增Sid唯識別---------
ALTER TABLE [dbo].[sEmailList] ADD  sEmailList_Sid int IDENTITY(1,1);
Go


---------倒檔-----------------
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


-----------清除PK_sEmailList PK-------------

ALTER TABLE [dbo].[sEmailList]
DROP CONSTRAINT PK_sEmailList
GO


 -----------設定sid為PK-------------
ALTER TABLE [dbo].[sEmailList] Add CONSTRAINT [PK_sEmailList] PRIMARY KEY  (sEmailList_Sid) 
Go

---------修改varCategory欄位長度--------
ALTER TABLE [dbo].[sEmailList]
ALTER COLUMN [varCategory] varchar(3) NOT NULL
GO

-----------設定varCategory為FK-------------
ALTER TABLE [dbo].[sEmailList] Add CONSTRAINT FK_sEmailCategory FOREIGN KEY  (varCategory)
REFERENCES [dbo].[sEmailCategory]([varCategoryId])
Go


-----------清空備份-------------
Drop Table [dbo].[sEmailList_Backup]
Go
