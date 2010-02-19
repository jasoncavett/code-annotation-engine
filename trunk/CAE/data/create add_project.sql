USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_project]    Script Date: 02/18/2010 19:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('add_project') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.add_project
    PRINT '<<< DROPPED PROCEDURE add_project>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
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
