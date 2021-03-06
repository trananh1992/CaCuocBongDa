USE [CaCuocBongDa]
GO
/****** Object:  Table [dbo].[TranDau]    Script Date: 06/29/2018 10:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TranDau](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MatchName] [varchar](50) NULL,
	[HomeName] [varchar](25) NULL,
	[HomeRate] [int] NULL,
	[AwayName] [varchar](25) NULL,
	[AwayRate] [int] NULL,
	[HandicapHome] [varchar](10) NULL,
	[HandicapAway] [varchar](10) NULL,
	[HandicapHomeRate] [int] NULL,
	[HandicapAwayRate] [int] NULL,
	[TimeMatch] [datetime] NULL,
	[FullTimeHome] [int] NULL,
	[FullTimeAway] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 06/29/2018 10:51:00 ******/
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
/****** Object:  StoredProcedure [dbo].[CaCuoc_InsertOrUpdateMatch]    Script Date: 06/29/2018 10:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CaCuoc_InsertOrUpdateMatch]
@InputValue xml,
@Type int=0 -- 1: tao ,2: update
AS
BEGIN
	SELECT   [ID]					= ISNULL(x.o.value('@ID','INT'),0)
			,[MatchName]			= x.o.value('@MatchName','VARCHAR(50)')
			,[HomeName]				= x.o.value('@HomeName','VARCHAR(25)')
			,[AwayName]				= x.o.value('@AwayName','VARCHAR(25)')
			,[HomeRate]				= x.o.value('@HomeRate','INT')
		    ,[AwayRate]				= x.o.value('@AwayRate','INT')
		    ,[HandicapHome]			= x.o.value('@HandicapHome','VARCHAR(10)')
		    ,[HandicapAway]			= x.o.value('@HandicapAway','VARCHAR(10)')
		    ,[HandicapHomeRate]		= x.o.value('@HandicapHomeRate','INT')
		    ,[HandicapAwayRate]		= x.o.value('@HandicapAwayRate','INT')
		    ,[TimeMatch]			= x.o.value('@TimeMatch','DATETIME')
		    ,[FullTimeHome]			= x.o.value('@FullTimeHome','INT')
		    ,[FullTimeAway]			= x.o.value('@FullTimeAway','INT')
		INTO #TEMP
		FROM	@InputValue.nodes('/T') AS x(o)
	
	IF @Type =1
	BEGIN 
		INSERT INTO TranDau(
			   [MatchName]
			  ,[HomeName]
			  ,[HomeRate]
			  ,[AwayName]
			  ,[AwayRate]
			  ,[HandicapHome]
			  ,[HandicapAway]
			  ,[HandicapHomeRate]
			  ,[HandicapAwayRate]
			  ,[TimeMatch]
			  ,[FullTimeHome]
			  ,[FullTimeAway]
		)
		SELECT [MatchName]
			  ,[HomeName]
			  ,[HomeRate]
			  ,[AwayName]
			  ,[AwayRate]
			  ,[HandicapHome]
			  ,[HandicapAway]
			  ,[HandicapHomeRate]
			  ,[HandicapAwayRate]
			  ,[TimeMatch]
			  ,[FullTimeHome]
			  ,[FullTimeAway]
		FROM #TEMP
		SELECT 1 AS RESULT, CAST(SCOPE_IDENTITY() AS INT) AS IdMatch
	END
	IF @Type=2
	BEGIN 
		UPDATE A
		SET		A.[MatchName]		= T.[MatchName]
			  ,A.[HomeName]			= T.[HomeName]
			  ,A.[HomeRate]			= T.[HomeRate]
			  ,A.[AwayName]			= T.[AwayName]
			  ,A.[AwayRate]			= T.[AwayRate]
			  ,A.[HandicapHome]		= T.[HandicapHome]
			  ,A.[HandicapAway]		= T.[HandicapAway]
			  ,A.[HandicapHomeRate]	= T.[HandicapHomeRate]
			  ,A.[HandicapAwayRate]	= T.[HandicapAwayRate]
			  ,A.[TimeMatch]		= T.[TimeMatch]
			  ,A.[FullTimeHome]		= T.[FullTimeHome]
			  ,A.[FullTimeAway]		= T.[FullTimeAway]
		FROM TranDau A WITH (NOLOCK)
		JOIN #TEMP T ON A.ID= T.ID
		Where A.TimeMatch <GETDATE()
		SELECT 1 AS RESULT
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CaCuoc_InsertOrUpdate]    Script Date: 06/29/2018 10:51:02 ******/
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
			  ,[Email]						= x.o.value('@Email','VARCHAR(100)')
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
/****** Object:  StoredProcedure [dbo].[CaCuoc_GetTaiKhoan]    Script Date: 06/29/2018 10:51:02 ******/
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
