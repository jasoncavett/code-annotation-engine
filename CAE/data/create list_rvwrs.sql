USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_rvwrs]    Script Date: 02/17/2010 00:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('list_rvwrs') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.list_rvwrs
    PRINT '<<< DROPPED PROCEDURE list_rvwrs>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<lists reviewers>
-- Input Parameters:
--		project_nm
-- =============================================
CREATE PROCEDURE [dbo].[list_rvwrs]
	@project_nm varchar(20) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 project_nm
		,rvwr_last_nm
		,rvwr_first_nm
		,annotation_color
		,last_update_dtm
	FROM
		dbo.Reviewer
	WHERE
		project_nm = @project_nm
	ORDER BY
		 rvwr_last_nm
		,rvwr_first_nm
END