/****** Object:  Database [team18db]    Script Date: 11/27/2022 9:10:03 PM ******/
CREATE DATABASE [team18db]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_Gen5_2', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [team18db] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [team18db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [team18db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [team18db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [team18db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [team18db] SET ARITHABORT OFF 
GO
ALTER DATABASE [team18db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [team18db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [team18db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [team18db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [team18db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [team18db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [team18db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [team18db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [team18db] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [team18db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [team18db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [team18db] SET  MULTI_USER 
GO
ALTER DATABASE [team18db] SET ENCRYPTION ON
GO
ALTER DATABASE [team18db] SET QUERY_STORE = ON
GO
ALTER DATABASE [team18db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Fname] [nvarchar](50) NOT NULL,
	[Minit] [nchar](1) NULL,
	[Lname] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientRequests]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientRequests](
	[RequestDesc] [nvarchar](750) NULL,
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ClientRequests] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](100) NOT NULL,
	[DepartmentManagerID] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[UserID] [int] NOT NULL,
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [nvarchar](50) NOT NULL,
	[Minit] [nchar](1) NULL,
	[Lname] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Sex] [nchar](1) NOT NULL,
	[DepartmentID] [int] NULL,
	[Hourly_rate] [decimal](6, 2) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorMessages]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorMessages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ErrorDescription] [nvarchar](400) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectDept] [int] NOT NULL,
	[ProjectManagerID] [int] NOT NULL,
	[ProjectBudget] [decimal](9, 2) NOT NULL,
	[CurrentExpenses] [decimal](9, 2) NOT NULL,
	[ProjectDeadline] [date] NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__tmp_ms_x__761ABED0D5464B3A] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[TaskBudget] [decimal](9, 2) NOT NULL,
	[TaskName] [nvarchar](100) NOT NULL,
	[TaskDeadline] [date] NOT NULL,
	[TaskExpenses] [decimal](9, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[userName] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorksOn]    Script Date: 11/27/2022 9:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorksOn](
	[WorksOnID] [int] IDENTITY(1,1) NOT NULL,
	[HoursWorked] [decimal](4, 2) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK__WorksOn__4ADF732B05B30594] PRIMARY KEY CLUSTERED 
(
	[WorksOnID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientID], [UserID], [Fname], [Minit], [Lname]) VALUES (1, 10, N'Cristiano', NULL, N'Ronaldo')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientRequests] ON 

INSERT [dbo].[ClientRequests] ([RequestDesc], [RequestID]) VALUES (N'My username is Dante and I Work for CyberWear Solutions, and I need a Package that helps me with animation software for an upcoming movie coming out in 2023. I need this done by Valentines day', 5)
SET IDENTITY_INSERT [dbo].[ClientRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentID], [DepartmentName], [DepartmentManagerID]) VALUES (1, N'Software Engineering', 1)
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName], [DepartmentManagerID]) VALUES (3, N'Design', 1)
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName], [DepartmentManagerID]) VALUES (4, N'Construction', 12)
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName], [DepartmentManagerID]) VALUES (5, N'Marketing', 11)
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([UserID], [EmployeeID], [Fname], [Minit], [Lname], [DOB], [Sex], [DepartmentID], [Hourly_rate]) VALUES (5, 1, N'Wei-1', NULL, N'Lin Tan', CAST(N'1991-11-11' AS Date), N'M', 1, CAST(30.00 AS Decimal(6, 2)))
INSERT [dbo].[Employee] ([UserID], [EmployeeID], [Fname], [Minit], [Lname], [DOB], [Sex], [DepartmentID], [Hourly_rate]) VALUES (9, 11, N'John', NULL, N'Smith', CAST(N'1999-09-09' AS Date), N'M', 1, CAST(33.00 AS Decimal(6, 2)))
INSERT [dbo].[Employee] ([UserID], [EmployeeID], [Fname], [Minit], [Lname], [DOB], [Sex], [DepartmentID], [Hourly_rate]) VALUES (8, 12, N'Abishek', NULL, N'Shaju', CAST(N'2001-11-20' AS Date), N'M', 1, CAST(32.00 AS Decimal(6, 2)))
INSERT [dbo].[Employee] ([UserID], [EmployeeID], [Fname], [Minit], [Lname], [DOB], [Sex], [DepartmentID], [Hourly_rate]) VALUES (10, 14, N'Cristiano', NULL, N'Ronaldo', CAST(N'1985-02-17' AS Date), N'M', 1, CAST(39.00 AS Decimal(6, 2)))
INSERT [dbo].[Employee] ([UserID], [EmployeeID], [Fname], [Minit], [Lname], [DOB], [Sex], [DepartmentID], [Hourly_rate]) VALUES (21, 16, N'Peter', N'N', N'Mendoza', CAST(N'2002-11-19' AS Date), N'M', 3, CAST(30.00 AS Decimal(6, 2)))
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[ErrorMessages] ON 

