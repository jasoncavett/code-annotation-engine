USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[get_rvwr]    Script Date: 02/25/2010 23:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('get_rvwr') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.get_rvwr
    PRINT '<<< DROPPED PROCEDURE get_rvwr>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<gets a reviewer>
-- Input Parameters:
--		project_nm
--		rvwr_last_nm
--		rvwr_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[get_rvwr]
   	 @project_nm varchar(20)
	,@rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
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
			AND
		rvwr_last_nm = @rvwr_last_nm
			AND
		rvwr_first_nm = @rvwr_first_nm
END