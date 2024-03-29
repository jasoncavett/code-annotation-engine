USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[merge_proj_annotations]    Script Date: 02/17/2010 00:15:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('merge_proj_annotations') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.merge_proj_annotations
    PRINT '<<< DROPPED PROCEDURE merge_proj_annotations>>>'
END
GO
/****** Object:  StoredProcedure [dbo].[merge_proj_annotations]    Script Date: 04/07/2010 18:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Mar. 27, 2010>
-- Description:	<Merges annotations from Import_stage table for a specific project>
-- Input Parameters:
--		rvwr_last_nm
--		rvwr_first_nm
--		project_nm
-- =============================================
CREATE PROCEDURE [dbo].[merge_proj_annotations]
	 @rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
	,@project_nm varchar(20)
AS
	DECLARE @err_msg nvarchar(4000);
	DECLARE @err_sev int;
	DECLARE @err_state int;
	DECLARE @codefile_nm varchar(50);
	DECLARE @codefile_line_no int;
	DECLARE @other_rvwr_last_nm varchar(20);
	DECLARE @other_rvwr_first_nm varchar(20);
	DECLARE @annotation_color varchar(15);
	DECLARE @annotation_txt varchar(2000);

BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		DELETE
		FROM 
			dbo.Review_annotation
		WHERE
			@project_nm = @project_nm
					AND
			(rvwr_last_nm <> @rvwr_last_nm
					OR
			 rvwr_first_nm <> @rvwr_first_nm)
	END TRY

	BEGIN CATCH
		SELECT @err_msg = ERROR_MESSAGE();
		SELECT @err_sev = ERROR_SEVERITY();
		SELECT @err_state = ERROR_STATE();

		RAISERROR (@err_msg,@err_sev,@err_state)
	END CATCH;	

	IF
		(
		SELECT
			COUNT(*)
		FROM
			dbo.Project
		WHERE 
			project_nm = @project_nm
		)
		= 0
	EXEC dbo.add_project @project_nm

	DECLARE csr_codefile CURSOR READ_ONLY FOR
		SELECT
			DISTINCT
				 project_nm
				,codefile_nm
			FROM
				dbo.Import_Stage

	OPEN csr_codefile

	FETCH NEXT
		FROM
			csr_codefile
		INTO
			 @project_nm
			,@codefile_nm

	WHILE @@FETCH_STATUS = 0
		BEGIN
			IF
			(
			SELECT
				COUNT(*)
			FROM
				dbo.Codefile
			WHERE 
				project_nm = @project_nm
						AND
				codefile_nm = @codefile_nm
			)
			= 0
			EXEC dbo.add_file @project_nm, @codefile_nm

			FETCH NEXT
				FROM
					csr_codefile
				INTO
					 @project_nm
					,@codefile_nm
		END

	CLOSE csr_codefile
	DEALLOCATE csr_codefile

	SELECT @annotation_color = 'default';
	DECLARE csr_reviewer CURSOR READ_ONLY FOR
		SELECT
			DISTINCT
				 project_nm
				,rvwr_last_nm
				,rvwr_first_nm
			FROM
				dbo.Import_Stage

	OPEN csr_reviewer

	FETCH NEXT
		FROM
			csr_reviewer
		INTO
			 @project_nm
			,@other_rvwr_last_nm
			,@other_rvwr_first_nm

	WHILE @@FETCH_STATUS = 0
		BEGIN
			IF
			(
			SELECT
				COUNT(*)
			FROM
				dbo.Reviewer
			WHERE 
				project_nm = @project_nm
						AND
				rvwr_last_nm = @other_rvwr_last_nm
						AND
				rvwr_first_nm = @other_rvwr_first_nm
			)
			= 0
			EXEC dbo.add_reviewer @project_nm, @other_rvwr_last_nm, @other_rvwr_first_nm, @annotation_color 
	
			FETCH NEXT
				FROM
					csr_reviewer
				INTO
					 @project_nm
					,@other_rvwr_last_nm
					,@other_rvwr_first_nm
		END

	CLOSE csr_reviewer
	DEALLOCATE csr_reviewer

	BEGIN TRY
		INSERT
			Review_annotation
			SELECT
				*
			FROM 
				dbo.Import_Stage
			WHERE
				rvwr_last_nm <> @rvwr_last_nm
						OR
				rvwr_first_nm <> @rvwr_first_nm
	END TRY

	BEGIN CATCH
		SELECT @err_msg = ERROR_MESSAGE();
		SELECT @err_sev = ERROR_SEVERITY();
		SELECT @err_state = ERROR_STATE();
		RAISERROR (@err_msg,@err_sev,@err_state)
	END CATCH;

	DECLARE csr_annotation CURSOR READ_ONLY FOR
		SELECT
			 project_nm
			,codefile_nm
			,codefile_line_no
			,annotation_txt
			FROM
				dbo.Import_Stage
			WHERE
				rvwr_last_nm = @rvwr_last_nm
						AND
				rvwr_first_nm = @rvwr_first_nm

	OPEN csr_annotation

	FETCH NEXT
		FROM
			csr_annotation
		INTO
			 @project_nm
			,@codefile_nm
			,@codefile_line_no
			,@annotation_txt

	WHILE @@FETCH_STATUS = 0
		BEGIN
			IF
			(
			SELECT
				COUNT(*)
			FROM
				dbo.Review_annotation
			WHERE 
				project_nm = @project_nm
						AND
				codefile_nm = @codefile_nm
						AND
				codefile_line_no = @codefile_line_no
						AND
				rvwr_last_nm = @rvwr_last_nm
						AND
				rvwr_first_nm = @rvwr_first_nm
			)
			= 0
			EXEC dbo.add_annotation @project_nm, @codefile_nm, @codefile_line_no, @rvwr_last_nm, @rvwr_first_nm, @annotation_txt 
	
		FETCH NEXT
			FROM
				csr_annotation
			INTO
				 @project_nm
				,@codefile_nm
				,@codefile_line_no
				,@annotation_txt
		END

	CLOSE csr_annotation
	DEALLOCATE csr_annotation

END	





