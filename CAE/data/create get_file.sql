USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[get_file]    Script Date: 02/17/2010 00:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('get_file') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.get_file
    PRINT '<<< DROPPED PROCEDURE get_file>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves details for a specific codefile>
-- Input parameters:
--		project_nm
--		codefile_nm
-- =============================================
CREATE PROCEDURE [dbo].[get_file]
	 @project_nm varchar(20) 
	,@codefile_nm varchar(50) 
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
			AND
		codefile_nm = @codefile_nm
END

