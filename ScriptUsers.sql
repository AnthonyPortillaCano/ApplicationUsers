USE [BDCompany]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 3/03/2023 19:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Token] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [FirstName], [LastName], [UserName], [Password], [Token]) VALUES (1, N'Anthony Jesus', N'Portilla Cano', N'aportilla', N'MTIzNDVuZWsyMw==', NULL)
INSERT [dbo].[Usuario] ([Id], [FirstName], [LastName], [UserName], [Password], [Token]) VALUES (2, N'erick ', N'delgado', N'edelgado', N'UGEkJHcwcmQyMDE5', NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
