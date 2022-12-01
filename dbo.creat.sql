USE [Claims]
GO

/****** Object:  Table [dbo].[Create]    Script Date: 11/30/2022 3:57:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Create](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InsuredName] [varchar](50) NULL,
	[InsuredClaimNo] [varchar](50) NULL,
	[InsuredContactedDate] [date] NULL,
	[ClaimTypeCode] [varchar](50) NULL,
	[LossDescCode] [varchar](50) NULL,
	[InsurerID] [varchar](50) NULL,
	[Rate] [float] NULL,
	[Period] [float] NULL,
	[LossLocation] [varchar](50) NULL,
	[LossDate] [date] NULL,
	[ReceiveDate] [date] NULL,
	[OpenDate] [date] NULL,
	[CloseDate] [date] NULL,
	[PolicyInceptionDate] [date] NULL,
	[PolicyExpiryDate] [date] NULL,
	[Taxable] [float] NULL,
	[InsuredFirstName] [varchar](50) NULL,
	[OrganizationCode] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [date] NULL,
	[LastChangedBy] [varchar](50) NULL,
	[LastChanged] [varchar](50) NULL,
	[PolicyNumber] [varchar](50) NULL,
	[ClaimedAmount] [float] NULL,
	[BrokerID] [int] NULL,
	[AdjestorId] [int] NULL,
	[BrokerName] [varchar](50) NULL,
 CONSTRAINT [PK_Create] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


