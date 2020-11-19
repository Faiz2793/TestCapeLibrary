USE [Library_Management_DB]
GO

/****** Object:  Table [dbo].[BookTransaction]    Script Date: 11/20/2020 4:29:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BookTransaction](
	[BookTransactionId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NULL,
	[UserId] [int] NULL,
	[PickedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


