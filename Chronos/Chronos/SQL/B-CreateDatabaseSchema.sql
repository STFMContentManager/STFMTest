-------------------------------------------------------------------------------
--	B-CreateDatabaseSchema.sql
--	This SQL script creates the database schema for ChronosDB.
-------------------------------------------------------------------------------
USE [ChronosDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProjects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[CostCentre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblProjects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEvents]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvents](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[ErrNo] [int] NULL,
	[ErrLine] [int] NULL,
	[Severity] [int] NULL,
	[State] [int] NULL,
	[ErrorMsg] [varchar](2048) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[GetDayName]    Script Date: 08/27/2007 05:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	Returns the day name for the specified date. If @Short = 1 then the day name
--	is truncated to 3 characters.
CREATE FUNCTION [dbo].[GetDayName]
(
	@DateVal					DATETIME,
	@Short					BIT
)
RETURNS
	VARCHAR(12)
AS
BEGIN
	DECLARE	@DayName				VARCHAR(12)
	
	IF @Short = 1
		SET @DayName = SUBSTRING(DATENAME(dw, @DateVal), 1, 3)
	ELSE
		SET @DayName = DATENAME(dw, @DateVal)
	
	RETURN @DayName
END
GO
/****** Object:  Table [dbo].[tblTeams]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTeams](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblTeams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserGroups]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserGroups](
	[UserGroupId] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupName] [varchar](50) NOT NULL,
	[UserGroupPermissions] [int] NOT NULL,
 CONSTRAINT [PK_tblUserGroups] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAttributes]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAttributes](
	[AttributeId] [int] IDENTITY(1,1) NOT NULL,
	[AttributeName] [varchar](50) NOT NULL,
	[AttributeValue] [varchar](250) NOT NULL,
 CONSTRAINT [PK_tblAttributes] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblStatus]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusText] [varchar](50) NOT NULL,
	[SortOrder] [smallint] NOT NULL,
 CONSTRAINT [PK_tblStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTasks]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[TaskName] [varchar](50) NOT NULL,
	[CostCentre] [varchar](50) NOT NULL,
	[Description] [varchar](1024) NOT NULL,
	[ReferenceRegEx] [varchar](50) NOT NULL,
	[IsProductive] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[ValidationType] [smallint] NOT NULL,
 CONSTRAINT [PK_tblTasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMapProjectToUser]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMapProjectToUser](
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUsers](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NULL,
	[UserGroupId] [int] NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Forename] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[HourlyRate] [smallmoney] NOT NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTime]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTime](
	[TimeId] [int] IDENTITY(1,1) NOT NULL,
	[DateVal] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Comment] [varchar](250) NOT NULL,
	[JobRef] [varchar](20) NULL,
	[Hours] [money] NOT NULL,
	[Locked] [bit] NULL,
 CONSTRAINT [PK_tblTime] PRIMARY KEY CLUSTERED 
(
	[TimeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblJobs]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblJobs](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[JobRef] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[BudgetHours] [money] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_tblJobs] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[SumHoursForUser]    Script Date: 08/27/2007 05:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	Returns either profitable or unprofitable hours for user between 2 dates.
CREATE FUNCTION [dbo].[SumHoursForUser]
(
	@UserId				INTEGER,
	@DateStart			DATETIME,
	@DateEnd				DATETIME,
	@Productive			BIT
)
RETURNS
	FLOAT
AS
BEGIN
	DECLARE	@RetVal			FLOAT
	
	SET @RetVal = (SELECT SUM(HOURS) FROM tblTime
	WHERE (UserId = @UserId) AND
		(DateVal BETWEEN @DateStart AND @DateEnd) AND
		(TaskId IN (SELECT TaskId FROM tblTasks
			WHERE (IsProductive = @Productive))))

	RETURN ISNULL(@RetVal, 0)
END
GO
/****** Object:  UserDefinedFunction [dbo].[TotalHoursForUser]    Script Date: 08/27/2007 05:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	Returns the total number of hours booked between 2 dates for a user.
CREATE FUNCTION [dbo].[TotalHoursForUser]
(
	@UserId				INTEGER,
	@DateStart			DATETIME,
	@DateEnd				DATETIME
)
RETURNS
	FLOAT
AS
BEGIN
	DECLARE	@RetVal			FLOAT
	
	SET @RetVal = (SELECT SUM(HOURS) FROM tblTime
		WHERE (UserId = @UserId) AND (DateVal BETWEEN @DateStart AND @DateEnd))
	
	RETURN ISNULL(@RetVal, 0)
END
GO
/****** Object:  StoredProcedure [dbo].[SaveTimeRecord]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	This stored procedure saves one time record, which can be a new record or an
--	update to an existing record depending upon @TimeId.
CREATE PROCEDURE [dbo].[SaveTimeRecord]
(
	@TimeId				INT OUTPUT,
	@DateVal			DATETIME,
	@UserId				INT,
	@ProjectId			INT,
	@TaskId				INT,
	@StatusId			INT,
	@Comment			VARCHAR(250),
	@JobRef				VARCHAR(20),
	@Hours				MONEY,
	@Locked				BIT
)
AS
BEGIN
	IF (@TimeId = 0)
	BEGIN
		--	Insert new time record.
		
		INSERT INTO tblTime
		(
			DateVal,
			UserId,
			ProjectId,
			TaskId,
			StatusId,
			Comment,
			JobRef,
			Hours,
			Locked
		)
		VALUES
		(
			@DateVal,
			@UserId,
			@ProjectId,
			@TaskId,
			@StatusId,
			@Comment,
			@JobRef,
			@Hours,
			@Locked
		)
		
		SET @TimeId = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		--	Update time record.
		
		UPDATE tblTime SET
			DateVal = @DateVal,
			UserId = @UserId,
			ProjectId = @ProjectId,
			TaskId = @TaskId,
			StatusId = @StatusId,
			Comment = @Comment,
			JobRef = @JobRef,
			Hours = @Hours,
			Locked = @Locked
			WHERE (TimeId = @TimeId)
	END
	
	RETURN @TimeId
END
GO
/****** Object:  UserDefinedFunction [dbo].[CostCentrePercent]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	This UDF calculates the percentage hours spent on the cost, for all
--	hours within the time period.
CREATE FUNCTION [dbo].[CostCentrePercent]
(
	@CostCentre				VARCHAR(50),
	@DateStart				DATETIME,
	@DateEnd					DATETIME
)
RETURNS
	FLOAT
AS
BEGIN
	DECLARE	@ReturnVal			FLOAT
	DECLARE	@Numerator			FLOAT
	DECLARE	@Denominator		FLOAT
	
	SELECT @Numerator = ISNULL(SUM(Hours), 0)
	FROM tblTime AS A
	INNER JOIN tblTasks AS B ON B.TaskId = A.TaskId
	WHERE (A.DateVal BETWEEN @DateStart AND @DateEnd) AND
		(B.CostCentre = @CostCentre)
	
	SELECT @Denominator = ISNULL(SUM(Hours), 0)
	FROM tblTime AS A
	INNER JOIN tblTasks AS B ON B.TaskId = A.TaskId
	WHERE (A.DateVal BETWEEN @DateStart AND @DateEnd)
	
	IF @Denominator = 0
		SET @ReturnVal = 0
	ELSE
		SET @ReturnVal = (100 * @Numerator) / @Denominator
	
	RETURN ROUND(@ReturnVal, 2)
END
GO
/****** Object:  UserDefinedFunction [dbo].[UserProductivity]    Script Date: 08/27/2007 05:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	This UDF returns the percentage productive time for a user in a given date
--	range.
CREATE FUNCTION [dbo].[UserProductivity]
(
	@UserId				INTEGER,
	@DateStart			DATETIME,
	@DateEnd				DATETIME
)
RETURNS
	FLOAT
AS
BEGIN
	DECLARE	@SlackTime			FLOAT
	DECLARE	@ProductiveTime	FLOAT
	DECLARE	@ReturnVal			FLOAT
	
	SELECT @SlackTime = ISNULL(SUM(Hours), 0.0) FROM tblTime
		WHERE (UserId = @UserId) AND
			(DateVal BETWEEN @DateStart AND @DateEnd) AND
			(TaskId IN (SELECT TaskId FROM tblTasks
				WHERE (IsProductive = 0)))
	
	SELECT @ProductiveTime = ISNULL(SUM(Hours), 0.0) FROM tblTime
		WHERE (UserId = @UserId) AND
			(DateVal BETWEEN @DateStart AND @DateEnd) AND
			(TaskId IN (SELECT TaskId FROM tblTasks
				WHERE (IsProductive = 1)))
	
	IF (@SlackTime + @ProductiveTime) = 0
	BEGIN
		SET @ReturnVal = 0.0
	END
	ELSE
	BEGIN
		SET @ReturnVal = 100.0 * @ProductiveTime / (@SlackTime + @ProductiveTime)
	END
	
	RETURN ROUND(@ReturnVal, 2)
END
GO
/****** Object:  StoredProcedure [dbo].[SaveUser]    Script Date: 08/27/2007 05:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	This stored procedure is responsible for saving a user definition.
CREATE PROCEDURE [dbo].[SaveUser]
(
	@UserId				INTEGER,
	@TeamId				INTEGER,
	@UserGroupId		INTEGER,
	@UserName			VARCHAR(20),
	@Password			VARCHAR(100),
	@Surname				VARCHAR(50),
	@Forename			VARCHAR(50),
	@EmailAddress		VARCHAR(100),
	@HourlyRate			SMALLMONEY,
	@ReturnVal			INTEGER OUTPUT
)
AS
BEGIN
	IF @UserId = 0
	BEGIN
		--	Add new user. First make sure that this username isn't already in use.
		
		DECLARE	@NewUserId			INTEGER
		
		SELECT @NewUserId = UserId FROM tblUsers WHERE UserName = @UserName
		
		IF @NewUserId IS NOT NULL
		BEGIN
			--	User name already exists. This is an error.
			
			SET @ReturnVal = -1
		END
		ELSE
		BEGIN
			--	User name does not already exist.
			
			INSERT INTO tblUsers
			(
				TeamId,
				UserGroupId,
				UserName,
				Password,
				Surname,
				Forename,
				EmailAddress,
				HourlyRate
			)
			VALUES
			(
				@TeamId,
				@UserGroupId,
				@UserName,
				@Password,
				@Surname,
				@Forename,
				@EmailAddress,
				@HourlyRate
			)
			
			SET @ReturnVal = SCOPE_IDENTITY()
		END
	END
	ELSE
	BEGIN
		--	Update existing user.
		
		SELECT @NewUserId = UserId FROM tblUsers WHERE UserId = @UserId
		
		IF @NewUserId IS NULL
		BEGIN
			--	This user ID doesn't exist.
			
			SET @ReturnVal = -2
		END
		ELSE
		BEGIN
			--	User ID does exist.
			
			UPDATE tblUsers SET
				TeamId = @TeamId,
				UserGroupId = @UserGroupId,
				UserName = @UserName,
				Password = @Password,
				Surname = @Surname,
				Forename = @Forename,
				EmailAddress = @EmailAddress,
				HourlyRate = @HourlyRate
			WHERE UserId = @UserId
			
			SET @ReturnVal = @UserId
		END
	END
	
	RETURN @ReturnVal
END
GO
/****** Object:  UserDefinedFunction [dbo].[PercentProductiveForUser]    Script Date: 08/27/2007 05:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	Returns the percentage of productive hours for a user within 2 dates.
CREATE FUNCTION [dbo].[PercentProductiveForUser]
(
	@UserId				INTEGER,
	@DateStart			DATETIME,
	@DateEnd				DATETIME
)
RETURNS
	FLOAT
AS
BEGIN
	DECLARE	@RetVal			FLOAT
	DECLARE	@TotalHours		FLOAT
	DECLARE	@Productive		FLOAT
	
	SET @TotalHours = dbo.TotalHoursForUser(@UserId, @DateStart, @DateEnd)
	
	IF @TotalHours <> 0
	BEGIN
		SET @Productive = dbo.SumHoursForUser(@UserId, @DateStart, @DateEnd, 1)
		
		SET @RetVal = (100 * @Productive) / @TotalHours
	END
	
	RETURN ISNULL(@RetVal, 0)
END
GO
/****** Object:  ForeignKey [FK_tblJobs_tblTasks]    Script Date: 08/27/2007 05:42:19 ******/
ALTER TABLE [dbo].[tblJobs]  WITH CHECK ADD  CONSTRAINT [FK_tblJobs_tblTasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[tblTasks] ([TaskId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblJobs] CHECK CONSTRAINT [FK_tblJobs_tblTasks]
GO
/****** Object:  ForeignKey [FK_tblMapProjectToUser_tblProjects]    Script Date: 08/27/2007 05:42:19 ******/
ALTER TABLE [dbo].[tblMapProjectToUser]  WITH CHECK ADD  CONSTRAINT [FK_tblMapProjectToUser_tblProjects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[tblProjects] ([ProjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblMapProjectToUser] CHECK CONSTRAINT [FK_tblMapProjectToUser_tblProjects]
GO
/****** Object:  ForeignKey [FK_tblMapProjectToUser_tblUsers]    Script Date: 08/27/2007 05:42:19 ******/
ALTER TABLE [dbo].[tblMapProjectToUser]  WITH CHECK ADD  CONSTRAINT [FK_tblMapProjectToUser_tblUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUsers] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblMapProjectToUser] CHECK CONSTRAINT [FK_tblMapProjectToUser_tblUsers]
GO
/****** Object:  ForeignKey [FK_tblTasks_tblProjects]    Script Date: 08/27/2007 05:42:19 ******/
ALTER TABLE [dbo].[tblTasks]  WITH CHECK ADD  CONSTRAINT [FK_tblTasks_tblProjects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[tblProjects] ([ProjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTasks] CHECK CONSTRAINT [FK_tblTasks_tblProjects]
GO
/****** Object:  ForeignKey [FK_tblTime_tblTasks]    Script Date: 08/27/2007 05:42:19 ******/
ALTER TABLE [dbo].[tblTime]  WITH CHECK ADD  CONSTRAINT [FK_tblTime_tblTasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[tblTasks] ([TaskId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTime] CHECK CONSTRAINT [FK_tblTime_tblTasks]
GO
/****** Object:  ForeignKey [FK_tblTime_tblUsers]    Script Date: 08/27/2007 05:42:19 ******/
ALTER TABLE [dbo].[tblTime]  WITH CHECK ADD  CONSTRAINT [FK_tblTime_tblUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUsers] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTime] CHECK CONSTRAINT [FK_tblTime_tblUsers]
GO
/****** Object:  ForeignKey [FK_tblUsers_tblTeams]    Script Date: 08/27/2007 05:42:19 ******/
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblTeams] FOREIGN KEY([TeamId])
REFERENCES [dbo].[tblTeams] ([TeamId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblTeams]
GO
