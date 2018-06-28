USE [CaCuocBongDa]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 06/28/2018 10:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](50) NULL,
	[Password] [nchar](200) NULL,
	[Email] [nchar](100) NULL,
	[FullName] [nvarchar](100) NULL,
	[IsActive] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdate] [datetime] NULL,
	[MoneyExchange] [money] NULL,
	[Deposits] [money] NULL,
	[Withdraw] [money] NULL,
	[DateDeposits] [datetime] NULL,
	[DateWithdraw] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON
INSERT [dbo].[TaiKhoan] ([ID], [UserName], [Password], [Email], [FullName], [IsActive], [DateCreated], [DateUpdate], [MoneyExchange], [Deposits], [Withdraw], [DateDeposits], [DateWithdraw]) VALUES (1, N'test                                              ', N'CC03E747A6AFBBCBF8BE7668ACFEBEE5                                                                                                                                                                        ', N'Trần Hoàng Anh                                                                                      ', N'tester@gmail.com', 1, CAST(0x0000A90C00F329B2 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
/****** Object:  StoredProcedure [dbo].[CaCuoc_InsertOrUpdate]    Script Date: 06/28/2018 10:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CaCuoc_InsertOrUpdate]
@InputValue	XML,
@Type INT -- 1: tao, 2: update,3: tien
AS
BEGIN
		SELECT [ID]					= ISNULL(x.o.value('@ID','INT'),0)
			  ,[UserName]				= x.o.value('@UserName','VARCHAR(50)')
			  ,[Password]			= x.o.value('@Password','VARCHAR(100)')
			  ,[Email]						= x.o.value('@Email','VARCHAR(100)') -- lay ten bai viet lam title
			  ,[FullName]           = x.o.value('@FullName','NVARCHAR(100)')
			  ,[MoneyExchange]				= x.o.value('@MoneyExchange','Money')
			  ,[Deposits]				= x.o.value('@Deposits','Money')
			  ,[Withdraw]					= x.o.value('@Withdraw','Money')
		INTO #TEMP
		FROM	@InputValue.nodes('/T') AS x(o)
		
		IF (@Type = 1)
		BEGIN
			INSERT INTO TaiKhoan(
					[UserName],
					[Password],
					[FullName],
					[Email],
					[IsActive],
					[DateCreated]
				)
			SELECT [UserName],
					[Password],
					[Email],
					[FullName],
					0,
					GETDATE()
			FROM #TEMP
			SELECT 1 AS RESULT
		END
		IF (@Type=2)
		BEGIN
			UPDATE A
			SET A.[Password] = T.[Password],
				A.[Email] = T.[Email],
				A.[FullName] = T.[FullName]
			FROM TaiKhoan A WITH (NOLOCK)
			JOIN #TEMP T ON A.ID = T.ID
			WHERE A.IsActive = 1
			
			SELECT 1 AS RESULT
		END
		
		DROP TABLE #TEMP
END
GO
/****** Object:  StoredProcedure [dbo].[CaCuoc_GetTaiKhoan]    Script Date: 06/28/2018 10:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CaCuoc_GetTaiKhoan]
@ID int,
@UserName VARCHAR(10),
@Type int-- 1: get all ,2: get Id, 3: get userName
AS
BEGIN
	IF(@Type=1)
	BEGIN
		SELECT * FROM TaiKhoan
		WHERE IsActive =1
	END
	IF(@Type=2)
	BEGIN 
		SELECT * FROM TaiKhoan Where ID = @ID
	END
	IF(@Type =3)
	BEGIN 
		SELECT * FROM TaiKhoan Where UserName= @UserName
	END
END
GO
