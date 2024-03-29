USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_mods]    Script Date: 02/17/2010 00:15:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('list_mods') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.list_mods
    PRINT '<<< DROPPED PROCEDURE list_mods>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves a list of all modules>
-- Input Parameters:
--		project_nm
-- =============================================
CREATE PROCEDURE [dbo].[list_mods]
	@project_nm varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 project_nm
		,module_nm
		,module_desc
		,lang
		,author_last_nm
		,author_first_nm
		,last_update_dtm
	FROM
		dbo.Module
	WHERE
		project_nm = @project_nm
	ORDER BY
		module_nm
END

