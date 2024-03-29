USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[get_mod_rev]    Script Date: 02/17/2010 00:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('get_mod_rev') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.get_mod_rev
    PRINT '<<< DROPPED PROCEDURE get_mod_rev>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves a specific revision for a module>
-- Input Parameters:
--		project_nm
--		module_nm
--		revision_no
-- =============================================
CREATE PROCEDURE [dbo].[get_mod_rev]
	 @project_nm varchar(20) 
	,@module_nm varchar(50)
	,@revision_no numeric(6,3)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 mod.project_nm
		,mod.module_nm
		,mod.module_desc
		,mod.lang
		,mod.author_last_nm
		,mod.author_first_nm
		,mod.last_update_dtm
		,rev.revision_no
		,rev.chg_desc
		,rev.devlpr_last_nm
		,rev.devlpr_first_nm
		,rev.last_update_dtm
	FROM
		dbo.Module mod
	INNER JOIN
		dbo.Module_revision rev
	ON
		mod.module_nm = rev.module_nm
	WHERE
		mod.project_nm = @project_nm
				AND
		mod.module_nm = @module_nm
				AND
		rev.revision_no = @revision_no
END


