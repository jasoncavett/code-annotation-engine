USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_project]    Script Date: 02/25/2010 23:23:10 ******/
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
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO
			dbo.Project
			(
			 project_nm		 
			,last_update_dtm
			)
		VALUES
			(
			 @project_nm
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
			RAISERROR (N'Add Failed: Project Already Exists',18,18)
		ELSE
			RAISERROR (@err_msg, @err_sev, @err_state)
	END CATCH;	
END
