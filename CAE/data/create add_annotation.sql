USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_annotation]    Script Date: 03/06/2010 18:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('add_annotation') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.add_annotation
    PRINT '<<< DROPPED PROCEDURE add_annotation>>>'
END
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<Adds a new annotation to an existing
--              module revision for a review event >
-- Input Parameters:
--		project_nm
--		module_nm
--		revision_no
--		module_line_no
--		rvw_event_dt
--		rvwr_last_nm
--		rvwr_first_nm
--		annotation_txt
-- =============================================
CREATE PROCEDURE [dbo].[add_annotation]
	 @project_nm varchar(20) 
	,@module_nm varchar(50)
	,@revision_no numeric(6,3)
	,@module_line_no int
	,@rvw_event_dt datetime
	,@rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
	,@annotation_txt varchar(2000)
AS
BEGIN
	DECLARE
		 @project_exists char(1)
		,@module_exists char(1)
		,@module_revision_exists char(1)
		,@reviewer_exists char(1)
		,@review_event_exists char(1)

	SET NOCOUNT ON;

	SET @project_exists = 'N';
	SET @module_exists = 'N';
	SET @module_revision_exists = 'N';
	SET @reviewer_exists = 'N';
	SET @review_event_exists = 'N';

	IF
		(
		SELECT COUNT(*)
		FROM dbo.Project
		WHERE project_nm = @project_nm
		)
		> 0
		SET @project_exists = 'Y'

	IF
		@project_exists = 'Y'
		BEGIN
			IF
				(
				SELECT COUNT(*)
				FROM dbo.Module
				WHERE project_nm = @project_nm
							AND
					  module_nm = @module_nm
				)
				> 0
				SET @module_exists = 'Y'
		END

	IF
		@module_exists = 'Y'
		BEGIN
		IF
			(
			SELECT COUNT(*)
				FROM dbo.Module_revision
				WHERE project_nm = @project_nm
							AND
					  module_nm = @module_nm
							AND
					  revision_no = @revision_no
			)
			> 0
			SET @module_revision_exists = 'Y'
		END

	IF
		@module_revision_exists = 'Y'
		BEGIN
		IF
			(
			SELECT COUNT(*)
				FROM dbo.Review_event
				WHERE project_nm = @project_nm
							AND
					  module_nm = @module_nm
							AND
					  revision_no = @revision_no
							AND
					  rvw_event_dt = @rvw_event_dt
			)
			> 0
			SET @review_event_exists = 'Y'
		END	
	
	IF
		@project_exists = 'Y'
		BEGIN
			IF
				(
				SELECT COUNT(*)
				FROM dbo.Reviewer
				WHERE project_nm = @project_nm
							AND
					  rvwr_last_nm = @rvwr_last_nm
							AND
					  rvwr_first_nm = @rvwr_first_nm
				)
				> 0
				SET @reviewer_exists = 'Y'
		END

	IF
		@project_exists = 'Y'
		BEGIN
		IF
			@module_exists = 'Y'
			BEGIN
			IF
				@module_revision_exists = 'Y'
				BEGIN
				IF
					@reviewer_exists = 'Y'
					BEGIN
					IF
						@review_event_exists = 'Y'
						BEGIN
							BEGIN TRY
							INSERT INTO
								dbo.Review_annotation
								(
								 project_nm
								,module_nm
								,revision_no
								,module_line_no
								,rvw_event_dt
								,rvwr_last_nm
								,rvwr_first_nm
								,annotation_txt
								,last_update_dtm
								)
							VALUES
								(
					 			 @project_nm
								,@module_nm
								,@revision_no 
								,@module_line_no
								,@rvw_event_dt
								,@rvwr_last_nm
								,@rvwr_first_nm
								,@annotation_txt
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
									RAISERROR (N'Add Failed: This Annotation Already Exists',18,18)
								ELSE
									RAISERROR (@err_msg,@err_sev,@err_state)
							END CATCH;	
						END
					ELSE
						RAISERROR (N'Add Failed: Review Event Not Found',18,18)
					END
				ELSE
					RAISERROR (N'Add Failed: Reviewer Not Found',18,18)
				END
			ELSE
				RAISERROR (N'Add Failed: Module Revision Not Found',18,18)
			END
		ELSE
			RAISERROR (N'Add Failed: Module Not Found',18,18)
		END
	ELSE
		RAISERROR (N'Add Failed: Project Not Found',18,18)
END
