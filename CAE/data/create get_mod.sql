USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[get_mod]    Script Date: 02/17/2010 00:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('get_mod') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.get_mod
    PRINT '<<< DROPPED PROCEDURE get_mod>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves details for a specific module>
-- Input parameters:
--		project_nm
--		module_nm
-- =============================================
CREATE PROCEDURE [dbo].[get_mod]
	 @project_nm varchar(20) 
	,@module_nm varchar(50) 
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
			AND
		module_nm = @module_nm
END

