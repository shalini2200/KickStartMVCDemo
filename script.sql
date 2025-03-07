USE [KickStartReactProject]
GO
/****** Object:  Table [dbo].[Child]    Script Date: 10/18/2018 12:42:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Child](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[ChildType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spAddChildren]    Script Date: 10/18/2018 12:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spAddChildren]  
@FirstName nvarchar(50),  
@LastName nvarchar(50),  
@Gender nvarchar (10),  
@Address nvarchar (50),  
@BirthDate DateTime,
@ChildType   nvarchar (50)  
as  
Begin  
Insert into Child (FirstName, LastName,Gender,Address,BirthDate,ChildType)  
Values (@FirstName,@LastName, @Gender, @Address, @BirthDate,@ChildType)  
End

GO
/****** Object:  StoredProcedure [dbo].[spDeleteChild]    Script Date: 10/18/2018 12:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteChild]
@Id int
as
Begin
 Delete from Child 
 where Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[spGetAllChildren]    Script Date: 10/18/2018 12:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllChildren]
as
Begin
 Select Id, FirstName, LastName,Gender,Address,BirthDate,ChildType
 from Child
End
GO
/****** Object:  StoredProcedure [dbo].[spSaveChildren]    Script Date: 10/18/2018 12:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spSaveChildren]     
@Id int,
@FirstName nvarchar(50),   
@Lastname nvarchar(50),   
@Gender nvarchar (10),      
@Address nvarchar (50),      
@BirthDate DateTime,
@ChildType nvarchar(50) 
as      
Begin      
 Update Child Set
 FirstName = @FirstName,
 Lastname=@LastName,
 Gender = @Gender,
 Address = @Address,
 BirthDate = @BirthDate,
 ChildType = @ChildType
 Where Id = @Id 
End 
GO
