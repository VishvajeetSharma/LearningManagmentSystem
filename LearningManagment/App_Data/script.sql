USE [LMS]
GO
/****** Object:  Table [dbo].[tbl_assignment]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_assignment](
	[Sr] [int] IDENTITY(100,1) NOT NULL,
	[Batch] [int] NULL,
	[Subject] [varchar](100) NULL,
	[Title] [varchar](100) NULL,
	[Description] [text] NULL,
	[TaskFile] [varchar](100) NULL,
	[Teacher] [varchar](100) NULL,
	[LastDate] [date] NULL,
	[Date] [datetime] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_batch]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_batch](
	[Sr] [int] IDENTITY(1,1) NOT NULL,
	[Batch] [varchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_notes]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_notes](
	[Sr] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[Description] [text] NULL,
	[UploadedBy] [varchar](100) NULL,
	[NotesFile] [varchar](100) NULL,
	[Batch] [int] NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_student]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_student](
	[Name] [varchar](70) NOT NULL,
	[Mobile] [bigint] NULL,
	[EmailId] [varchar](50) NOT NULL,
	[Password] [varchar](30) NULL,
	[Course & Branch] [varchar](100) NULL,
	[Year] [varchar](50) NULL,
	[Picture] [varchar](70) NULL,
	[Batch] [int] NULL,
	[Status] [bit] NULL,
	[RegDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_submittedtask]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_submittedtask](
	[Sr] [int] IDENTITY(1,1) NOT NULL,
	[TaskNo] [int] NULL,
	[UserId] [varchar](50) NULL,
	[AnswerFile] [varchar](100) NULL,
	[Date] [datetime] NULL,
	[Marks] [int] NULL,
	[Remark] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_video]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_video](
	[Sr] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Batch] [int] NULL,
	[Cetegory] [int] NULL,
	[Description] [text] NULL,
	[Link] [varchar](100) NOT NULL,
	[ThumbNail] [varchar](100) NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_video_cetegory]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_video_cetegory](
	[Sr] [int] IDENTITY(1,1) NOT NULL,
	[CetegoryName] [varchar](100) NOT NULL,
	[ThumbNail] [varchar](100) NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl1_contact]    Script Date: 26-09-2024 17:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl1_contact](
	[Sr] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[MobileNumber] [bigint] NULL,
	[EmailId] [varchar](50) NULL,
	[Subject] [varchar](200) NULL,
	[Message] [text] NULL,
	[EnqDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_assignment] ON 

INSERT [dbo].[tbl_assignment] ([Sr], [Batch], [Subject], [Title], [Description], [TaskFile], [Teacher], [LastDate], [Date], [Status]) VALUES (109, 29, N'C#', N'ASP.Net Day1 Task ', N'Write a program in C# to calculate arithmetic operations..', N'csharp_dotnet_adnanreza_compressed.pdf', N'Divya Rai', CAST(N'2024-09-28' AS Date), CAST(N'2024-09-26T11:03:06.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_assignment] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_batch] ON 

INSERT [dbo].[tbl_batch] ([Sr], [Batch], [Status]) VALUES (29, N'ST2024', 1)
INSERT [dbo].[tbl_batch] ([Sr], [Batch], [Status]) VALUES (30, N'InternShips2024', 1)
INSERT [dbo].[tbl_batch] ([Sr], [Batch], [Status]) VALUES (31, N'Fresher2024', 1)
SET IDENTITY_INSERT [dbo].[tbl_batch] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_notes] ON 

INSERT [dbo].[tbl_notes] ([Sr], [Title], [Description], [UploadedBy], [NotesFile], [Batch], [Date]) VALUES (4, N'Introduction to C#', N'This presentation describes some
elementary features of .NET Framework and
C#. ', N'Divya Rai', N'csharp_dotnet_adnanreza_compressed.pdf', 29, CAST(N'2024-09-26T03:58:37.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_notes] OFF
GO
INSERT [dbo].[tbl_student] ([Name], [Mobile], [EmailId], [Password], [Course & Branch], [Year], [Picture], [Batch], [Status], [RegDate]) VALUES (N'Vishvajeet Sharma', 7237024533, N'v@gmail.com', N'123', N'DiplomaCS/IT', N'secondYear', N'myimg.jpg', 29, 1, CAST(N'2024-09-26T03:49:30.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tbl_submittedtask] ON 

INSERT [dbo].[tbl_submittedtask] ([Sr], [TaskNo], [UserId], [AnswerFile], [Date], [Marks], [Remark]) VALUES (2, 109, N'v@gmail.com', N'csharp_dotnet_adnanreza_compressed.pdf', CAST(N'2024-09-26T00:00:00.000' AS DateTime), 0, N'')
SET IDENTITY_INSERT [dbo].[tbl_submittedtask] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_video] ON 

INSERT [dbo].[tbl_video] ([Sr], [Title], [Batch], [Cetegory], [Description], [Link], [ThumbNail], [Date]) VALUES (6, N'Introduction to C#', 29, 16, N'C# tutorial for beginners in Hindi (Introduction)', N'https://www.youtube.com/embed/N8-uuKd5tyY?si=j7hU7UG8u4PvUnzA', N'c_cSharp.png', CAST(N'2024-09-26T03:46:04.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_video] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_video_cetegory] ON 

INSERT [dbo].[tbl_video_cetegory] ([Sr], [CetegoryName], [ThumbNail], [Date]) VALUES (16, N'ASP.Net', N'c_asp.png', CAST(N'2024-09-26T03:42:11.000' AS DateTime))
INSERT [dbo].[tbl_video_cetegory] ([Sr], [CetegoryName], [ThumbNail], [Date]) VALUES (17, N'ANDROID', N'c_android.png', CAST(N'2024-09-26T11:15:10.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_video_cetegory] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl1_contact] ON 

INSERT [dbo].[tbl1_contact] ([Sr], [Name], [MobileNumber], [EmailId], [Subject], [Message], [EnqDate]) VALUES (6, N'Shreyash Shrivashtav', 879653435764, N'shreyash@gmail.com', N'Courses', N'How to access your course?', CAST(N'2020-09-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl1_contact] OFF
GO
ALTER TABLE [dbo].[tbl_assignment]  WITH CHECK ADD FOREIGN KEY([Batch])
REFERENCES [dbo].[tbl_batch] ([Sr])
GO
ALTER TABLE [dbo].[tbl_notes]  WITH CHECK ADD FOREIGN KEY([Batch])
REFERENCES [dbo].[tbl_batch] ([Sr])
GO
ALTER TABLE [dbo].[tbl_student]  WITH CHECK ADD FOREIGN KEY([Batch])
REFERENCES [dbo].[tbl_batch] ([Sr])
GO
ALTER TABLE [dbo].[tbl_submittedtask]  WITH CHECK ADD FOREIGN KEY([TaskNo])
REFERENCES [dbo].[tbl_assignment] ([Sr])
GO
ALTER TABLE [dbo].[tbl_submittedtask]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[tbl_student] ([EmailId])
GO
ALTER TABLE [dbo].[tbl_video]  WITH CHECK ADD FOREIGN KEY([Batch])
REFERENCES [dbo].[tbl_batch] ([Sr])
GO
ALTER TABLE [dbo].[tbl_video]  WITH CHECK ADD FOREIGN KEY([Cetegory])
REFERENCES [dbo].[tbl_video_cetegory] ([Sr])
GO
