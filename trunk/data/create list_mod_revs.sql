USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_mod_revs]    Script Date: 02/15/2010 20:53:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves all revisions for a module>
-- Input Parameters:
--		module_nm
-- =============================================
CREATE PROCEDURE [dbo].[list_mod_revs] 
	@module_nm varchar(50) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 mod.module_nm
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
		mod.module_nm = @module_nm
	ORDER BY
		rev.revision_no
END

