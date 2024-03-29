USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_files]    Script Date: 02/17/2010 00:15:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('list_files') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.list_files
    PRINT '<<< DROPPED PROCEDURE list_files>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves a list of all codefiles>
-- Input Parameters:
--		project_nm
-- =============================================
CREATE PROCEDURE [dbo].[list_files]
	@project_nm varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 project_nm
		,codefile_nm
		,last_update_dtm
	FROM
		dbo.Codefile
	WHERE
		project_nm = @project_nm
	ORDER BY
		codefile_nm
END

