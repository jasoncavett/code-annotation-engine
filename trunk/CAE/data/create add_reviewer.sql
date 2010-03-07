USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_reviewer]    Script Date: 03/06/2010 18:59:06 ******/
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
			BEGIN TRY
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
			END TRY
			BEGIN CATCH
				DECLARE @err_msg nvarchar(4000);
				DECLARE @err_sev int;
				DECLARE @err_state int;

				SELECT @err_msg = ERROR_MESSAGE();
				SELECT @err_sev = ERROR_SEVERITY();
				SELECT @err_state = ERROR_STATE();

				IF ERROR_NUMBER() = 2627
					RAISERROR (N'Add Failed: Reviewer Already Exists',18,18)
				ELSE
					RAISERROR (@err_msg, @err_sev, @err_state)
			END CATCH;	
		END	
	ELSE
		RAISERROR (N'Add Failed: Project Not Found',18,18)
END
