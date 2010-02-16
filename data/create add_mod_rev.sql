USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_mod_rev]    Script Date: 02/15/2010 22:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<Adds a new revision to an existing module>
-- Input parameters:
--		module_nm
--		revision_no
--		chg_desc
--		devlpr_last_nm
--		devlpr_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[add_mod_rev] 
	 @module_nm varchar(50)
	,@revision_no numeric(6,3)
	,@chg_desc varchar(256)
	,@devlpr_last_nm varchar(20)
	,@devlpr_first_nm varchar(20)
AS
BEGIN
	DECLARE
		@module_exists char(1)
	SET NOCOUNT ON;
	IF
		(
		SELECT COUNT(*)
		FROM dbo.Module
		WHERE module_nm = @module_nm
		)
		> 0
		SET @module_exists = 'Y'
	ELSE
		SET @module_exists = 'N'

	IF 
		@module_exists = 'Y'
		BEGIN
			INSERT INTO
				dbo.Module_revision
				(
				 module_nm
				,revision_no 
				,chg_desc
				,devlpr_last_nm
				,devlpr_first_nm
				,last_update_dtm
				)
			VALUES
				(
				 @module_nm
				,@revision_no 
				,@chg_desc 
				,@devlpr_last_nm 
				,@devlpr_first_nm 
				,getdate()
				)
		END
	ELSE
		RAISERROR (N'Module Not Found',18,18)
END
