USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_reviewer]    Script Date: 03/03/2010 23:44:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('add_reviewer') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.add_reviewer
    PRINT '<<< DROPPED PROCEDURE add_reviewer>>>'
END
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 27, 2010>
-- Description:	<Adds a new reviewer>
-- Input parameters:
--		project_nm
--		rvwr_last_nm
--		rvwr_first_nm
--		job_title
--		annotation_color
--		annotation_font
--		annotation_font_wt
-- =============================================
CREATE PROCEDURE [dbo].[add_reviewer]
	 @project_nm varchar(20)
	,@rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
	,@job_title varchar(30)
	,@annotation_color varchar(15)
	,@annotation_font varchar(20)
	,@annotation_font_wt varchar(15)
AS
BEGIN
	DECLARE
		@project_exists char(1)
	SET NOCOUNT ON;
	IF
		(
		SELECT COUNT(*)
		FROM dbo.Project
		WHERE project_nm = @project_nm
		)
		> 0
		SET @project_exists = 'Y'
	ELSE
		SET @project_exists = 'N'

	IF 
		@project_exists = 'Y'
		BEGIN
			INSERT INTO
				dbo.Reviewer
				(
				 project_nm		 
				,rvwr_last_nm
				,rvwr_first_nm
				,job_title
				,annotation_color
				,annotation_font
				,annotation_font_wt
				,last_update_dtm
				)
			VALUES
				(
				 @project_nm 
				,@rvwr_last_nm
				,@rvwr_first_nm 
				,@job_title
				,@annotation_color
				,@annotation_font
				,@annotation_font_wt
				,getdate()
				)
		END	
	ELSE
		RAISERROR (N'Project Not Found',18,18)
END
