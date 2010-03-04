USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_mod]    Script Date: 03/03/2010 23:42:44 ******/
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
		END
	ELSE
		RAISERROR (N'Project Not Found',18,18)
END
