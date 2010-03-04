USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_project]    Script Date: 03/03/2010 23:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('add_project') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.add_project
    PRINT '<<< DROPPED PROCEDURE add_project>>>'
END
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 27, 2010>
-- Description:	<Adds a new project>
-- Input parameters:
--		project_nm
--		project_desc
-- =============================================
CREATE PROCEDURE [dbo].[add_project]
	 @project_nm varchar(20)
	,@project_desc varchar(256)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO
		dbo.Project
		(
		 project_nm		 
		,project_desc
		,last_update_dtm
		)
	VALUES
		(
		 @project_nm
		,@project_desc
		,getdate()
		)
END
