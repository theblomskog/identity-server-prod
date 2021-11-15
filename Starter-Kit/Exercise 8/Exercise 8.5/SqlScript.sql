/****** Object:  Table [dbo].[DataProtectionKeys_Client]    Script Date: 2020-10-11 09:44:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DataProtectionKeys_Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FriendlyName] [nvarchar](max) NULL,
	[Xml] [nvarchar](max) NULL,
 CONSTRAINT [PK_DataProtectionKeys_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[DataProtectionKeys_IdentityService](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FriendlyName] [nvarchar](max) NULL,
	[Xml] [nvarchar](max) NULL,
 CONSTRAINT [PK_DataProtectionKeys_IdentityService] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[DataProtectionKeys_PaymentAPI](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FriendlyName] [nvarchar](max) NULL,
	[Xml] [nvarchar](max) NULL,
 CONSTRAINT [PK_DataProtectionKeys_PaymentAPI] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO