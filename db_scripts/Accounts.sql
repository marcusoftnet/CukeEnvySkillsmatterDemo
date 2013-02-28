IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Accounts_Balance]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [DF_Accounts_Balance]
END

GO

/****** Object:  Table [dbo].[Accounts]    Script Date: 02/28/2013 19:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[Accounts]
GO


/****** Object:  Table [dbo].[Accounts]    Script Date: 02/28/2013 19:57:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Accounts](
	[Number] [varchar](100) NOT NULL,
	[Pin] [varchar](4) NOT NULL,
	[Balance] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_Balance]  DEFAULT ((0)) FOR [Balance]
GO


