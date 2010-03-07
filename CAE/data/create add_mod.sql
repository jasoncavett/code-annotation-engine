USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_mod]    Script Date: 03/06/2010 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('add_mod') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.add_mod
    PRINT '<<< DROPPED PROCEDURE add_mod>>>'
END
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<Adds a new module>
-- Input parameters:
--		project_nm
--		module_nm
--		module_desc
--		lang
--		author_last_nm
--		author_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[add_mod]
	 @project_nm varchar(20) 
	,@module_nm varchar(50)
	,@module_desc varchar(256)
	,@lang varchar(10)
	,@author_last_nm varchar(20)
	,@author_first_nm varchar(20)
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
					dbo.Module
					(
					 project_nm		 
					,module_nm
					,module_desc
					,lang
					,author_last_nm
					,author_first_nm
					,last_update_dtm
					)
				VALUES
					(
					 @project_nm
					,@module_nm
					,@module_desc
					,@lang
					,@author_last_nm
					,@author_first_nm
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
