USE [Claims]
GO

/****** Object:  Table [dbo].[LoginT]    Script Date: 11/30/2022 3:59:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LoginT](
	[FirstName] [nchar](100) NULL,
	[LastName] [nchar](100) NULL,
	[Age] [int] NULL,
	[Username] [nchar](20) NOT NULL,
	[Password] [nchar](20) NULL,
	[conformPassword] [nchar](20) NULL,
 CONSTRAINT [PK_LoginT] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


