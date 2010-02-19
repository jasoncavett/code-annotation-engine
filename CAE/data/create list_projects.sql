USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_projects]    Script Date: 02/18/2010 18:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('list_projects') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.list_projects
    PRINT '<<< DROPPED PROCEDURE list_projects>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves a list of all projects>
-- Input Parameters:
--		none
-- =============================================
CREATE PROCEDURE [dbo].[list_projects]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 project_nm
		,project_desc
		,last_update_dtm
	FROM
		dbo.Project
	ORDER BY
		project_nm
END