INSERT [dbo].[ErrorMessages] ([MessageID], [ProjectID], [ErrorDescription]) VALUES (1, 31, N'The Expenses are coming close to the Budget for project:')
INSERT [dbo].[ErrorMessages] ([MessageID], [ProjectID], [ErrorDescription]) VALUES (8, 31, N'Employee wants to work more than 40 Hours in project: ')
INSERT [dbo].[ErrorMessages] ([MessageID], [ProjectID], [ErrorDescription]) VALUES (9, 38, N'The Expenses are coming close to the Budget for project:')
INSERT [dbo].[ErrorMessages] ([MessageID], [ProjectID], [ErrorDescription]) VALUES (10, 41, N'Employee wants to work more than 40 Hours in project: ')
SET IDENTITY_INSERT [dbo].[ErrorMessages] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ProjectID], [ProjectDept], [ProjectManagerID], [ProjectBudget], [CurrentExpenses], [ProjectDeadline], [ProjectName]) VALUES (31, 1, 1, CAST(97000.00 AS Decimal(9, 2)), CAST(96000.00 AS Decimal(9, 2)), CAST(N'2023-11-29' AS Date), N'McDonalds')
INSERT [dbo].[Projects] ([ProjectID], [ProjectDept], [ProjectManagerID], [ProjectBudget], [CurrentExpenses], [ProjectDeadline], [ProjectName]) VALUES (38, 1, 1, CAST(1000.00 AS Decimal(9, 2)), CAST(900.00 AS Decimal(9, 2)), CAST(N'2023-11-25' AS Date), N'Make Facebook')
INSERT [dbo].[Projects] ([ProjectID], [ProjectDept], [ProjectManagerID], [ProjectBudget], [CurrentExpenses], [ProjectDeadline], [ProjectName]) VALUES (39, 3, 16, CAST(5000.00 AS Decimal(9, 2)), CAST(0.00 AS Decimal(9, 2)), CAST(N'2023-11-27' AS Date), N'Create client website')
INSERT [dbo].[Projects] ([ProjectID], [ProjectDept], [ProjectManagerID], [ProjectBudget], [CurrentExpenses], [ProjectDeadline], [ProjectName]) VALUES (40, 4, 1, CAST(5000.00 AS Decimal(9, 2)), CAST(0.00 AS Decimal(9, 2)), CAST(N'2022-11-27' AS Date), N'New Floor')
INSERT [dbo].[Projects] ([ProjectID], [ProjectDept], [ProjectManagerID], [ProjectBudget], [CurrentExpenses], [ProjectDeadline], [ProjectName]) VALUES (41, 5, 14, CAST(1000.00 AS Decimal(9, 2)), CAST(0.00 AS Decimal(9, 2)), CAST(N'2022-12-20' AS Date), N'Make commercials')
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (2, N'admin')
INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (3, N'client')
INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (4, N'departmentHead')
INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (1, N'employee')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([TaskID], [ProjectID], [TaskBudget], [TaskName], [TaskDeadline], [TaskExpenses]) VALUES (1, 38, CAST(100.00 AS Decimal(9, 2)), N'Choose Colors', CAST(N'2022-12-01' AS Date), CAST(0.00 AS Decimal(9, 2)))
INSERT [dbo].[Tasks] ([TaskID], [ProjectID], [TaskBudget], [TaskName], [TaskDeadline], [TaskExpenses]) VALUES (2, 39, CAST(500.00 AS Decimal(9, 2)), N'Login Page', CAST(N'2022-12-20' AS Date), CAST(0.00 AS Decimal(9, 2)))
INSERT [dbo].[Tasks] ([TaskID], [ProjectID], [TaskBudget], [TaskName], [TaskDeadline], [TaskExpenses]) VALUES (3, 40, CAST(500.00 AS Decimal(9, 2)), N'Getting tiles', CAST(N'2022-12-05' AS Date), CAST(0.00 AS Decimal(9, 2)))
INSERT [dbo].[Tasks] ([TaskID], [ProjectID], [TaskBudget], [TaskName], [TaskDeadline], [TaskExpenses]) VALUES (4, 41, CAST(250.00 AS Decimal(9, 2)), N'Film employees', CAST(N'2022-12-10' AS Date), CAST(100.00 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (5, 3, N'wei', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (6, 3, N'PeterTest', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (7, 3, N'weilin', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (8, 3, N'Abishek', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (9, 3, N'jsmith', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (10, 3, N'ronaldo', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (11, 3, N'testuser', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (12, 3, N'nhi', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (14, 2, N'admin', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (15, 3, N'Leafsicle', N'1234')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (17, 3, N'client', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (18, 4, N'departmenthead', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (19, 1, N'employee', N'123')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (20, 3, N'Dante', N'1738')
INSERT [dbo].[Users] ([id], [role], [userName], [password]) VALUES (21, 1, N'Peter', N'123')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WorksOn] ON 

INSERT [dbo].[WorksOn] ([WorksOnID], [HoursWorked], [ProjectID], [EmployeeID]) VALUES (5, CAST(35.00 AS Decimal(4, 2)), 31, 11)
INSERT [dbo].[WorksOn] ([WorksOnID], [HoursWorked], [ProjectID], [EmployeeID]) VALUES (6, CAST(20.00 AS Decimal(4, 2)), 31, 14)
INSERT [dbo].[WorksOn] ([WorksOnID], [HoursWorked], [ProjectID], [EmployeeID]) VALUES (12, CAST(30.00 AS Decimal(4, 2)), 38, 16)
INSERT [dbo].[WorksOn] ([WorksOnID], [HoursWorked], [ProjectID], [EmployeeID]) VALUES (13, CAST(52.00 AS Decimal(4, 2)), 41, 14)
SET IDENTITY_INSERT [dbo].[WorksOn] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Role__B1947861058C8BC1]    Script Date: 11/27/2022 9:10:07 PM ******/
ALTER TABLE [dbo].[Role] ADD UNIQUE NONCLUSTERED 
(
	[roleName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [role]    Script Date: 11/27/2022 9:10:07 PM ******/
CREATE NONCLUSTERED INDEX [role] ON [dbo].[Role]
(
	[roleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__66DCF95C1AFD3560]    Script Date: 11/27/2022 9:10:07 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[userName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF__Projects__Curren__14270015]  DEFAULT ((0)) FOR [CurrentExpenses]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT ((0)) FOR [TaskExpenses]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((3)) FOR [role]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_UserID]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentManagerID] FOREIGN KEY([DepartmentManagerID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_DepartmentManagerID]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_UserIDEmployee] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_UserIDEmployee]
GO
ALTER TABLE [dbo].[ErrorMessages]  WITH CHECK ADD  CONSTRAINT [FK_ErrorMessages_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[ErrorMessages] CHECK CONSTRAINT [FK_ErrorMessages_ProjectID]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_ManagerID] FOREIGN KEY([ProjectManagerID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_ManagerID]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDept] FOREIGN KEY([ProjectDept])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_ProjectDept]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_TaskProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_TaskProjectID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Role] FOREIGN KEY([role])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Role]
GO
ALTER TABLE [dbo].[WorksOn]  WITH CHECK ADD  CONSTRAINT [FK_WorksOn_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[WorksOn] CHECK CONSTRAINT [FK_WorksOn_Employee]
GO
ALTER TABLE [dbo].[WorksOn]  WITH CHECK ADD  CONSTRAINT [FK_WorksOnProject] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[WorksOn] CHECK CONSTRAINT [FK_WorksOnProject]
GO
/****** Object:  StoredProcedure [dbo].[EDraft]    Script Date: 11/27/2022 9:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[EDraft]
(
    -- Add the parameters for the stored procedure here
    @hoursWorked int,
	@deptName varchar(50)
)
AS
	SELECT Employee.EmployeeID, Employee.Fname AS "First Name", Employee.Lname AS "Last Name", SUM(WorksOn.HoursWorked)/2 AS [Total Hours Worked]
	FROM Employee, WorksOn, Projects, Department
	WHERE (SELECT SUM(HoursWorked)/2 FROM WorksOn) >= @hoursWorked AND @deptName = Department.DepartmentName 
	AND Employee.DepartmentID = Department.DepartmentID 
	GROUP BY Employee.EmployeeID, Fname, Lname
	ORDER BY [Total Hours Worked] DESC;
GO
/****** Object:  StoredProcedure [dbo].[getProjectInfo]    Script Date: 11/27/2022 9:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[getProjectInfo]
	@projectID int
AS
	SELECT dbo.Projects.ProjectID AS "Project_ID",
	dbo.Projects.ProjectName AS "Project_Name", 
	dbo.Projects.ProjectDept AS "Department_Code",
	(ProjectBudget - CurrentExpenses) AS "Budget_Balance",
	 (SELECT COUNT(dbo.tasks.TaskID)
		FROM dbo.tasks
		WHERE dbo.tasks.ProjectID = @projectID) 
		AS "Amount_of_Related_Tasks"

	FROM dbo.Projects, dbo.tasks
	WHERE dbo.Projects.ProjectID = @projectID AND dbo.tasks.ProjectID = @projectID
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[getTaskInfo]    Script Date: 11/27/2022 9:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getTaskInfo]

	@projectCode int

AS
	SELECT 
	dbo.Tasks.TaskName AS "Task",
	dbo.Tasks.TaskBudget AS "Budget",
	dbo.Tasks.TaskDeadline AS "Deadline",
	dbo.Projects.ProjectName AS "Project Name",

	(Select Department.DepartmentName WHERE
		dbo.Projects.ProjectDept = dbo.Department.DepartmentID AND Projects.ProjectID = @projectCode) AS "Department Name" 


	FROM dbo.tasks, dbo.Projects, dbo.Department
	WHERE dbo.Tasks.ProjectID = @projectCode AND Projects.ProjectID = @projectCode AND Projects.ProjectDept = Department.DepartmentID;
GO
/****** Object:  StoredProcedure [dbo].[getTopEmployees]    Script Date: 11/27/2022 9:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getTopEmployees]
	@hoursWorked int,
	@deptName varchar(50)
	/*@projName varchar(30)*/
AS
	SELECT Employee.EmployeeID, Employee.Fname AS "First Name", Employee.Lname AS "Last Name", SUM(WorksOn.HoursWorked)/2 AS [Total Hours Worked]
	FROM Employee, WorksOn, Projects, Department
	WHERE (SELECT SUM(HoursWorked)/2 FROM WorksOn WHERE WorksOn.EmployeeID = Employee.EmployeeID) >= @hoursWorked/2 
	AND @deptName = Department.DepartmentName 
	AND Employee.DepartmentID = Department.DepartmentID 
	AND  WorksOn.EmployeeID = Employee.EmployeeID
	GROUP BY Employee.EmployeeID, Fname, Lname
	ORDER BY [Total Hours Worked] DESC;
GO
/****** Object:  StoredProcedure [dbo].[projectDraft]    Script Date: 11/27/2022 9:10:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[projectDraft]
	@projectID int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * FROM [dbo].[Projects]
	WHERE ProjectID = @projectID
END
GO
ALTER DATABASE [team18db] SET  READ_WRITE 
GO
