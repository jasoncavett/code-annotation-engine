USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_file]    Script Date: 02/25/2010 23:23:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('add_file') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.add_file
    PRINT '<<< DROPPED PROCEDURE add_file>>>'
END
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<Adds a new codefile
-- Input parameters:
--		project_nm
--		codefile_nm
-- =============================================
CREATE PROCEDURE [dbo].[add_file]
	 @project_nm varchar(20) 
	,@codefile_nm varchar(50)
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
					dbo.Codefile
					(
					 project_nm		 
					,codefile_nm
					,last_update_dtm
					)
				VALUES
					(
					 @project_nm
					,@codefile_nm
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
					RAISERROR (N'Add Failed: Module Already Exists',18,18)
				ELSE
					RAISERROR (@err_msg, @err_sev, @err_state)
			END CATCH;	
		END
	ELSE
		RAISERROR (N'Add Failed: Project Not Found',18,18)
END
