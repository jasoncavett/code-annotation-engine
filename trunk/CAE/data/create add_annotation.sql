USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_annotation]    Script Date: 02/25/2010 23:23:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('add_annotation') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.add_annotation
    PRINT '<<< DROPPED PROCEDURE add_annotation>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<Adds a new annotation to an existing
--              codefile and reviewer>
-- Input Parameters:
--		project_nm
--		codefile_nm
--		codefile_line_no
--		rvwr_last_nm
--		rvwr_first_nm
--		annotation_txt
-- =============================================
CREATE PROCEDURE [dbo].[add_annotation]
	 @project_nm varchar(20) 
	,@codefile_nm varchar(50)
	,@codefile_line_no int
	,@rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
	,@annotation_txt varchar(2000)
AS
BEGIN
	DECLARE
		 @project_exists char(1)
		,@codefile_exists char(1)
		,@reviewer_exists char(1)

	SET NOCOUNT ON;

	SET @project_exists = 'N';
	SET @codefile_exists = 'N';
	SET @reviewer_exists = 'N';

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
				FROM dbo.Codefile
				WHERE project_nm = @project_nm
							AND
					  codefile_nm = @codefile_nm
				)
				> 0
				SET @codefile_exists = 'Y'
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
			@codefile_exists = 'Y'
			BEGIN
			IF

				@reviewer_exists = 'Y'
				BEGIN
					BEGIN TRY
						INSERT INTO
							dbo.Review_annotation
							(
							 project_nm
							,codefile_nm
							,codefile_line_no
							,rvwr_last_nm
							,rvwr_first_nm
							,annotation_txt
							,last_update_dtm
							)
						VALUES
							(
				 			 @project_nm
							,@codefile_nm 
							,@codefile_line_no
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
				RAISERROR (N'Add Failed: Reviewer Not Found',18,18)
		END
	ELSE
		RAISERROR (N'Add Failed: Codefile Not Found',18,18)
	END
ELSE
	RAISERROR (N'Add Failed: Project Not Found',18,18)
END
