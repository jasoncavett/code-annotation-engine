USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_annotation]    Script Date: 03/31/2010 19:07:10 ******/
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
	DECLARE @annotation_color varchar(15);
BEGIN

	SET NOCOUNT ON;

	IF
		(
		SELECT COUNT(*)
		FROM dbo.Project
		WHERE project_nm = @project_nm
		)
		= 0
		EXEC dbo.add_project @project_nm

	IF
		(
		SELECT COUNT(*)
		FROM dbo.Codefile
		WHERE project_nm = @project_nm
					AND
			  codefile_nm = @codefile_nm
		)
		= 0
		EXEC dbo.add_file @project_nm, @codefile_nm

		SELECT @annotation_color = 'default';
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
		= 0
		EXEC dbo.add_reviewer @project_nm, @rvwr_last_nm, @rvwr_first_nm, @annotation_color 

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
