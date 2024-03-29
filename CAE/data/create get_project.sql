USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[get_project]    Script Date: 02/25/2010 23:23:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('get_project') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.get_project
    PRINT '<<< DROPPED PROCEDURE get_project>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves details for a specific project>
-- Input parameters:
--		project_nm
-- =============================================
CREATE PROCEDURE [dbo].[get_project]
	 @project_nm varchar(20) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 project_nm
		,last_update_dtm
	FROM
		dbo.Project
	WHERE
		project_nm = @project_nm
END
