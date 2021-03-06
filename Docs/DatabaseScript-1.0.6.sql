USE [DB_9B0A01_motorbid3]
GO
/****** Object:  Table [dbo].[SellerCompanyLogos]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerCompanyLogos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ImageSizeID] [int] NULL,
	[OriginalFilename] [nvarchar](max) NOT NULL,
	[Filename] [nvarchar](max) NOT NULL,
	[FolderPath] [nvarchar](max) NOT NULL,
	[TempID] [nvarchar](max) NULL,
	[UploadedOn] [datetime] NULL,
 CONSTRAINT [PK_CompanyLogos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransmissionTypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransmissionTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsRemoved] [bit] NULL,
 CONSTRAINT [PK_TransmissionTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TransmissionTypes] ON
INSERT [dbo].[TransmissionTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (1, N'Automatic', NULL, NULL)
INSERT [dbo].[TransmissionTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (2, N'Manual', NULL, NULL)
INSERT [dbo].[TransmissionTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (3, N'Semi-Auto', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransmissionTypes] OFF
/****** Object:  Table [dbo].[SaleDates]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[VehicleSaleDate] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_SaleDates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SaleDates] ON
INSERT [dbo].[SaleDates] ([ID], [UserID], [Title], [VehicleSaleDate], [Description]) VALUES (1, 59, N'Operating System 14', CAST(0x0000A3C000000000 AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[SaleDates] OFF
/****** Object:  Table [dbo].[Models]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MakeID] [int] NULL,
	[Modelname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Models] ON
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (1, 142, N'Wagonar')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (2, 142, N'Swift-Desire')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (3, 154, N'NANO')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (4, 155, N'DC1000')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (5, 155, N'DC-1000')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (6, 156, N'MAASTRO')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (7, 138, N'JETTA 230')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (8, 8, N'ALFA 120')
INSERT [dbo].[Models] ([ID], [MakeID], [Modelname]) VALUES (9, 45, N'5 SERIES')
SET IDENTITY_INSERT [dbo].[Models] OFF
/****** Object:  Table [dbo].[MIMETypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MIMETypes](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[MIME] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_MIMETypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MIME Type ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MIMETypes', @level2type=N'COLUMN',@level2name=N'ID'
GO
SET IDENTITY_INSERT [dbo].[MIMETypes] ON
INSERT [dbo].[MIMETypes] ([ID], [MIME], [Description]) VALUES (0, N'.pdf', N'application/pdf')
INSERT [dbo].[MIMETypes] ([ID], [MIME], [Description]) VALUES (1, N'.doc', N'application/msword')
INSERT [dbo].[MIMETypes] ([ID], [MIME], [Description]) VALUES (2, N'.docx', N'application/vnd.openxmlformats-officedocument.wordprocessingml.document')
INSERT [dbo].[MIMETypes] ([ID], [MIME], [Description]) VALUES (3, N'.xls', N'application/vnd.ms-excel')
INSERT [dbo].[MIMETypes] ([ID], [MIME], [Description]) VALUES (4, N'.xlsx', N'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet')
SET IDENTITY_INSERT [dbo].[MIMETypes] OFF
/****** Object:  Table [dbo].[Makes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Makename] [nvarchar](50) NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Makes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Makes] ON
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (1, N'ACCURA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (2, N'ACRUA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (3, N'ACUR', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (4, N'ADION', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (5, N'ADVENTURE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (6, N'AEROS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (7, N'AGRIMONDO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (8, N'ALFA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (9, N'ALFA ROMEO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (10, N'ALJO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (11, N'ALLISON', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (12, N'ALPHA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (13, N'AMC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (14, N'AMERICAN MOTORS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (15, N'APACHE TRAILERS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (16, N'APOLLO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (17, N'APPIL', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (18, N'APRILIA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (19, N'ARCTIC CAT', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (20, N'ARGOS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (21, N'ARIENS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (22, N'AROS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (23, N'ARTIC CAT', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (24, N'ASCORT', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (25, N'ASCROT', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (26, N'ASTON MARTIN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (27, N'ATLAS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (28, N'ATTITUDE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (29, N'AUDI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (30, N'AUSTIN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (31, N'AUTI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (32, N'AZ-TEX TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (33, N'AZTEX', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (34, N'BAJA ZIFT', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (35, N'BASS TRACKER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (36, N'BASSO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (37, N'BAYLINER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (38, N'BENTLEY', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (39, N'BENZ', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (40, N'BICYCLE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (41, N'BIG DOG', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (42, N'BIG TEX', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (43, N'BIG TEX TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (44, N'BIG TOW TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (45, N'BMW', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (46, N'BMW 328I', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (47, N'BNW', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (48, N'BOUNDER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (49, N'BOURG DISTRIBUTING', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (50, N'BUELL', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (51, N'BUICK', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (52, N'BUICK CENTURY', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (53, N'BUIK', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (54, N'BUZZAROUND', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (55, N'BWM', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (56, N'CADDILAC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (57, N'CADELLAC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (58, N'CADI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (59, N'CADIALLAC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (60, N'CADIL', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (61, N'CADILAC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (62, N'CADILLA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (63, N'CADILLAC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (64, N'CADILLACE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (65, N'CADILLIAC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (66, N'CAL-TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (67, N'CALICO TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (68, N'CAM SUPERLINE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (69, N'CAMRY', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (70, N'CAN-AM', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (71, N'CARGO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (72, N'CAROLINA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (73, N'CARRIAGE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (74, N'CARRY ON TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (75, N'CARRY-ON TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (76, N'CARSO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (77, N'CARSON', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (78, N'CARSON TRAILER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (79, N'CEDILLAC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (80, N'CEHVROLET', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (81, N'CHYSLER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (82, N'DAEWO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (83, N'DAEWOO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (84, N'DAIHATSU', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (85, N'DAIHUTSU', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (86, N'DAMON', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (87, N'DASHUN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (88, N'DATSON', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (89, N'DATSUN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (90, N'DATZUN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (91, N'DAYWOO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (92, N'DDD', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (93, N'DEAWOO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (94, N'DEWOO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (95, N'DFGDGD', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (96, N'DIAWOO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (97, N'DIDGE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (98, N'DITCHWITCH', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (99, N'DODE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (100, N'DODG', 0)
GO
print 'Processed 100 total records'
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (101, N'DODGE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (102, N'DODGR', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (103, N'DODOGE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (104, N'DOGDE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (105, N'DOGE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (106, N'DOLPHIN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (107, N'DORSEY', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (108, N'DUCATI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (109, N'DURANGO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (110, N'DUTCHMAN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (111, N'DUTCHMEN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (112, N'E-TON', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (113, N'E350', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (114, N'EAGLE', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (115, N'F0RD', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (116, N'FERRARI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (117, N'FORD', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (118, N'GEEP', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (119, N'GEO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (120, N'GEORGIA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (121, N'GETTA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (122, N'GM MOTORS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (123, N'GRAND', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (124, N'GRAND NATIONAL', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (125, N'HONDA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (126, N'HONDAY', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (127, N'HONDIA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (128, N'HOOPER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (129, N'HUDAYI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (130, N'HUMMER', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (131, N'HUNDAI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (132, N'JAGUAR', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (133, N'JEEEP', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (134, N'JEEP', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (135, N'', 1)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (136, N'', 1)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (137, N'', 1)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (138, N'JETTA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (139, N'JIMMY', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (140, N'JMC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (141, N'LAMBORGHINI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (142, N'MARUTI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (143, N'MECEDES', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (144, N'MISTUBISHI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (145, N'MONARCH', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (146, N'NISSAN', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (147, N'OPEL', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (148, N'PIAGGIO', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (149, N'POLAR', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (150, N'SUSUKI', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (151, N'VOLKS', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (152, N'VOLKS WAGON', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (153, N'YAHAMA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (154, N'TATA', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (155, N'DC', 0)
INSERT [dbo].[Makes] ([ID], [Makename], [IsRemoved]) VALUES (156, N'HEROO', 0)
SET IDENTITY_INSERT [dbo].[Makes] OFF
/****** Object:  Table [dbo].[ImageSizes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageSizes](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_ImageSizes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ImageSizes] ON
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (0, N'Original', -1, -1, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (1, N'131x143', 131, 143, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (2, N'180x194', 180, 194, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (3, N'102x106', 102, 106, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (4, N'470x282', 470, 282, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (5, N'760x339', 760, 339, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (6, N'320x240', 320, 240, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (7, N'78x59', 78, 59, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (8, N'50x50', 50, 50, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (9, N'145x87', 145, 87, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (10, N'212x173', 212, 173, 0)
INSERT [dbo].[ImageSizes] ([ID], [Title], [Width], [Height], [IsRemoved]) VALUES (11, N'117x70', 117, 70, 0)
SET IDENTITY_INSERT [dbo].[ImageSizes] OFF
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'45e377d8-8deb-4567-ae04-976a94a179cc', N'Admin')
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201410200958479_InitialCreate', N'IdentitySample.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE4B8117D0F907F10F49404DE962F99C1C468EFC2DBB61323E30BA63D93BC196C89DD1646A2B412E5B511E4CBF2904FCA2FA4285117DE74E996BBDB8B0516D32279AA583C248BC5A2FFF79FFF4E7F7A0903EB1927A91F9133FB6872685B98B891E793D5999DD1E50F9FEC9F7EFCFDEFA6975EF8627D2BEB9DB07AD092A467F613A5F1A9E3A4EE130E513A097D3789D26849276E143AC88B9CE3C3C3BF3847470E06081BB02C6BFA2523D40F71FE037ECE22E2E2986628B8893C1CA4FC3B94CC7354EB1685388D918BCFEC6B0F435BFA3A47611CE049D1C0B6CE031F8132731C2C6D0B1112514441D5D3AF299ED32422AB790C1F50F0F01A63A8B744418A79174EEBEA7D7B7378CC7AE3D40D4B28374B69140E043C3AE1E671E4E66B19D9AECC0706BCCC8DC57A9D1BB1B6DF97280003C8024F6741C22A9FD9379588F334BEC57452369C14905709C0FD1A25DF274DC403AB77BB838A4EC79343F6DF8135CB029A25F88CE08C262838B0EEB345E0BB7FC7AF0FD1774CCE4E8E16CB934F1F3E22EFE4E39FF1C987664FA1AF504FF8009FEE9328C609E8869755FF6DCB11DB3972C3AA59A34D6115E012CC0CDBBA412F9F3159D1279833C79F6CEBCA7FC15EF98593EB2BF1612241239A64F0F3360B02B4087055EEB4CA64FF6F917AFCE1E328526FD1B3BFCA875E920F13278179F505077969FAE4C7C5F412C6FB9157BB4AA290FD16F955943ECEA32C7159672263950794AC3015B59B3A35797B519A418D4FEB1275FFA9CD3455E9ADADCA3AB4CE4C28456C7B3694FABEADDCDE8C3B8F6318BC9C5ACC226D84D3EE571309E0C0FA075E34BE3DDE7C9B7D80DF35918EFA128940077FCBEBE26588FC608485B18714704B967E12E2AA973F4740434406EB7C8FD214D605EF6F287D6A511DFE3982EA73EC6609231C05C6BDB9B4FBA788E0DB2C5CB059B03D59A30DCDC3AFD1157269945C12D66A63BCCF91FB3DCAE825F12E10C55FA95B02B29F0F7ED81F601475CE5D17A7E91590197BB308BCEE12F09AD093E3C1706CADDAB563320B901FEA3D1369557D2CABD6DE89BE86E2A118AAE9BC9436553F472B9FF453B5AC6A56B5A8D1A92AAF36545506D64F535ED3AC685EA153CFA2D6687E5F3E42E33B7E39ECFE7B7E9B6DDEA6B5A061C639AC90F8AF98E0049631EF1E518A13528F409F756317CE423E7C4CE89BEF4DB9A46F28C8C616B5D66CC81781F167430EBBFFB32157133E3FFB1EF34A7A1C87CACA00DFABBEFEA4D53DE724CDB63D1D846E6E5BF876D600D374394FD3C8F5F359A00984F13086A83FF87056774CA3E88D1C17818E01D17DB6E5C117E89B2D93EA8E5CE000536C9DBB45A07086521779AA19A143DE00C5CA1D55A3581D1F1195FB932213988E13D608B143500A33D527549D163E71FD18059D56925AF6DCC258DF2B1972C9058E3161023B2DD147B83E1CC214A8E44883D265A1A9D3605C3B110D5EAB69CCBB5CD87ADC9528C55638D9E13B1B78C9FDB7372166BBC5B640CE7693F451C018DADB0541F959A52F01E483CBBE11543A311908CA5DAAAD1054B4D80E082A9AE4DD11B438A2F61D7FE9BCBA6FF4140FCADBDFD65BCDB5036E0AF6D8336A16BE27B4A1D002272A3D2F16AC10BF50CDE10CF4E4E7B394BBBA3245F27B044CC5904DEDEF6AFD50A71D4426511B604DB40E507E29A80029136A8072652CAF553BEE450C802DE36EADB07CED97601B1C50B19B97A38D8AE62B54999CBD4E1F55CF2A362824EF755868E06808212F5E62C77B18C51497550DD3C7171EE20D373AC607A3C5401D9EABC148656746B75249CD6E2BE91CB2212ED9465692DC278395CACE8C6E25CED16E23699C82016EC1462612B7F091265B19E9A8769BAA6CEA146953FCC3D431E4574D6F501CFB64D5C8B7E25FAC79916C35FB613E3C05292C301C37D5642255DA56926894A015964A4134687AE52729BD40142D108BF3CCBC50A9A6DD5B0DCB7F29B2B97DAA8358EE03656DF66F716D17AFF285ED56F54738CC157432644E4D1E49D75040DFDC62297028408926783F8B822C24661FCBDCBAB8C26BB62FBEA8085347D25FF1A11483299EAE68FD5E63A3CE8BF1C6A9F262D61F2B3384C9E2A50FDAB4B9C92F35A39461AA268A2974B5B3B133B93343C74B7616870F5727C2DBCC2E9EA1D204E09F066234921C14B046597F54310FA5892996F44794924D9A9052D1002D9B29258292CD82B5F00C16D5D7E82F414D2269A2ABA5FD9135E9244D684DF11AD81A9DE5B2FEA89A8C9326B0A6B83F769D7E22AFA37BBC7F198F309B6C60C54177B31DCC80F1368BE2381B60E33EBF09D4F83C108BDFD82B60FCFB5E12CA78DADB845045886333421930CCEB8F70192E2E3FAD37F8664CE1865B58E2DB6EF8CD78C368FBA6E450CE7B72954A7A75EE93CE77537ED6EA7E64A31CBE8A2AB6559A11B6F7D794E270C22A4CE6BF04B3C0C76C312F2BDC20E22F714A8BAC0E1BCE869FA4473AFBF360C649532FD09C554DAF66C431DB428216794689FB8412355D6283472535A81289BE261E7E39B3FF95B73ACD831AEC5FF9E703EB3AFD4AFC5F32287848326CFD5B4DFF1C27C9BEFDB4B5A74F22FA5BF5FA9F8F45D303EB2E8119736A1D4AB65C6784C5871283B4299A6EA0CDDACF27DEEF84125E236851A509B1FEE383854F477978506AF98710BDFC71A86ADAC7051B216A1E108C85378A094D0F04D6C1323E0EF0E027CD1F070CEBACFEB1C03AAA191F0AF8643898FC4CA0FF3254B6DCE156A339166D6349CAEDDC9966BD51CEE5AEF726251B7BA389AE665C0F80DB20AB7A0D66BCB384E4D176474DBEF168D8BBA4F69B2719EF4B5E719DF1B1DB74E26D6610B7DC0FFDA61287F720D54D93BAB3FBF4E06D73CD14CADDF31CCB6149C07B46369ED0B5FB54DF6D93CD14E6DD73B20D4AE8DD33AEED6AFFDC31D37A6FA13B4FCF55338D0C5732BA587057FA6D11388713FE220212141E65F16A529FEF65125693C528B0AE62166A4E3493052B134791ABD468173BACAF7CC36FED2CAFD32ED6909ED9269BAFFFADB2799D76D986A4C75D240E6BD30E75C9DC1DEB585B36D47B4A14167AD29197DEE5B3B6DEAFBFA7BCE0518C22CC1EC31DF1FB49031EC524634E9D0169BFEA752FEC9D8DBFBC08FB77EAAF6A08F677180976855DB3AA734D9651B9794B1A9555A408CD0DA6C8832DF53CA1FE12B9148A598C397FF69DC7EDD84DC7027BD7E42EA37146A1CB385C0442C08B39016DF2F3DC6651E7E95D9CFF059331BA006AFA2C367F477ECEFCC0ABF4BED2C4840C10CCBBE0115D369694457657AF15D26D447A0271F3554ED1030EE300C0D23B3247CF781DDD807E9FF10AB9AF7504D004D23D10A2D9A7173E5A25284C3946DD1E7E0287BDF0E5C7FF03F18CFF9480540000, N'6.1.2-beta1-30916')
/****** Object:  Table [dbo].[BodyTypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BodyTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[IsRemoved] [bit] NULL,
 CONSTRAINT [PK_BodyTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BodyTypes] ON
INSERT [dbo].[BodyTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (1, N'Hatchback', NULL, NULL)
INSERT [dbo].[BodyTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (2, N'Liftbacks', NULL, NULL)
INSERT [dbo].[BodyTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (3, N'Minivans', NULL, NULL)
INSERT [dbo].[BodyTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (4, N'Sadan', NULL, NULL)
INSERT [dbo].[BodyTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (5, N'SUVs', NULL, NULL)
INSERT [dbo].[BodyTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (6, N'Saloon', NULL, NULL)
INSERT [dbo].[BodyTypes] ([ID], [Type], [Description], [IsRemoved]) VALUES (7, N'MPV', NULL, NULL)
SET IDENTITY_INSERT [dbo].[BodyTypes] OFF
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'00e4a9af-344c-4ab2-90ab-9babd7026d4f', N'Sameer@mail.com', 0, N'APtR18gmn1LPe2D4Hrkwf04oEoAk798LvCiuIMg8y5eMy4eXRTJNpBRDy6t+QgVYkA==', N'9a2ec969-44ea-4c7d-853a-7506631e282a', NULL, 0, 0, NULL, 0, 0, N'Sameer')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30b7bdc0-3509-4f43-8a9f-d44f5b24f7c0', N'AKhan@mail.com', 0, N'AAB6X7+yJYGZAS29zCJuIi+FA5pOBg7Uk+EbyTM+yqdRaQNeodESedgcjsk1ginIAw==', N'47d7f2cf-c253-4ac6-b49e-65c131e829b8', NULL, 0, 0, NULL, 0, 0, N'AKhan')
/****** Object:  Table [dbo].[FuelTypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_FuelTyps] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FuelTypes] ON
INSERT [dbo].[FuelTypes] ([ID], [Type], [Description]) VALUES (1, N'Petrol', NULL)
INSERT [dbo].[FuelTypes] ([ID], [Type], [Description]) VALUES (2, N'Diesel', NULL)
INSERT [dbo].[FuelTypes] ([ID], [Type], [Description]) VALUES (3, N'Bi-Fuel', NULL)
INSERT [dbo].[FuelTypes] ([ID], [Type], [Description]) VALUES (4, N'LPG', NULL)
SET IDENTITY_INSERT [dbo].[FuelTypes] OFF
/****** Object:  Table [dbo].[Countries]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](max) NULL,
	[DisplayName] [nvarchar](max) NULL,
	[FormalName] [varchar](max) NULL,
	[Type] [varchar](max) NULL,
	[SubType] [varchar](max) NULL,
	[Sovereignty] [varchar](max) NULL,
	[Capital] [varchar](max) NULL,
	[ISO_4217_Currency_Code] [varchar](max) NULL,
	[ISO_4217_Currency_Name] [varchar](max) NULL,
	[ITU_T_Telephone_Code] [varchar](max) NULL,
	[ISO_3166_1_2Letter_Code] [varchar](max) NULL,
	[ISO_3166_1_3Letter_Code] [varchar](max) NULL,
	[ISO_3166_1Number] [varchar](max) NULL,
	[IANA_Country_Code_TLD] [varchar](max) NULL,
	[IsListed] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (1, N'Abkhazia', N'Abkhazia', N'Republic of Abkhazia', N'Proto Independent State', N'', N'', N'Sokhumi', N'RUB', N'Ruble', N'995', N'GE', N'GEO', N'268', N'.ge', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (2, N'Afghanistan', N'Afghanistan', N'Islamic State of Afghanistan', N'Independent State', N'', N'', N'Kabul', N'AFN', N'Afghani', N'93', N'AF', N'AFG', N'4', N'.af', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (3, N'Aland', N'Aland', N'', N'Proto Dependency', N'', N'Finland', N'Mariehamn', N'EUR', N'Euro', N'340', N'AX', N'ALA', N'248', N'.ax', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (4, N'Albania', N'Albania', N'Republic of Albania', N'Independent State', N'', N'', N'Tirana', N'ALL', N'Lek', N'355', N'AL', N'ALB', N'8', N'.al', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (5, N'Algeria', N'Algeria', N'People''s Democratic Republic of Algeria', N'Independent State', N'', N'', N'Algiers', N'DZD', N'Dinar', N'213', N'DZ', N'DZA', N'12', N'.dz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (6, N'American Samoa', N'American Samoa', N'Territory of American Samoa', N'Dependency', N'Territory', N'United States', N'Pago Pago', N'USD', N'Dollar', N'-683', N'AS', N'ASM', N'16', N'.as', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (7, N'Andorra', N'Andorra', N'Principality of Andorra', N'Independent State', N'', N'', N'Andorra la Vella', N'EUR', N'Euro', N'376', N'AD', N'AND', N'20', N'.ad', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (8, N'Angola', N'Angola', N'Republic of Angola', N'Independent State', N'', N'', N'Luanda', N'AOA', N'Kwanza', N'244', N'AO', N'AGO', N'24', N'.ao', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (9, N'Anguilla', N'Anguilla', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'The Valley', N'XCD', N'Dollar', N'-263', N'AI', N'AIA', N'660', N'.ai', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (10, N'Antarctica', N'Antarctica', N'', N'Disputed Territory', N'', N'Undetermined', N'', N'', N'', N'', N'AQ', N'ATA', N'10', N'.aq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (11, N'Antigua and Barbuda', N'Antigua and Barbuda', N'', N'Independent State', N'', N'', N'Saint John''s', N'XCD', N'Dollar', N'-267', N'AG', N'ATG', N'28', N'.ag', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (12, N'Argentina', N'Argentina', N'Argentine Republic', N'Independent State', N'', N'', N'Buenos Aires', N'ARS', N'Peso', N'54', N'AR', N'ARG', N'32', N'.ar', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (13, N'Armenia', N'Armenia', N'Republic of Armenia', N'Independent State', N'', N'', N'Yerevan', N'AMD', N'Dram', N'374', N'AM', N'ARM', N'51', N'.am', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (14, N'Aruba', N'Aruba', N'', N'Proto Dependency', N'', N'Netherlands', N'Oranjestad', N'AWG', N'Guilder', N'297', N'AW', N'ABW', N'533', N'.aw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (15, N'Ascension', N'Ascension', N'', N'Proto Dependency', N'Dependency of Saint Helena', N'United Kingdom', N'Georgetown', N'SHP', N'Pound', N'247', N'AC', N'ASC', N'', N'.ac', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (16, N'Ashmore and Cartier Islands', N'Ashmore and Cartier Islands', N'Territory of Ashmore and Cartier Islands', N'Dependency', N'External Territory', N'Australia', N'', N'', N'', N'', N'AU', N'AUS', N'36', N'.au', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (17, N'Australia', N'Australia', N'Commonwealth of Australia', N'Independent State', N'', N'', N'Canberra', N'AUD', N'Dollar', N'61', N'AU', N'AUS', N'36', N'.au', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (18, N'Australian Antarctic Territory', N'Australian Antarctic Territory', N'', N'Antarctic Territory', N'External Territory', N'Australia', N'', N'', N'', N'', N'AQ', N'ATA', N'10', N'.aq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (19, N'Austria', N'Austria', N'Republic of Austria', N'Independent State', N'', N'', N'Vienna', N'EUR', N'Euro', N'43', N'AT', N'AUT', N'40', N'.at', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (20, N'Azerbaijan', N'Azerbaijan', N'Republic of Azerbaijan', N'Independent State', N'', N'', N'Baku', N'AZN', N'Manat', N'994', N'AZ', N'AZE', N'31', N'.az', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (21, N'Bahamas, The', N'Bahamas, The', N'Commonwealth of The Bahamas', N'Independent State', N'', N'', N'Nassau', N'BSD', N'Dollar', N'-241', N'BS', N'BHS', N'44', N'.bs', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (22, N'Bahrain', N'Bahrain', N'Kingdom of Bahrain', N'Independent State', N'', N'', N'Manama', N'BHD', N'Dinar', N'973', N'BH', N'BHR', N'48', N'.bh', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (23, N'Baker Island', N'Baker Island', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (24, N'Bangladesh', N'Bangladesh', N'People''s Republic of Bangladesh', N'Independent State', N'', N'', N'Dhaka', N'BDT', N'Taka', N'880', N'BD', N'BGD', N'50', N'.bd', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (25, N'Barbados', N'Barbados', N'', N'Independent State', N'', N'', N'Bridgetown', N'BBD', N'Dollar', N'-245', N'BB', N'BRB', N'52', N'.bb', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (26, N'Belarus', N'Belarus', N'Republic of Belarus', N'Independent State', N'', N'', N'Minsk', N'BYR', N'Ruble', N'375', N'BY', N'BLR', N'112', N'.by', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (27, N'Belgium', N'Belgium', N'Kingdom of Belgium', N'Independent State', N'', N'', N'Brussels', N'EUR', N'Euro', N'32', N'BE', N'BEL', N'56', N'.be', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (28, N'Belize', N'Belize', N'', N'Independent State', N'', N'', N'Belmopan', N'BZD', N'Dollar', N'501', N'BZ', N'BLZ', N'84', N'.bz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (29, N'Benin', N'Benin', N'Republic of Benin', N'Independent State', N'', N'', N'Porto-Novo', N'XOF', N'Franc', N'229', N'BJ', N'BEN', N'204', N'.bj', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (30, N'Bermuda', N'Bermuda', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Hamilton', N'BMD', N'Dollar', N'-440', N'BM', N'BMU', N'60', N'.bm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (31, N'Bhutan', N'Bhutan', N'Kingdom of Bhutan', N'Independent State', N'', N'', N'Thimphu', N'BTN', N'Ngultrum', N'975', N'BT', N'BTN', N'64', N'.bt', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (32, N'Bolivia', N'Bolivia', N'Republic of Bolivia', N'Independent State', N'', N'', N'La Paz (administrative/legislative) and Sucre (judical)', N'BOB', N'Boliviano', N'591', N'BO', N'BOL', N'68', N'.bo', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (33, N'Bosnia and Herzegovina', N'Bosnia and Herzegovina', N'', N'Independent State', N'', N'', N'Sarajevo', N'BAM', N'Marka', N'387', N'BA', N'BIH', N'70', N'.ba', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (34, N'Botswana', N'Botswana', N'Republic of Botswana', N'Independent State', N'', N'', N'Gaborone', N'BWP', N'Pula', N'267', N'BW', N'BWA', N'72', N'.bw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (35, N'Bouvet Island', N'Bouvet Island', N'', N'Dependency', N'Territory', N'Norway', N'', N'', N'', N'', N'BV', N'BVT', N'74', N'.bv', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (36, N'Brazil', N'Brazil', N'Federative Republic of Brazil', N'Independent State', N'', N'', N'Brasilia', N'BRL', N'Real', N'55', N'BR', N'BRA', N'76', N'.br', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (37, N'British Antarctic Territory', N'British Antarctic Territory', N'', N'Antarctic Territory', N'Overseas Territory', N'United Kingdom', N'', N'', N'', N'', N'AQ', N'ATA', N'10', N'.aq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (38, N'British Indian Ocean Territory', N'British Indian Ocean Territory', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'', N'', N'', N'246', N'IO', N'IOT', N'86', N'.io', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (39, N'British Sovereign Base Areas', N'British Sovereign Base Areas', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Episkopi', N'CYP', N'Pound', N'357', N'', N'', N'', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (40, N'British Virgin Islands', N'British Virgin Islands', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Road Town', N'USD', N'Dollar', N'-283', N'VG', N'VGB', N'92', N'.vg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (41, N'Brunei', N'Brunei', N'Negara Brunei Darussalam', N'Independent State', N'', N'', N'Bandar Seri Begawan', N'BND', N'Dollar', N'673', N'BN', N'BRN', N'96', N'.bn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (42, N'Bulgaria', N'Bulgaria', N'Republic of Bulgaria', N'Independent State', N'', N'', N'Sofia', N'BGN', N'Lev', N'359', N'BG', N'BGR', N'100', N'.bg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (43, N'Burkina Faso', N'Burkina Faso', N'', N'Independent State', N'', N'', N'Ouagadougou', N'XOF', N'Franc', N'226', N'BF', N'BFA', N'854', N'.bf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (44, N'Burundi', N'Burundi', N'Republic of Burundi', N'Independent State', N'', N'', N'Bujumbura', N'BIF', N'Franc', N'257', N'BI', N'BDI', N'108', N'.bi', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (45, N'Cambodia', N'Cambodia', N'Kingdom of Cambodia', N'Independent State', N'', N'', N'Phnom Penh', N'KHR', N'Riels', N'855', N'KH', N'KHM', N'116', N'.kh', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (46, N'Cameroon', N'Cameroon', N'Republic of Cameroon', N'Independent State', N'', N'', N'Yaounde', N'XAF', N'Franc', N'237', N'CM', N'CMR', N'120', N'.cm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (47, N'Canada', N'Canada', N'', N'Independent State', N'', N'', N'Ottawa', N'CAD', N'Dollar', N'1', N'CA', N'CAN', N'124', N'.ca', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (48, N'Cape Verde', N'Cape Verde', N'Republic of Cape Verde', N'Independent State', N'', N'', N'Praia', N'CVE', N'Escudo', N'238', N'CV', N'CPV', N'132', N'.cv', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (49, N'Cayman Islands', N'Cayman Islands', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'George Town', N'KYD', N'Dollar', N'-344', N'KY', N'CYM', N'136', N'.ky', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (50, N'Central African Republic', N'Central African Republic', N'', N'Independent State', N'', N'', N'Bangui', N'XAF', N'Franc', N'236', N'CF', N'CAF', N'140', N'.cf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (51, N'Chad', N'Chad', N'Republic of Chad', N'Independent State', N'', N'', N'N''Djamena', N'XAF', N'Franc', N'235', N'TD', N'TCD', N'148', N'.td', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (52, N'Chile', N'Chile', N'Republic of Chile', N'Independent State', N'', N'', N'Santiago (administrative/judical) and Valparaiso (legislative)', N'CLP', N'Peso', N'56', N'CL', N'CHL', N'152', N'.cl', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (53, N'China, People''s Republic of', N'China, People''s Republic of', N'People''s Republic of China', N'Independent State', N'', N'', N'Beijing', N'CNY', N'Yuan Renminbi', N'86', N'CN', N'CHN', N'156', N'.cn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (54, N'China, Republic of (Taiwan)', N'China, Republic of (Taiwan)', N'Republic of China', N'Proto Independent State', N'', N'', N'Taipei', N'TWD', N'Dollar', N'886', N'TW', N'TWN', N'158', N'.tw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (55, N'Christmas Island', N'Christmas Island', N'Territory of Christmas Island', N'Dependency', N'External Territory', N'Australia', N'The Settlement (Flying Fish Cove)', N'AUD', N'Dollar', N'61', N'CX', N'CXR', N'162', N'.cx', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (56, N'Clipperton Island', N'Clipperton Island', N'', N'Dependency', N'Possession', N'France', N'', N'', N'', N'', N'PF', N'PYF', N'258', N'.pf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (57, N'Cocos (Keeling) Islands', N'Cocos (Keeling) Islands', N'Territory of Cocos (Keeling) Islands', N'Dependency', N'External Territory', N'Australia', N'West Island', N'AUD', N'Dollar', N'61', N'CC', N'CCK', N'166', N'.cc', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (58, N'Colombia', N'Colombia', N'Republic of Colombia', N'Independent State', N'', N'', N'Bogota', N'COP', N'Peso', N'57', N'CO', N'COL', N'170', N'.co', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (59, N'Comoros', N'Comoros', N'Union of Comoros', N'Independent State', N'', N'', N'Moroni', N'KMF', N'Franc', N'269', N'KM', N'COM', N'174', N'.km', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (60, N'Congo, Democratic Republic of the (Congo – Kinshasa)', N'Congo, Democratic Republic of the (Congo – Kinshasa)', N'Democratic Republic of the Congo', N'Independent State', N'', N'', N'Kinshasa', N'CDF', N'Franc', N'243', N'CD', N'COD', N'180', N'.cd', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (61, N'Congo, Republic of the (Congo – Brazzaville)', N'Congo, Republic of the (Congo – Brazzaville)', N'Republic of the Congo', N'Independent State', N'', N'', N'Brazzaville', N'XAF', N'Franc', N'242', N'CG', N'COG', N'178', N'.cg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (62, N'Cook Islands', N'Cook Islands', N'', N'Dependency', N'Self-Governing in Free Association', N'New Zealand', N'Avarua', N'NZD', N'Dollar', N'682', N'CK', N'COK', N'184', N'.ck', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (63, N'Coral Sea Islands', N'Coral Sea Islands', N'Coral Sea Islands Territory', N'Dependency', N'External Territory', N'Australia', N'', N'', N'', N'', N'AU', N'AUS', N'36', N'.au', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (64, N'Costa Rica', N'Costa Rica', N'Republic of Costa Rica', N'Independent State', N'', N'', N'San Jose', N'CRC', N'Colon', N'506', N'CR', N'CRI', N'188', N'.cr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (65, N'Cote d''Ivoire (Ivory Coast)', N'Cote d''Ivoire (Ivory Coast)', N'Republic of Cote d''Ivoire', N'Independent State', N'', N'', N'Yamoussoukro', N'XOF', N'Franc', N'225', N'CI', N'CIV', N'384', N'.ci', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (66, N'Croatia', N'Croatia', N'Republic of Croatia', N'Independent State', N'', N'', N'Zagreb', N'HRK', N'Kuna', N'385', N'HR', N'HRV', N'191', N'.hr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (67, N'Cuba', N'Cuba', N'Republic of Cuba', N'Independent State', N'', N'', N'Havana', N'CUP', N'Peso', N'53', N'CU', N'CUB', N'192', N'.cu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (68, N'Cyprus', N'Cyprus', N'Republic of Cyprus', N'Independent State', N'', N'', N'Nicosia', N'CYP', N'Pound', N'357', N'CY', N'CYP', N'196', N'.cy', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (69, N'Czech Republic', N'Czech Republic', N'', N'Independent State', N'', N'', N'Prague', N'CZK', N'Koruna', N'420', N'CZ', N'CZE', N'203', N'.cz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (70, N'Denmark', N'Denmark', N'Kingdom of Denmark', N'Independent State', N'', N'', N'Copenhagen', N'DKK', N'Krone', N'45', N'DK', N'DNK', N'208', N'.dk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (71, N'Djibouti', N'Djibouti', N'Republic of Djibouti', N'Independent State', N'', N'', N'Djibouti', N'DJF', N'Franc', N'253', N'DJ', N'DJI', N'262', N'.dj', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (72, N'Dominica', N'Dominica', N'Commonwealth of Dominica', N'Independent State', N'', N'', N'Roseau', N'XCD', N'Dollar', N'-766', N'DM', N'DMA', N'212', N'.dm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (73, N'Dominican Republic', N'Dominican Republic', N'', N'Independent State', N'', N'', N'Santo Domingo', N'DOP', N'Peso', N'+1-809 and 1-829', N'DO', N'DOM', N'214', N'.do', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (74, N'Ecuador', N'Ecuador', N'Republic of Ecuador', N'Independent State', N'', N'', N'Quito', N'USD', N'Dollar', N'593', N'EC', N'ECU', N'218', N'.ec', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (75, N'Egypt', N'Egypt', N'Arab Republic of Egypt', N'Independent State', N'', N'', N'Cairo', N'EGP', N'Pound', N'20', N'EG', N'EGY', N'818', N'.eg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (76, N'El Salvador', N'El Salvador', N'Republic of El Salvador', N'Independent State', N'', N'', N'San Salvador', N'USD', N'Dollar', N'503', N'SV', N'SLV', N'222', N'.sv', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (77, N'Equatorial Guinea', N'Equatorial Guinea', N'Republic of Equatorial Guinea', N'Independent State', N'', N'', N'Malabo', N'XAF', N'Franc', N'240', N'GQ', N'GNQ', N'226', N'.gq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (78, N'Eritrea', N'Eritrea', N'State of Eritrea', N'Independent State', N'', N'', N'Asmara', N'ERN', N'Nakfa', N'291', N'ER', N'ERI', N'232', N'.er', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (79, N'Estonia', N'Estonia', N'Republic of Estonia', N'Independent State', N'', N'', N'Tallinn', N'EEK', N'Kroon', N'372', N'EE', N'EST', N'233', N'.ee', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (80, N'Ethiopia', N'Ethiopia', N'Federal Democratic Republic of Ethiopia', N'Independent State', N'', N'', N'Addis Ababa', N'ETB', N'Birr', N'251', N'ET', N'ETH', N'231', N'.et', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (81, N'Falkland Islands (Islas Malvinas)', N'Falkland Islands (Islas Malvinas)', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Stanley', N'FKP', N'Pound', N'500', N'FK', N'FLK', N'238', N'.fk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (82, N'Faroe Islands', N'Faroe Islands', N'', N'Proto Dependency', N'', N'Denmark', N'Torshavn', N'DKK', N'Krone', N'298', N'FO', N'FRO', N'234', N'.fo', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (83, N'Fiji', N'Fiji', N'Republic of the Fiji Islands', N'Independent State', N'', N'', N'Suva', N'FJD', N'Dollar', N'679', N'FJ', N'FJI', N'242', N'.fj', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (84, N'Finland', N'Finland', N'Republic of Finland', N'Independent State', N'', N'', N'Helsinki', N'EUR', N'Euro', N'358', N'FI', N'FIN', N'246', N'.fi', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (85, N'France', N'France', N'French Republic', N'Independent State', N'', N'', N'Paris', N'EUR', N'Euro', N'33', N'FR', N'FRA', N'250', N'.fr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (86, N'French Guiana', N'French Guiana', N'Overseas Region of Guiana', N'Proto Dependency', N'Overseas Region', N'France', N'Cayenne', N'EUR', N'Euro', N'594', N'GF', N'GUF', N'254', N'.gf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (87, N'French Polynesia', N'French Polynesia', N'Overseas Country of French Polynesia', N'Dependency', N'Overseas Collectivity', N'France', N'Papeete', N'XPF', N'Franc', N'689', N'PF', N'PYF', N'258', N'.pf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (88, N'French Southern and Antarctic Lands', N'French Southern and Antarctic Lands', N'Territory of the French Southern and Antarctic Lands', N'Dependency', N'Overseas Territory', N'France', N'Martin-de-Viviès', N'', N'', N'', N'TF', N'ATF', N'260', N'.tf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (89, N'Gabon', N'Gabon', N'Gabonese Republic', N'Independent State', N'', N'', N'Libreville', N'XAF', N'Franc', N'241', N'GA', N'GAB', N'266', N'.ga', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (90, N'Gambia, The', N'Gambia, The', N'Republic of The Gambia', N'Independent State', N'', N'', N'Banjul', N'GMD', N'Dalasi', N'220', N'GM', N'GMB', N'270', N'.gm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (91, N'Georgia', N'Georgia', N'Republic of Georgia', N'Independent State', N'', N'', N'Tbilisi', N'GEL', N'Lari', N'995', N'GE', N'GEO', N'268', N'.ge', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (92, N'Germany', N'Germany', N'Federal Republic of Germany', N'Independent State', N'', N'', N'Berlin', N'EUR', N'Euro', N'49', N'DE', N'DEU', N'276', N'.de', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (93, N'Ghana', N'Ghana', N'Republic of Ghana', N'Independent State', N'', N'', N'Accra', N'GHS', N'Cedi', N'233', N'GH', N'GHA', N'288', N'.gh', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (94, N'Gibraltar', N'Gibraltar', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Gibraltar', N'GIP', N'Pound', N'350', N'GI', N'GIB', N'292', N'.gi', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (95, N'Greece', N'Greece', N'Hellenic Republic', N'Independent State', N'', N'', N'Athens', N'EUR', N'Euro', N'30', N'GR', N'GRC', N'300', N'.gr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (96, N'Greenland', N'Greenland', N'', N'Proto Dependency', N'', N'Denmark', N'Nuuk (Godthab)', N'DKK', N'Krone', N'299', N'GL', N'GRL', N'304', N'.gl', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (97, N'Grenada', N'Grenada', N'', N'Independent State', N'', N'', N'Saint George''s', N'XCD', N'Dollar', N'-472', N'GD', N'GRD', N'308', N'.gd', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (98, N'Guadeloupe', N'Guadeloupe', N'Overseas Region of Guadeloupe', N'Proto Dependency', N'Overseas Region', N'France', N'Basse-Terre', N'EUR', N'Euro', N'590', N'GP', N'GLP', N'312', N'.gp', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (99, N'Guam', N'Guam', N'Territory of Guam', N'Dependency', N'Territory', N'United States', N'Hagatna', N'USD', N'Dollar', N'-670', N'GU', N'GUM', N'316', N'.gu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (100, N'Guatemala', N'Guatemala', N'Republic of Guatemala', N'Independent State', N'', N'', N'Guatemala', N'GTQ', N'Quetzal', N'502', N'GT', N'GTM', N'320', N'.gt', 1)
GO
print 'Processed 100 total records'
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (101, N'Guernsey', N'Guernsey', N'Bailiwick of Guernsey', N'Dependency', N'Crown Dependency', N'United Kingdom', N'Saint Peter Port', N'GGP', N'Pound', N'44', N'GG', N'GGY', N'831', N'.gg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (102, N'Guinea', N'Guinea', N'Republic of Guinea', N'Independent State', N'', N'', N'Conakry', N'GNF', N'Franc', N'224', N'GN', N'GIN', N'324', N'.gn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (103, N'Guinea-Bissau', N'Guinea-Bissau', N'Republic of Guinea-Bissau', N'Independent State', N'', N'', N'Bissau', N'XOF', N'Franc', N'245', N'GW', N'GNB', N'624', N'.gw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (104, N'Guyana', N'Guyana', N'Co-operative Republic of Guyana', N'Independent State', N'', N'', N'Georgetown', N'GYD', N'Dollar', N'592', N'GY', N'GUY', N'328', N'.gy', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (105, N'Haiti', N'Haiti', N'Republic of Haiti', N'Independent State', N'', N'', N'Port-au-Prince', N'HTG', N'Gourde', N'509', N'HT', N'HTI', N'332', N'.ht', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (106, N'Heard Island and McDonald Islands', N'Heard Island and McDonald Islands', N'Territory of Heard Island and McDonald Islands', N'Dependency', N'External Territory', N'Australia', N'', N'', N'', N'', N'HM', N'HMD', N'334', N'.hm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (107, N'Honduras', N'Honduras', N'Republic of Honduras', N'Independent State', N'', N'', N'Tegucigalpa', N'HNL', N'Lempira', N'504', N'HN', N'HND', N'340', N'.hn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (108, N'Hong Kong', N'Hong Kong', N'Hong Kong Special Administrative Region', N'Proto Dependency', N'Special Administrative Region', N'China', N'', N'HKD', N'Dollar', N'852', N'HK', N'HKG', N'344', N'.hk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (109, N'Howland Island', N'Howland Island', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (110, N'Hungary', N'Hungary', N'Republic of Hungary', N'Independent State', N'', N'', N'Budapest', N'HUF', N'Forint', N'36', N'HU', N'HUN', N'348', N'.hu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (111, N'Iceland', N'Iceland', N'Republic of Iceland', N'Independent State', N'', N'', N'Reykjavik', N'ISK', N'Krona', N'354', N'IS', N'ISL', N'352', N'.is', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (112, N'India', N'India', N'Republic of India', N'Independent State', N'', N'', N'New Delhi', N'INR', N'Rupee', N'91', N'IN', N'IND', N'356', N'.in', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (113, N'Indonesia', N'Indonesia', N'Republic of Indonesia', N'Independent State', N'', N'', N'Jakarta', N'IDR', N'Rupiah', N'62', N'ID', N'IDN', N'360', N'.id', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (114, N'Iran', N'Iran', N'Islamic Republic of Iran', N'Independent State', N'', N'', N'Tehran', N'IRR', N'Rial', N'98', N'IR', N'IRN', N'364', N'.ir', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (115, N'Iraq', N'Iraq', N'Republic of Iraq', N'Independent State', N'', N'', N'Baghdad', N'IQD', N'Dinar', N'964', N'IQ', N'IRQ', N'368', N'.iq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (116, N'Ireland', N'Ireland', N'', N'Independent State', N'', N'', N'Dublin', N'EUR', N'Euro', N'353', N'IE', N'IRL', N'372', N'.ie', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (117, N'Isle of Man', N'Isle of Man', N'', N'Dependency', N'Crown Dependency', N'United Kingdom', N'Douglas', N'IMP', N'Pound', N'44', N'IM', N'IMN', N'833', N'.im', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (118, N'Israel', N'Israel', N'State of Israel', N'Independent State', N'', N'', N'Jerusalem', N'ILS', N'Shekel', N'972', N'IL', N'ISR', N'376', N'.il', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (119, N'Italy', N'Italy', N'Italian Republic', N'Independent State', N'', N'', N'Rome', N'EUR', N'Euro', N'39', N'IT', N'ITA', N'380', N'.it', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (120, N'Jamaica', N'Jamaica', N'', N'Independent State', N'', N'', N'Kingston', N'JMD', N'Dollar', N'-875', N'JM', N'JAM', N'388', N'.jm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (121, N'Japan', N'Japan', N'', N'Independent State', N'', N'', N'Tokyo', N'JPY', N'Yen', N'81', N'JP', N'JPN', N'392', N'.jp', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (122, N'Jarvis Island', N'Jarvis Island', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (123, N'Jersey', N'Jersey', N'Bailiwick of Jersey', N'Dependency', N'Crown Dependency', N'United Kingdom', N'Saint Helier', N'JEP', N'Pound', N'44', N'JE', N'JEY', N'832', N'.je', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (124, N'Johnston Atoll', N'Johnston Atoll', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (125, N'Jordan', N'Jordan', N'Hashemite Kingdom of Jordan', N'Independent State', N'', N'', N'Amman', N'JOD', N'Dinar', N'962', N'JO', N'JOR', N'400', N'.jo', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (126, N'Kazakhstan', N'Kazakhstan', N'Republic of Kazakhstan', N'Independent State', N'', N'', N'Astana', N'KZT', N'Tenge', N'7', N'KZ', N'KAZ', N'398', N'.kz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (127, N'Kenya', N'Kenya', N'Republic of Kenya', N'Independent State', N'', N'', N'Nairobi', N'KES', N'Shilling', N'254', N'KE', N'KEN', N'404', N'.ke', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (128, N'Kingman Reef', N'Kingman Reef', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (129, N'Kiribati', N'Kiribati', N'Republic of Kiribati', N'Independent State', N'', N'', N'Tarawa', N'AUD', N'Dollar', N'686', N'KI', N'KIR', N'296', N'.ki', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (130, N'Korea, Democratic People''s Republic of (North Korea)', N'Korea, Democratic People''s Republic of (North Korea)', N'Democratic People''s Republic of Korea', N'Independent State', N'', N'', N'Pyongyang', N'KPW', N'Won', N'850', N'KP', N'PRK', N'408', N'.kp', 0)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (131, N'Korea, Republic of  (South Korea)', N'Korea', N'Republic of Korea', N'Independent State', N'', N'', N'Seoul', N'KRW', N'Won', N'82', N'KR', N'KOR', N'410', N'.kr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (132, N'Kosovo', N'Kosovo', N'', N'Disputed Territory', N'', N'Administrated by the UN', N'Pristina', N'CSD and EUR', N'Dinar and Euro', N'381', N'CS', N'SCG', N'891', N'.cs and .yu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (133, N'Kuwait', N'Kuwait', N'State of Kuwait', N'Independent State', N'', N'', N'Kuwait', N'KWD', N'Dinar', N'965', N'KW', N'KWT', N'414', N'.kw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (134, N'Kyrgyzstan', N'Kyrgyzstan', N'Kyrgyz Republic', N'Independent State', N'', N'', N'Bishkek', N'KGS', N'Som', N'996', N'KG', N'KGZ', N'417', N'.kg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (135, N'Laos', N'Laos', N'Lao People''s Democratic Republic', N'Independent State', N'', N'', N'Vientiane', N'LAK', N'Kip', N'856', N'LA', N'LAO', N'418', N'.la', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (136, N'Latvia', N'Latvia', N'Republic of Latvia', N'Independent State', N'', N'', N'Riga', N'LVL', N'Lat', N'371', N'LV', N'LVA', N'428', N'.lv', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (137, N'Lebanon', N'Lebanon', N'Lebanese Republic', N'Independent State', N'', N'', N'Beirut', N'LBP', N'Pound', N'961', N'LB', N'LBN', N'422', N'.lb', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (138, N'Lesotho', N'Lesotho', N'Kingdom of Lesotho', N'Independent State', N'', N'', N'Maseru', N'LSL', N'Loti', N'266', N'LS', N'LSO', N'426', N'.ls', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (139, N'Liberia', N'Liberia', N'Republic of Liberia', N'Independent State', N'', N'', N'Monrovia', N'LRD', N'Dollar', N'231', N'LR', N'LBR', N'430', N'.lr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (140, N'Libya', N'Libya', N'Great Socialist People''s Libyan Arab Jamahiriya', N'Independent State', N'', N'', N'Tripoli', N'LYD', N'Dinar', N'218', N'LY', N'LBY', N'434', N'.ly', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (141, N'Liechtenstein', N'Liechtenstein', N'Principality of Liechtenstein', N'Independent State', N'', N'', N'Vaduz', N'CHF', N'Franc', N'423', N'LI', N'LIE', N'438', N'.li', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (142, N'Lithuania', N'Lithuania', N'Republic of Lithuania', N'Independent State', N'', N'', N'Vilnius', N'LTL', N'Litas', N'370', N'LT', N'LTU', N'440', N'.lt', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (143, N'Luxembourg', N'Luxembourg', N'Grand Duchy of Luxembourg', N'Independent State', N'', N'', N'Luxembourg', N'EUR', N'Euro', N'352', N'LU', N'LUX', N'442', N'.lu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (144, N'Macau', N'Macau', N'Macau Special Administrative Region', N'Proto Dependency', N'Special Administrative Region', N'China', N'Macau', N'MOP', N'Pataca', N'853', N'MO', N'MAC', N'446', N'.mo', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (145, N'Macedonia', N'Macedonia', N'Republic of Macedonia', N'Independent State', N'', N'', N'Skopje', N'MKD', N'Denar', N'389', N'MK', N'MKD', N'807', N'.mk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (146, N'Madagascar', N'Madagascar', N'Republic of Madagascar', N'Independent State', N'', N'', N'Antananarivo', N'MGA', N'Ariary', N'261', N'MG', N'MDG', N'450', N'.mg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (147, N'Malawi', N'Malawi', N'Republic of Malawi', N'Independent State', N'', N'', N'Lilongwe', N'MWK', N'Kwacha', N'265', N'MW', N'MWI', N'454', N'.mw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (148, N'Malaysia', N'Malaysia', N'', N'Independent State', N'', N'', N'Kuala Lumpur (legislative/judical) and Putrajaya (administrative)', N'MYR', N'Ringgit', N'60', N'MY', N'MYS', N'458', N'.my', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (149, N'Maldives', N'Maldives', N'Republic of Maldives', N'Independent State', N'', N'', N'Male', N'MVR', N'Rufiyaa', N'960', N'MV', N'MDV', N'462', N'.mv', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (150, N'Mali', N'Mali', N'Republic of Mali', N'Independent State', N'', N'', N'Bamako', N'XOF', N'Franc', N'223', N'ML', N'MLI', N'466', N'.ml', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (151, N'Malta', N'Malta', N'Republic of Malta', N'Independent State', N'', N'', N'Valletta', N'MTL', N'Lira', N'356', N'MT', N'MLT', N'470', N'.mt', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (152, N'Marshall Islands', N'Marshall Islands', N'Republic of the Marshall Islands', N'Independent State', N'', N'', N'Majuro', N'USD', N'Dollar', N'692', N'MH', N'MHL', N'584', N'.mh', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (153, N'Martinique', N'Martinique', N'Overseas Region of Martinique', N'Proto Dependency', N'Overseas Region', N'France', N'Fort-de-France', N'EUR', N'Euro', N'596', N'MQ', N'MTQ', N'474', N'.mq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (154, N'Mauritania', N'Mauritania', N'Islamic Republic of Mauritania', N'Independent State', N'', N'', N'Nouakchott', N'MRO', N'Ouguiya', N'222', N'MR', N'MRT', N'478', N'.mr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (155, N'Mauritius', N'Mauritius', N'Republic of Mauritius', N'Independent State', N'', N'', N'Port Louis', N'MUR', N'Rupee', N'230', N'MU', N'MUS', N'480', N'.mu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (156, N'Mayotte', N'Mayotte', N'Departmental Collectivity of Mayotte', N'Dependency', N'Overseas Collectivity', N'France', N'Mamoudzou', N'EUR', N'Euro', N'262', N'YT', N'MYT', N'175', N'.yt', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (157, N'Mexico', N'Mexico', N'United Mexican States', N'Independent State', N'', N'', N'Mexico', N'MXN', N'Peso', N'52', N'MX', N'MEX', N'484', N'.mx', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (158, N'Micronesia', N'Micronesia', N'Federated States of Micronesia', N'Independent State', N'', N'', N'Palikir', N'USD', N'Dollar', N'691', N'FM', N'FSM', N'583', N'.fm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (159, N'Midway Islands', N'Midway Islands', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (160, N'Moldova', N'Moldova', N'Republic of Moldova', N'Independent State', N'', N'', N'Chisinau', N'MDL', N'Leu', N'373', N'MD', N'MDA', N'498', N'.md', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (161, N'Monaco', N'Monaco', N'Principality of Monaco', N'Independent State', N'', N'', N'Monaco', N'EUR', N'Euro', N'377', N'MC', N'MCO', N'492', N'.mc', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (162, N'Mongolia', N'Mongolia', N'', N'Independent State', N'', N'', N'Ulaanbaatar', N'MNT', N'Tugrik', N'976', N'MN', N'MNG', N'496', N'.mn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (163, N'Montenegro', N'Montenegro', N'Republic of Montenegro', N'Independent State', N'', N'', N'Podgorica', N'EUR', N'Euro', N'382', N'ME', N'MNE', N'499', N'.me and .yu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (164, N'Montserrat', N'Montserrat', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Plymouth', N'XCD', N'Dollar', N'-663', N'MS', N'MSR', N'500', N'.ms', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (165, N'Morocco', N'Morocco', N'Kingdom of Morocco', N'Independent State', N'', N'', N'Rabat', N'MAD', N'Dirham', N'212', N'MA', N'MAR', N'504', N'.ma', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (166, N'Mozambique', N'Mozambique', N'Republic of Mozambique', N'Independent State', N'', N'', N'Maputo', N'MZM', N'Meticail', N'258', N'MZ', N'MOZ', N'508', N'.mz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (167, N'Myanmar (Burma)', N'Myanmar (Burma)', N'Union of Myanmar', N'Independent State', N'', N'', N'Naypyidaw', N'MMK', N'Kyat', N'95', N'MM', N'MMR', N'104', N'.mm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (168, N'Nagorno-Karabakh', N'Nagorno-Karabakh', N'Nagorno-Karabakh Republic', N'Proto Independent State', N'', N'', N'Stepanakert', N'AMD', N'Dram', N'277', N'AZ', N'AZE', N'31', N'.az', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (169, N'Namibia', N'Namibia', N'Republic of Namibia', N'Independent State', N'', N'', N'Windhoek', N'NAD', N'Dollar', N'264', N'NA', N'NAM', N'516', N'.na', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (170, N'Nauru', N'Nauru', N'Republic of Nauru', N'Independent State', N'', N'', N'Yaren', N'AUD', N'Dollar', N'674', N'NR', N'NRU', N'520', N'.nr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (171, N'Navassa Island', N'Navassa Island', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (172, N'Nepal', N'Nepal', N'', N'Independent State', N'', N'', N'Kathmandu', N'NPR', N'Rupee', N'977', N'NP', N'NPL', N'524', N'.np', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (173, N'Netherlands', N'Netherlands', N'Kingdom of the Netherlands', N'Independent State', N'', N'', N'Amsterdam (administrative) and The Hague (legislative/judical)', N'EUR', N'Euro', N'31', N'NL', N'NLD', N'528', N'.nl', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (174, N'Netherlands Antilles', N'Netherlands Antilles', N'', N'Proto Dependency', N'', N'Netherlands', N'Willemstad', N'ANG', N'Guilder', N'599', N'AN', N'ANT', N'530', N'.an', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (175, N'New Caledonia', N'New Caledonia', N'', N'Dependency', N'Sui generis Collectivity', N'France', N'Noumea', N'XPF', N'Franc', N'687', N'NC', N'NCL', N'540', N'.nc', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (176, N'New Zealand', N'New Zealand', N'', N'Independent State', N'', N'', N'Wellington', N'NZD', N'Dollar', N'64', N'NZ', N'NZL', N'554', N'.nz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (177, N'Nicaragua', N'Nicaragua', N'Republic of Nicaragua', N'Independent State', N'', N'', N'Managua', N'NIO', N'Cordoba', N'505', N'NI', N'NIC', N'558', N'.ni', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (178, N'Niger', N'Niger', N'Republic of Niger', N'Independent State', N'', N'', N'Niamey', N'XOF', N'Franc', N'227', N'NE', N'NER', N'562', N'.ne', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (179, N'Nigeria', N'Nigeria', N'Federal Republic of Nigeria', N'Independent State', N'', N'', N'Abuja', N'NGN', N'Naira', N'234', N'NG', N'NGA', N'566', N'.ng', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (180, N'Niue', N'Niue', N'', N'Dependency', N'Self-Governing in Free Association', N'New Zealand', N'Alofi', N'NZD', N'Dollar', N'683', N'NU', N'NIU', N'570', N'.nu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (181, N'Norfolk Island', N'Norfolk Island', N'Territory of Norfolk Island', N'Dependency', N'External Territory', N'Australia', N'Kingston', N'AUD', N'Dollar', N'672', N'NF', N'NFK', N'574', N'.nf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (182, N'Northern Cyprus', N'Northern Cyprus', N'Turkish Republic of Northern Cyprus', N'Proto Independent State', N'', N'', N'Nicosia', N'TRY', N'Lira', N'-302', N'CY', N'CYP', N'196', N'.nc.tr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (183, N'Northern Mariana Islands', N'Northern Mariana Islands', N'Commonwealth of The Northern Mariana Islands', N'Dependency', N'Commonwealth', N'United States', N'Saipan', N'USD', N'Dollar', N'-669', N'MP', N'MNP', N'580', N'.mp', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (184, N'Norway', N'Norway', N'Kingdom of Norway', N'Independent State', N'', N'', N'Oslo', N'NOK', N'Krone', N'47', N'NO', N'NOR', N'578', N'.no', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (185, N'Oman', N'Oman', N'Sultanate of Oman', N'Independent State', N'', N'', N'Muscat', N'OMR', N'Rial', N'968', N'OM', N'OMN', N'512', N'.om', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (186, N'Pakistan', N'Pakistan', N'Islamic Republic of Pakistan', N'Independent State', N'', N'', N'Islamabad', N'PKR', N'Rupee', N'92', N'PK', N'PAK', N'586', N'.pk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (187, N'Palau', N'Palau', N'Republic of Palau', N'Independent State', N'', N'', N'Melekeok', N'USD', N'Dollar', N'680', N'PW', N'PLW', N'585', N'.pw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (188, N'Palestinian Territories (Gaza Strip and West Bank)', N'Palestinian Territories (Gaza Strip and West Bank)', N'', N'Disputed Territory', N'', N'Administrated by Israel', N'Gaza City (Gaza Strip) and Ramallah (West Bank)', N'ILS', N'Shekel', N'970', N'PS', N'PSE', N'275', N'.ps', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (189, N'Palmyra Atoll', N'Palmyra Atoll', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'581', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (190, N'Panama', N'Panama', N'Republic of Panama', N'Independent State', N'', N'', N'Panama', N'PAB', N'Balboa', N'507', N'PA', N'PAN', N'591', N'.pa', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (191, N'Papua New Guinea', N'Papua New Guinea', N'Independent State of Papua New Guinea', N'Independent State', N'', N'', N'Port Moresby', N'PGK', N'Kina', N'675', N'PG', N'PNG', N'598', N'.pg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (192, N'Paraguay', N'Paraguay', N'Republic of Paraguay', N'Independent State', N'', N'', N'Asuncion', N'PYG', N'Guarani', N'595', N'PY', N'PRY', N'600', N'.py', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (193, N'Peru', N'Peru', N'Republic of Peru', N'Independent State', N'', N'', N'Lima', N'PEN', N'Sol', N'51', N'PE', N'PER', N'604', N'.pe', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (194, N'Peter I Island', N'Peter I Island', N'', N'Antarctic Territory', N'Territory', N'Norway', N'', N'', N'', N'', N'AQ', N'ATA', N'10', N'.aq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (195, N'Philippines', N'Philippines', N'Republic of the Philippines', N'Independent State', N'', N'', N'Manila', N'PHP', N'Peso', N'63', N'PH', N'PHL', N'608', N'.ph', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (196, N'Pitcairn Islands', N'Pitcairn Islands', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Adamstown', N'NZD', N'Dollar', N'', N'PN', N'PCN', N'612', N'.pn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (197, N'Poland', N'Poland', N'Republic of Poland', N'Independent State', N'', N'', N'Warsaw', N'PLN', N'Zloty', N'48', N'PL', N'POL', N'616', N'.pl', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (198, N'Portugal', N'Portugal', N'Portuguese Republic', N'Independent State', N'', N'', N'Lisbon', N'EUR', N'Euro', N'351', N'PT', N'PRT', N'620', N'.pt', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (199, N'Pridnestrovie (Transnistria)', N'Pridnestrovie (Transnistria)', N'Pridnestrovian Moldavian Republic', N'Proto Independent State', N'', N'', N'Tiraspol', N'', N'Ruple', N'-160', N'MD', N'MDA', N'498', N'.md', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (200, N'Puerto Rico', N'Puerto Rico', N'Commonwealth of Puerto Rico', N'Dependency', N'Commonwealth', N'United States', N'San Juan', N'USD', N'Dollar', N'+1-787 and 1-939', N'PR', N'PRI', N'630', N'.pr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (201, N'Qatar', N'Qatar', N'State of Qatar', N'Independent State', N'', N'', N'Doha', N'QAR', N'Rial', N'974', N'QA', N'QAT', N'634', N'.qa', 1)
GO
print 'Processed 200 total records'
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (202, N'Queen Maud Land', N'Queen Maud Land', N'', N'Antarctic Territory', N'Territory', N'Norway', N'', N'', N'', N'', N'AQ', N'ATA', N'10', N'.aq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (203, N'Reunion', N'Reunion', N'Overseas Region of Reunion', N'Proto Dependency', N'Overseas Region', N'France', N'Saint-Denis', N'EUR', N'Euro', N'262', N'RE', N'REU', N'638', N'.re', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (204, N'Romania', N'Romania', N'', N'Independent State', N'', N'', N'Bucharest', N'RON', N'Leu', N'40', N'RO', N'ROU', N'642', N'.ro', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (205, N'Ross Dependency', N'Ross Dependency', N'', N'Antarctic Territory', N'Territory', N'New Zealand', N'', N'', N'', N'', N'AQ', N'ATA', N'10', N'.aq', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (206, N'Russia', N'Russia', N'Russian Federation', N'Independent State', N'', N'', N'Moscow', N'RUB', N'Ruble', N'7', N'RU', N'RUS', N'643', N'.ru and .su', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (207, N'Rwanda', N'Rwanda', N'Republic of Rwanda', N'Independent State', N'', N'', N'Kigali', N'RWF', N'Franc', N'250', N'RW', N'RWA', N'646', N'.rw', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (208, N'Saint Barthelemy', N'Saint Barthelemy', N'Collectivity of Saint Barthelemy', N'Dependency', N'Overseas Collectivity', N'France', N'Gustavia', N'EUR', N'Euro', N'590', N'GP', N'GLP', N'312', N'.gp', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (209, N'Saint Helena', N'Saint Helena', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Jamestown', N'SHP', N'Pound', N'290', N'SH', N'SHN', N'654', N'.sh', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (210, N'Saint Kitts and Nevis', N'Saint Kitts and Nevis', N'Federation of Saint Kitts and Nevis', N'Independent State', N'', N'', N'Basseterre', N'XCD', N'Dollar', N'-868', N'KN', N'KNA', N'659', N'.kn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (211, N'Saint Lucia', N'Saint Lucia', N'', N'Independent State', N'', N'', N'Castries', N'XCD', N'Dollar', N'-757', N'LC', N'LCA', N'662', N'.lc', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (212, N'Saint Martin', N'Saint Martin', N'Collectivity of Saint Martin', N'Dependency', N'Overseas Collectivity', N'France', N'Marigot', N'EUR', N'Euro', N'590', N'GP', N'GLP', N'312', N'.gp', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (213, N'Saint Pierre and Miquelon', N'Saint Pierre and Miquelon', N'Territorial Collectivity of Saint Pierre and Miquelon', N'Dependency', N'Overseas Collectivity', N'France', N'Saint-Pierre', N'EUR', N'Euro', N'508', N'PM', N'SPM', N'666', N'.pm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (214, N'Saint Vincent and the Grenadines', N'Saint Vincent and the Grenadines', N'', N'Independent State', N'', N'', N'Kingstown', N'XCD', N'Dollar', N'-783', N'VC', N'VCT', N'670', N'.vc', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (215, N'Samoa', N'Samoa', N'Independent State of Samoa', N'Independent State', N'', N'', N'Apia', N'WST', N'Tala', N'685', N'WS', N'WSM', N'882', N'.ws', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (216, N'San Marino', N'San Marino', N'Republic of San Marino', N'Independent State', N'', N'', N'San Marino', N'EUR', N'Euro', N'378', N'SM', N'SMR', N'674', N'.sm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (217, N'Sao Tome and Principe', N'Sao Tome and Principe', N'Democratic Republic of Sao Tome and Principe', N'Independent State', N'', N'', N'Sao Tome', N'STD', N'Dobra', N'239', N'ST', N'STP', N'678', N'.st', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (218, N'Saudi Arabia', N'Saudi Arabia', N'Kingdom of Saudi Arabia', N'Independent State', N'', N'', N'Riyadh', N'SAR', N'Rial', N'966', N'SA', N'SAU', N'682', N'.sa', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (219, N'Senegal', N'Senegal', N'Republic of Senegal', N'Independent State', N'', N'', N'Dakar', N'XOF', N'Franc', N'221', N'SN', N'SEN', N'686', N'.sn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (220, N'Serbia', N'Serbia', N'Republic of Serbia', N'Independent State', N'', N'', N'Belgrade', N'RSD', N'Dinar', N'381', N'RS', N'SRB', N'688', N'.rs and .yu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (221, N'Seychelles', N'Seychelles', N'Republic of Seychelles', N'Independent State', N'', N'', N'Victoria', N'SCR', N'Rupee', N'248', N'SC', N'SYC', N'690', N'.sc', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (222, N'Sierra Leone', N'Sierra Leone', N'Republic of Sierra Leone', N'Independent State', N'', N'', N'Freetown', N'SLL', N'Leone', N'232', N'SL', N'SLE', N'694', N'.sl', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (223, N'Singapore', N'Singapore', N'Republic of Singapore', N'Independent State', N'', N'', N'Singapore', N'SGD', N'Dollar', N'65', N'SG', N'SGP', N'702', N'.sg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (224, N'Slovakia', N'Slovakia', N'Slovak Republic', N'Independent State', N'', N'', N'Bratislava', N'SKK', N'Koruna', N'421', N'SK', N'SVK', N'703', N'.sk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (225, N'Slovenia', N'Slovenia', N'Republic of Slovenia', N'Independent State', N'', N'', N'Ljubljana', N'EUR', N'Euro', N'386', N'SI', N'SVN', N'705', N'.si', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (226, N'Solomon Islands', N'Solomon Islands', N'', N'Independent State', N'', N'', N'Honiara', N'SBD', N'Dollar', N'677', N'SB', N'SLB', N'90', N'.sb', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (227, N'Somalia', N'Somalia', N'', N'Independent State', N'', N'', N'Mogadishu', N'SOS', N'Shilling', N'252', N'SO', N'SOM', N'706', N'.so', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (228, N'Somaliland', N'Somaliland', N'Republic of Somaliland', N'Proto Independent State', N'', N'', N'Hargeisa', N'', N'Shilling', N'252', N'SO', N'SOM', N'706', N'.so', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (229, N'South Africa', N'South Africa', N'Republic of South Africa', N'Independent State', N'', N'', N'Pretoria (administrative), Cape Town (legislative), and Bloemfontein (judical)', N'ZAR', N'Rand', N'27', N'ZA', N'ZAF', N'710', N'.za', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (230, N'South Georgia and the South Sandwich Islands', N'South Georgia and the South Sandwich Islands', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'', N'', N'', N'', N'GS', N'SGS', N'239', N'.gs', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (231, N'South Ossetia', N'South Ossetia', N'Republic of South Ossetia', N'Proto Independent State', N'', N'', N'Tskhinvali', N'RUB and GEL', N'Ruble and Lari', N'995', N'GE', N'GEO', N'268', N'.ge', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (232, N'Spain', N'Spain', N'Kingdom of Spain', N'Independent State', N'', N'', N'Madrid', N'EUR', N'Euro', N'34', N'ES', N'ESP', N'724', N'.es', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (233, N'Sri Lanka', N'Sri Lanka', N'Democratic Socialist Republic of Sri Lanka', N'Independent State', N'', N'', N'Colombo (administrative/judical) and Sri Jayewardenepura Kotte (legislative)', N'LKR', N'Rupee', N'94', N'LK', N'LKA', N'144', N'.lk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (234, N'Sudan', N'Sudan', N'Republic of the Sudan', N'Independent State', N'', N'', N'Khartoum', N'SDG', N'Pound', N'249', N'SD', N'SDN', N'736', N'.sd', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (235, N'Suriname', N'Suriname', N'Republic of Suriname', N'Independent State', N'', N'', N'Paramaribo', N'SRD', N'Dollar', N'597', N'SR', N'SUR', N'740', N'.sr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (236, N'Svalbard', N'Svalbard', N'', N'Proto Dependency', N'', N'Norway', N'Longyearbyen', N'NOK', N'Krone', N'47', N'SJ', N'SJM', N'744', N'.sj', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (237, N'Swaziland', N'Swaziland', N'Kingdom of Swaziland', N'Independent State', N'', N'', N'Mbabane (administrative) and Lobamba (legislative)', N'SZL', N'Lilangeni', N'268', N'SZ', N'SWZ', N'748', N'.sz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (238, N'Sweden', N'Sweden', N'Kingdom of Sweden', N'Independent State', N'', N'', N'Stockholm', N'SEK', N'Kronoa', N'46', N'SE', N'SWE', N'752', N'.se', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (239, N'Switzerland', N'Switzerland', N'Swiss Confederation', N'Independent State', N'', N'', N'Bern', N'CHF', N'Franc', N'41', N'CH', N'CHE', N'756', N'.ch', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (240, N'Syria', N'Syria', N'Syrian Arab Republic', N'Independent State', N'', N'', N'Damascus', N'SYP', N'Pound', N'963', N'SY', N'SYR', N'760', N'.sy', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (241, N'Tajikistan', N'Tajikistan', N'Republic of Tajikistan', N'Independent State', N'', N'', N'Dushanbe', N'TJS', N'Somoni', N'992', N'TJ', N'TJK', N'762', N'.tj', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (242, N'Tanzania', N'Tanzania', N'United Republic of Tanzania', N'Independent State', N'', N'', N'Dar es Salaam (administrative/judical) and Dodoma (legislative)', N'TZS', N'Shilling', N'255', N'TZ', N'TZA', N'834', N'.tz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (243, N'Thailand', N'Thailand', N'Kingdom of Thailand', N'Independent State', N'', N'', N'Bangkok', N'THB', N'Baht', N'66', N'TH', N'THA', N'764', N'.th', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (244, N'Timor-Leste (East Timor)', N'Timor-Leste (East Timor)', N'Democratic Republic of Timor-Leste', N'Independent State', N'', N'', N'Dili', N'USD', N'Dollar', N'670', N'TL', N'TLS', N'626', N'.tp and .tl', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (245, N'Togo', N'Togo', N'Togolese Republic', N'Independent State', N'', N'', N'Lome', N'XOF', N'Franc', N'228', N'TG', N'TGO', N'768', N'.tg', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (246, N'Tokelau', N'Tokelau', N'', N'Dependency', N'Territory', N'New Zealand', N'', N'NZD', N'Dollar', N'690', N'TK', N'TKL', N'772', N'.tk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (247, N'Tonga', N'Tonga', N'Kingdom of Tonga', N'Independent State', N'', N'', N'Nuku''alofa', N'TOP', N'Pa''anga', N'676', N'TO', N'TON', N'776', N'.to', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (248, N'Trinidad and Tobago', N'Trinidad and Tobago', N'Republic of Trinidad and Tobago', N'Independent State', N'', N'', N'Port-of-Spain', N'TTD', N'Dollar', N'-867', N'TT', N'TTO', N'780', N'.tt', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (249, N'Tristan da Cunha', N'Tristan da Cunha', N'', N'Proto Dependency', N'Dependency of Saint Helena', N'United Kingdom', N'Edinburgh', N'SHP', N'Pound', N'290', N'TA', N'TAA', N'', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (250, N'Tunisia', N'Tunisia', N'Tunisian Republic', N'Independent State', N'', N'', N'Tunis', N'TND', N'Dinar', N'216', N'TN', N'TUN', N'788', N'.tn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (251, N'Turkey', N'Turkey', N'Republic of Turkey', N'Independent State', N'', N'', N'Ankara', N'TRY', N'Lira', N'90', N'TR', N'TUR', N'792', N'.tr', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (252, N'Turkmenistan', N'Turkmenistan', N'', N'Independent State', N'', N'', N'Ashgabat', N'TMM', N'Manat', N'993', N'TM', N'TKM', N'795', N'.tm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (253, N'Turks and Caicos Islands', N'Turks and Caicos Islands', N'', N'Dependency', N'Overseas Territory', N'United Kingdom', N'Grand Turk', N'USD', N'Dollar', N'-648', N'TC', N'TCA', N'796', N'.tc', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (254, N'Tuvalu', N'Tuvalu', N'', N'Independent State', N'', N'', N'Funafuti', N'AUD', N'Dollar', N'688', N'TV', N'TUV', N'798', N'.tv', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (255, N'U.S. Virgin Islands', N'U.S. Virgin Islands', N'United States Virgin Islands', N'Dependency', N'Territory', N'United States', N'Charlotte Amalie', N'USD', N'Dollar', N'-339', N'VI', N'VIR', N'850', N'.vi', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (256, N'Uganda', N'Uganda', N'Republic of Uganda', N'Independent State', N'', N'', N'Kampala', N'UGX', N'Shilling', N'256', N'UG', N'UGA', N'800', N'.ug', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (257, N'Ukraine', N'Ukraine', N'', N'Independent State', N'', N'', N'Kiev', N'UAH', N'Hryvnia', N'380', N'UA', N'UKR', N'804', N'.ua', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (258, N'United Arab Emirates', N'United Arab Emirates', N'United Arab Emirates', N'Independent State', N'', N'', N'Abu Dhabi', N'AED', N'Dirham', N'971', N'AE', N'ARE', N'784', N'.ae', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (259, N'United Kingdom', N'United Kingdom', N'United Kingdom of Great Britain and Northern Ireland', N'Independent State', N'', N'', N'London', N'GBP', N'Pound', N'44', N'GB', N'GBR', N'826', N'.uk', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (260, N'United States of America', N'United States of America', N'United States of America', N'Independent State', N'', N'', N'Washington', N'USD', N'Dollar', N'1', N'US', N'USA', N'840', N'.us', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (261, N'Uruguay', N'Uruguay', N'Oriental Republic of Uruguay', N'Independent State', N'', N'', N'Montevideo', N'UYU', N'Peso', N'598', N'UY', N'URY', N'858', N'.uy', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (262, N'Uzbekistan', N'Uzbekistan', N'Republic of Uzbekistan', N'Independent State', N'', N'', N'Tashkent', N'UZS', N'Som', N'998', N'UZ', N'UZB', N'860', N'.uz', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (263, N'Vanuatu', N'Vanuatu', N'Republic of Vanuatu', N'Independent State', N'', N'', N'Port-Vila', N'VUV', N'Vatu', N'678', N'VU', N'VUT', N'548', N'.vu', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (264, N'Vatican City', N'Vatican City', N'State of the Vatican City', N'Independent State', N'', N'', N'Vatican City', N'EUR', N'Euro', N'379', N'VA', N'VAT', N'336', N'.va', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (265, N'Venezuela', N'Venezuela', N'Bolivarian Republic of Venezuela', N'Independent State', N'', N'', N'Caracas', N'VEB', N'Bolivar', N'58', N'VE', N'VEN', N'862', N'.ve', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (266, N'Vietnam', N'Vietnam', N'Socialist Republic of Vietnam', N'Independent State', N'', N'', N'Hanoi', N'VND', N'Dong', N'84', N'VN', N'VNM', N'704', N'.vn', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (267, N'Wake Island', N'Wake Island', N'', N'Dependency', N'Territory', N'United States', N'', N'', N'', N'', N'UM', N'UMI', N'850', N'', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (268, N'Wallis and Futuna', N'Wallis and Futuna', N'Collectivity of the Wallis and Futuna Islands', N'Dependency', N'Overseas Collectivity', N'France', N'Mata''utu', N'XPF', N'Franc', N'681', N'WF', N'WLF', N'876', N'.wf', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (269, N'Western Sahara', N'Western Sahara', N'', N'Disputed Territory', N'', N'Administrated by Morocco', N'El-Aaiun', N'MAD', N'Dirham', N'212', N'EH', N'ESH', N'732', N'.eh', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (270, N'Yemen', N'Yemen', N'Republic of Yemen', N'Independent State', N'', N'', N'Sanaa', N'YER', N'Rial', N'967', N'YE', N'YEM', N'887', N'.ye', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (271, N'Zambia', N'Zambia', N'Republic of Zambia', N'Independent State', N'', N'', N'Lusaka', N'ZMK', N'Kwacha', N'260', N'ZM', N'ZMB', N'894', N'.zm', 1)
INSERT [dbo].[Countries] ([ID], [CountryName], [DisplayName], [FormalName], [Type], [SubType], [Sovereignty], [Capital], [ISO_4217_Currency_Code], [ISO_4217_Currency_Name], [ITU_T_Telephone_Code], [ISO_3166_1_2Letter_Code], [ISO_3166_1_3Letter_Code], [ISO_3166_1Number], [IANA_Country_Code_TLD], [IsListed]) VALUES (272, N'Zimbabwe', N'Zimbabwe', N'Republic of Zimbabwe', N'Independent State', N'', N'', N'Harare', N'ZWD', N'Dollar', N'263', N'ZW', N'ZWE', N'716', N'.zw', 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
/****** Object:  Table [dbo].[CompanyTypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyType] [nvarchar](250) NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CompanyTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CompanyTypes] ON
INSERT [dbo].[CompanyTypes] ([ID], [CompanyType], [IsRemoved]) VALUES (1, N'Sole Trader', 0)
INSERT [dbo].[CompanyTypes] ([ID], [CompanyType], [IsRemoved]) VALUES (2, N'Limited company', 0)
INSERT [dbo].[CompanyTypes] ([ID], [CompanyType], [IsRemoved]) VALUES (3, N'Public Company ', 0)
SET IDENTITY_INSERT [dbo].[CompanyTypes] OFF
/****** Object:  StoredProcedure [dbo].[GET_SellerCompanyInfo]    Script Date: 02/18/2015 16:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		A Khan
-- Create date: 22 Oct 2014
-- Description:	SP to get the seller company information.
-- =============================================
CREATE PROCEDURE [dbo].[GET_SellerCompanyInfo] 
	-- Add the parameters for the stored procedure here
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.CompanyInfo WHERE UserID = @UserID
END
GO
/****** Object:  Table [dbo].[CompanyCategories]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](250) NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CompanyCategories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Company category ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CompanyCategories', @level2type=N'COLUMN',@level2name=N'ID'
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](250) NOT NULL,
	[CountryID] [int] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarSellingOn]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellingOn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Way] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_CarSellingOn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CarSellingOn] ON
INSERT [dbo].[CarSellingOn] ([ID], [Way], [Description]) VALUES (1, N'Classified Ad', NULL)
INSERT [dbo].[CarSellingOn] ([ID], [Way], [Description]) VALUES (2, N'Live Auction', NULL)
INSERT [dbo].[CarSellingOn] ([ID], [Way], [Description]) VALUES (3, N'Timed Auction', NULL)
SET IDENTITY_INSERT [dbo].[CarSellingOn] OFF
/****** Object:  Table [dbo].[CarSellerTypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_CarSellerTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CarSellerTypes] ON
INSERT [dbo].[CarSellerTypes] ([ID], [Type], [Description]) VALUES (1, N'Private Seller', NULL)
INSERT [dbo].[CarSellerTypes] ([ID], [Type], [Description]) VALUES (2, N'Trade Seller', NULL)
SET IDENTITY_INSERT [dbo].[CarSellerTypes] OFF
/****** Object:  Table [dbo].[CarSellerPackages]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerPackages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Package] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CarSellerPackages] ON
INSERT [dbo].[CarSellerPackages] ([ID], [Package], [Description]) VALUES (1, N'Package 1 ', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')
INSERT [dbo].[CarSellerPackages] ([ID], [Package], [Description]) VALUES (5, N'Package 2', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')
INSERT [dbo].[CarSellerPackages] ([ID], [Package], [Description]) VALUES (6, N'Package 3', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')
INSERT [dbo].[CarSellerPackages] ([ID], [Package], [Description]) VALUES (7, N'Package 4', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')
INSERT [dbo].[CarSellerPackages] ([ID], [Package], [Description]) VALUES (8, N'Package 5', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')
INSERT [dbo].[CarSellerPackages] ([ID], [Package], [Description]) VALUES (9, N'Package 6', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')
SET IDENTITY_INSERT [dbo].[CarSellerPackages] OFF
/****** Object:  Table [dbo].[CarSellerVehicleImages]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerVehicleImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NULL,
	[ImageSizeID] [int] NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[OriginalFilename] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[Foldername] [nvarchar](max) NULL,
	[Size] [int] NULL,
	[UploadedOn] [datetime] NULL,
	[UploadedFromIP] [nvarchar](50) NULL,
	[UploadedByUserID] [int] NULL,
	[TempID] [nvarchar](100) NULL,
	[SectionFromImageUploaded] [nvarchar](50) NULL,
	[PositionID] [int] NULL,
 CONSTRAINT [PK_CarSellerVehicleImages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SELL, 
AUCTION-HOUSE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarSellerVehicleImages', @level2type=N'COLUMN',@level2name=N'SectionFromImageUploaded'
GO
/****** Object:  Table [dbo].[CarSellerVehicleFuelTypes]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerVehicleFuelTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NOT NULL,
	[FuelTypeID] [int] NULL,
 CONSTRAINT [PK_CarSellerVehicleFuelTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsersAdditionalInfo]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsersAdditionalInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserKey] [nvarchar](128) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedFromIP] [nvarchar](50) NOT NULL,
	[IsRemoved] [bit] NULL,
	[SellerTypeID] [int] NULL,
 CONSTRAINT [PK_AspNetUsersAdditionalInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AspNetUsersAdditionalInfo] ON
INSERT [dbo].[AspNetUsersAdditionalInfo] ([ID], [UserKey], [CreatedOn], [CreatedFromIP], [IsRemoved], [SellerTypeID]) VALUES (74, N'30b7bdc0-3509-4f43-8a9f-d44f5b24f7c0', CAST(0x0000A42D00DE5E14 AS DateTime), N'::1', NULL, 1)
INSERT [dbo].[AspNetUsersAdditionalInfo] ([ID], [UserKey], [CreatedOn], [CreatedFromIP], [IsRemoved], [SellerTypeID]) VALUES (75, N'00e4a9af-344c-4ab2-90ab-9babd7026d4f', CAST(0x0000A42D00DEF267 AS DateTime), N'::1', NULL, 2)
SET IDENTITY_INSERT [dbo].[AspNetUsersAdditionalInfo] OFF
/****** Object:  StoredProcedure [dbo].[GET_VehicleImageInfo]    Script Date: 02/18/2015 16:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: A Khan
-- Create date: 04 Nov 2014
-- Description:	 SP to get the vehicle image info.
-- TestQuery : Exec GET_VehicleImageInfo 21,1
-- =============================================
CREATE PROCEDURE [dbo].[GET_VehicleImageInfo]
	-- Add the parameters for the stored procedure here
	@VehicleID int,
	@ImageSizeID int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT * FROM [dbo].[CarSellerVehicleImages] WHERE VehicleID = @VehicleID And
		(@ImageSizeID = NULL Or ImageSizeID = @ImageSizeID) ORDER BY ID
END
GO
/****** Object:  StoredProcedure [dbo].[SAVE_CreateSaleDate]    Script Date: 02/18/2015 16:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		A Khan
-- Create date: 25 Nov 2014
-- Description:	SP to save the new Sale date.
-- =============================================
CREATE PROCEDURE [dbo].[SAVE_CreateSaleDate] 
	-- Add the parameters for the stored procedure here
	@UserID int,
	@Title nvarchar(max),
	@SaleDate datetime,
	@Description nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(Exists(SELECT ID FROM dbo.SaleDates WHERE UserID = @UserID and VehicleSaleDate = @SaleDate))
	BEGIN
		SELECT * FROM dbo.SaleDates WHERE UserID = @UserID and VehicleSaleDate = @SaleDate
	END 
	ELSE
	BEGIN
		DECLARE @NewID AS INT
		INSERT INTO dbo.SaleDates(UserID, Title, VehicleSaleDate, [Description])
		VALUES(@UserID, @Title, @SaleDate, @Description)
		
		SET @Newid = SCOPE_IDENTITY()
		
		SELECT * FROM dbo.SaleDates WHERE ID = @NewID
	END
END
GO
/****** Object:  Table [dbo].[CarSellerDocuments]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerDocuments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[OriginalFilename] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[Foldername] [nvarchar](max) NULL,
	[MIMETypeID] [int] NULL,
	[Size] [int] NULL,
	[UploadedOn] [datetime] NULL,
	[UploadedFromIP] [nvarchar](50) NULL,
	[UploadedByUserID] [int] NULL,
	[TempID] [nvarchar](100) NULL,
	[SectionFromDocUploaded] [nvarchar](50) NULL,
 CONSTRAINT [PK_CarSellerDocuments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Document ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarSellerDocuments', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SELL, AUCTION-HOUSE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarSellerDocuments', @level2type=N'COLUMN',@level2name=N'SectionFromDocUploaded'
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_VehileIDIntoCarSellerVehicleImages]    Script Date: 02/18/2015 16:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		A Khan
-- Create date: 03 Nov 2014
-- Description:	SP to update the vehilce ID into Vehicle Image info.
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_VehileIDIntoCarSellerVehicleImages] 
	-- Add the parameters for the stored procedure here
	@UniqueID nvarchar(100),
	@vehicleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
	UPDATE dbo.CarSellerVehicleImages SET VehicleID = @vehicleID,
		TempID = NULL where TempID = @UniqueID
	UPDATE dbo.CarSellerVehicleImages SET Foldername = REPLACE(Foldername, @UniqueID, @vehicleID)
END
GO
/****** Object:  Table [dbo].[SellerCompanyInfo]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerCompanyInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CompanyTypeID] [int] NOT NULL,
	[CompanyName] [nvarchar](250) NOT NULL,
	[Address001] [nvarchar](250) NOT NULL,
	[Address002] [nvarchar](250) NULL,
	[Address003] [nvarchar](250) NULL,
	[CityID] [int] NULL,
	[CountryID] [int] NULL,
	[PostalCode] [nvarchar](250) NULL,
	[ContactNumbers] [nvarchar](max) NOT NULL,
	[CompanyNumber] [nvarchar](250) NULL,
	[VatNumber] [nvarchar](250) NULL,
	[YearOfFoundation] [int] NULL,
	[NoOfEmployees] [int] NULL,
	[TurnOver] [decimal](18, 2) NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Numbers = Contact Number ~ 2nd Number ~ 3rd Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SellerCompanyInfo', @level2type=N'COLUMN',@level2name=N'ContactNumbers'
GO
SET IDENTITY_INSERT [dbo].[SellerCompanyInfo] ON
INSERT [dbo].[SellerCompanyInfo] ([ID], [UserID], [CompanyTypeID], [CompanyName], [Address001], [Address002], [Address003], [CityID], [CountryID], [PostalCode], [ContactNumbers], [CompanyNumber], [VatNumber], [YearOfFoundation], [NoOfEmployees], [TurnOver], [CategoryID]) VALUES (65, 75, 0, N'Antaaru Shop', N'New Delhi', NULL, NULL, NULL, 112, N'PO16 7GZ', N'(234) 234-2423~(465) 464-5645+(456) 546-4564', N'23434', N'234234', 2015, 10, CAST(15225855.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[SellerCompanyInfo] OFF
/****** Object:  Table [dbo].[SellerCardDetails]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerCardDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[CardNumber] [nvarchar](250) NOT NULL,
	[BillingAddress] [nvarchar](max) NULL,
	[LikeToReceiveMarketingProducts] [bit] NULL,
 CONSTRAINT [PK_SellerCardDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarSellerInfo]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[SellerTypeID] [int] NULL,
	[WayOfSelling] [int] NULL,
 CONSTRAINT [PK_CarSellerInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1. Private Seller
2. Trade Seller' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarSellerInfo', @level2type=N'COLUMN',@level2name=N'SellerTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1. Classified Ad
2. Live Auction
3. Timed Auction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarSellerInfo', @level2type=N'COLUMN',@level2name=N'WayOfSelling'
GO
/****** Object:  Table [dbo].[SellerPersonalInfo]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerPersonalInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[FirstName] [nvarchar](250) NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[Address001] [nvarchar](250) NULL,
	[Address002] [nvarchar](250) NULL,
	[Address003] [nvarchar](250) NULL,
	[ContactNo] [nvarchar](250) NULL,
	[PostalCode] [nvarchar](250) NULL,
 CONSTRAINT [PK_PersonalInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SellerPersonalInfo] ON
INSERT [dbo].[SellerPersonalInfo] ([ID], [UserID], [Title], [FirstName], [MiddleName], [LastName], [Address001], [Address002], [Address003], [ContactNo], [PostalCode]) VALUES (65, 74, N'0', N'AKhan', NULL, N'Ganar', N'1120 Lodhi complex', NULL, NULL, N'(242) 342-3423', N'PO16 7GZ')
INSERT [dbo].[SellerPersonalInfo] ([ID], [UserID], [Title], [FirstName], [MiddleName], [LastName], [Address001], [Address002], [Address003], [ContactNo], [PostalCode]) VALUES (66, 75, N'0', N'Sameer', NULL, N'Ganar', N'New Delhi', NULL, NULL, N'(878) 558-5588', N'PO16 7GZ')
SET IDENTITY_INSERT [dbo].[SellerPersonalInfo] OFF
/****** Object:  Table [dbo].[AspNetUsersANDUserTypesMapping]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsersANDUserTypesMapping](
	[ID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserTypeID] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsersANDUserTypesMapping] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarSellerVehicleInfo]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerVehicleInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CarSellerInfoID] [int] NOT NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[MakeID] [int] NULL,
	[ModelID] [int] NULL,
	[BodyTypeID] [int] NULL,
	[Color] [nvarchar](50) NULL,
	[MOTExpiryDate] [datetime] NULL,
	[TransmissionTypeID] [int] NULL,
	[ExactMileage] [nvarchar](50) NULL,
	[InteriorColor] [nvarchar](50) NULL,
	[Trim] [nvarchar](50) NULL,
	[TAXExpiryDate] [datetime] NULL,
	[ServiceHistory] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[DateOfFirstRegistration] [datetime] NULL,
 CONSTRAINT [PK_SellerVehicleInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SellerInfo]    Script Date: 02/18/2015 16:50:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SellerInfo]
AS
SELECT        dbo.AspNetUsersAdditionalInfo.ID, dbo.AspNetUsers.Id AS UserKey, dbo.AspNetUsers.UserName, dbo.AspNetUsers.Email, dbo.AspNetUsers.PasswordHash, 
                         dbo.AspNetUsers.SecurityStamp, dbo.SellerPersonalInfo.Title, dbo.SellerPersonalInfo.FirstName, dbo.SellerPersonalInfo.MiddleName, 
                         dbo.SellerPersonalInfo.LastName, dbo.SellerPersonalInfo.Address001, dbo.SellerPersonalInfo.Address002, dbo.SellerPersonalInfo.Address003, 
                         dbo.SellerPersonalInfo.ContactNo, dbo.SellerPersonalInfo.PostalCode, dbo.AspNetUsersAdditionalInfo.CreatedOn, dbo.AspNetUsersAdditionalInfo.CreatedFromIP, 
                         dbo.AspNetUsersAdditionalInfo.IsRemoved, dbo.AspNetUsersAdditionalInfo.SellerTypeID
FROM            dbo.AspNetUsers INNER JOIN
                         dbo.AspNetUsersAdditionalInfo ON dbo.AspNetUsers.Id = dbo.AspNetUsersAdditionalInfo.UserKey INNER JOIN
                         dbo.SellerPersonalInfo ON dbo.AspNetUsersAdditionalInfo.ID = dbo.SellerPersonalInfo.UserID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AspNetUsers"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 231
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "AspNetUsersAdditionalInfo"
            Begin Extent = 
               Top = 6
               Left = 281
               Bottom = 199
               Right = 443
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PersonalInfo"
            Begin Extent = 
               Top = 6
               Left = 481
               Bottom = 220
               Right = 641
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 21
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or =' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SellerInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SellerInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SellerInfo'
GO
/****** Object:  StoredProcedure [dbo].[GET_SellerVehiclesInfo]    Script Date: 02/18/2015 16:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		A Khan
-- Create date: 16 Nov 2014
-- Description:	Sp to get the vehicle images info.
-- =============================================
CREATE PROCEDURE [dbo].[GET_SellerVehiclesInfo] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from dbo.CarSellerVehicleInfo where CarSellerInfoID 
	in(select ID from dbo.CarSellerInfo)
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SellerPersonalInfo]    Script Date: 02/18/2015 16:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		A Khan
-- Create date: 22 Oct 2014
-- Description:	SP to get the seller profile info.
-- =============================================
CREATE PROCEDURE [dbo].[GET_SellerPersonalInfo] 
	-- Add the parameters for the stored procedure here
	@UserID int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.SellerInfo
	WHERE ID = @UserID
END
GO
/****** Object:  Table [dbo].[CarSellerMoreDetails]    Script Date: 02/18/2015 16:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSellerMoreDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NULL,
	[CarLocation] [nvarchar](50) NULL,
	[ContactEmailID] [nvarchar](max) NULL,
	[ContactNumberOnAdvert] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[SelectedPackageID] [int] NULL,
 CONSTRAINT [PK_CarSellerMoreDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_AspNetUsersAdditionalInfo_IsRemoved]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUsersAdditionalInfo] ADD  CONSTRAINT [DF_AspNetUsersAdditionalInfo_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
/****** Object:  Default [DF_CarSellerDocuments_MIMETypeID]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerDocuments] ADD  CONSTRAINT [DF_CarSellerDocuments_MIMETypeID]  DEFAULT ((0)) FOR [MIMETypeID]
GO
/****** Object:  Default [DF_CarSellerVehicleImages_ImageSizeID]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerVehicleImages] ADD  CONSTRAINT [DF_CarSellerVehicleImages_ImageSizeID]  DEFAULT ((0)) FOR [ImageSizeID]
GO
/****** Object:  Default [DF_CompanyCategories_IsRemoved]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CompanyCategories] ADD  CONSTRAINT [DF_CompanyCategories_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
/****** Object:  Default [DF_CompanyTypes_IsRemoved]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CompanyTypes] ADD  CONSTRAINT [DF_CompanyTypes_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
/****** Object:  Default [DF_Countries_IsListed]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [DF_Countries_IsListed]  DEFAULT ((0)) FOR [IsListed]
GO
/****** Object:  Default [DF_ImageSizes_IsRemoved]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[ImageSizes] ADD  CONSTRAINT [DF_ImageSizes_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
/****** Object:  Default [DF_Makes_IsRemoved]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[Makes] ADD  CONSTRAINT [DF_Makes_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
/****** Object:  Default [DF_SellerCardDetails_LikeToReceiveMarketingProducts]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[SellerCardDetails] ADD  CONSTRAINT [DF_SellerCardDetails_LikeToReceiveMarketingProducts]  DEFAULT ((0)) FOR [LikeToReceiveMarketingProducts]
GO
/****** Object:  Default [DF_UserTypes_IsRemoved]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[UserTypes] ADD  CONSTRAINT [DF_UserTypes_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_AspNetUsersAdditionalInfo_AspNetUsers]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUsersAdditionalInfo]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsersAdditionalInfo_AspNetUsers] FOREIGN KEY([UserKey])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsersAdditionalInfo] CHECK CONSTRAINT [FK_AspNetUsersAdditionalInfo_AspNetUsers]
GO
/****** Object:  ForeignKey [FK_AspNetUsersANDUserTypesMapping_AspNetUsersAdditionalInfo]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUsersANDUserTypesMapping]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsersANDUserTypesMapping_AspNetUsersAdditionalInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsersAdditionalInfo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsersANDUserTypesMapping] CHECK CONSTRAINT [FK_AspNetUsersANDUserTypesMapping_AspNetUsersAdditionalInfo]
GO
/****** Object:  ForeignKey [FK_AspNetUsersANDUserTypesMapping_UserTypes]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[AspNetUsersANDUserTypesMapping]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsersANDUserTypesMapping_UserTypes] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserTypes] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsersANDUserTypesMapping] CHECK CONSTRAINT [FK_AspNetUsersANDUserTypesMapping_UserTypes]
GO
/****** Object:  ForeignKey [FK_CarSellerDocuments_MIMETypes]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerDocuments]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerDocuments_MIMETypes] FOREIGN KEY([MIMETypeID])
REFERENCES [dbo].[MIMETypes] ([ID])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[CarSellerDocuments] CHECK CONSTRAINT [FK_CarSellerDocuments_MIMETypes]
GO
/****** Object:  ForeignKey [FK_CarSellerInfo_AspNetUsersAdditionalInfo]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerInfo]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerInfo_AspNetUsersAdditionalInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsersAdditionalInfo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarSellerInfo] CHECK CONSTRAINT [FK_CarSellerInfo_AspNetUsersAdditionalInfo]
GO
/****** Object:  ForeignKey [FK_CarSellerInfo_CarSellerTypes]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerInfo]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerInfo_CarSellerTypes] FOREIGN KEY([SellerTypeID])
REFERENCES [dbo].[CarSellerTypes] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CarSellerInfo] CHECK CONSTRAINT [FK_CarSellerInfo_CarSellerTypes]
GO
/****** Object:  ForeignKey [FK_CarSellerInfo_CarSellingOn]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerInfo]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerInfo_CarSellingOn] FOREIGN KEY([WayOfSelling])
REFERENCES [dbo].[CarSellingOn] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CarSellerInfo] CHECK CONSTRAINT [FK_CarSellerInfo_CarSellingOn]
GO
/****** Object:  ForeignKey [FK_CarSellerMoreDetails_CarSellerPackages]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerMoreDetails]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerMoreDetails_CarSellerPackages] FOREIGN KEY([SelectedPackageID])
REFERENCES [dbo].[CarSellerPackages] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CarSellerMoreDetails] CHECK CONSTRAINT [FK_CarSellerMoreDetails_CarSellerPackages]
GO
/****** Object:  ForeignKey [FK_CarSellerMoreDetails_CarSellerVehicleInfo]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerMoreDetails]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerMoreDetails_CarSellerVehicleInfo] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[CarSellerVehicleInfo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarSellerMoreDetails] CHECK CONSTRAINT [FK_CarSellerMoreDetails_CarSellerVehicleInfo]
GO
/****** Object:  ForeignKey [FK_CarSellerVehicleFuelTypes_FuelTypes]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerVehicleFuelTypes]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerVehicleFuelTypes_FuelTypes] FOREIGN KEY([FuelTypeID])
REFERENCES [dbo].[FuelTypes] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CarSellerVehicleFuelTypes] CHECK CONSTRAINT [FK_CarSellerVehicleFuelTypes_FuelTypes]
GO
/****** Object:  ForeignKey [FK_CarSellerVehicleInfo_BodyTypes]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerVehicleInfo]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerVehicleInfo_BodyTypes] FOREIGN KEY([BodyTypeID])
REFERENCES [dbo].[BodyTypes] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CarSellerVehicleInfo] CHECK CONSTRAINT [FK_CarSellerVehicleInfo_BodyTypes]
GO
/****** Object:  ForeignKey [FK_CarSellerVehicleInfo_CarSellerInfo]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerVehicleInfo]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerVehicleInfo_CarSellerInfo] FOREIGN KEY([CarSellerInfoID])
REFERENCES [dbo].[CarSellerInfo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarSellerVehicleInfo] CHECK CONSTRAINT [FK_CarSellerVehicleInfo_CarSellerInfo]
GO
/****** Object:  ForeignKey [FK_CarSellerVehicleInfo_TransmissionTypes]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[CarSellerVehicleInfo]  WITH CHECK ADD  CONSTRAINT [FK_CarSellerVehicleInfo_TransmissionTypes] FOREIGN KEY([TransmissionTypeID])
REFERENCES [dbo].[TransmissionTypes] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CarSellerVehicleInfo] CHECK CONSTRAINT [FK_CarSellerVehicleInfo_TransmissionTypes]
GO
/****** Object:  ForeignKey [FK_SellerCardDetails_AspNetUsersAdditionalInfo]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[SellerCardDetails]  WITH CHECK ADD  CONSTRAINT [FK_SellerCardDetails_AspNetUsersAdditionalInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsersAdditionalInfo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SellerCardDetails] CHECK CONSTRAINT [FK_SellerCardDetails_AspNetUsersAdditionalInfo]
GO
/****** Object:  ForeignKey [FK_CompanyInfo_AspNetUsersAdditionalInfo]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[SellerCompanyInfo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfo_AspNetUsersAdditionalInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsersAdditionalInfo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SellerCompanyInfo] CHECK CONSTRAINT [FK_CompanyInfo_AspNetUsersAdditionalInfo]
GO
/****** Object:  ForeignKey [FK_PersonalInfo_AspNetUsersAdditionalInfo]    Script Date: 02/18/2015 16:50:03 ******/
ALTER TABLE [dbo].[SellerPersonalInfo]  WITH CHECK ADD  CONSTRAINT [FK_PersonalInfo_AspNetUsersAdditionalInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsersAdditionalInfo] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SellerPersonalInfo] CHECK CONSTRAINT [FK_PersonalInfo_AspNetUsersAdditionalInfo]
GO
