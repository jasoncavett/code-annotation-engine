USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_rvwrs]    Script Date: 02/15/2010 20:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<lists reviewers>
-- Input Parameters:
--		none
-- =============================================
CREATE PROCEDURE [dbo].[list_rvwrs] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 rvwr_last_nm
		,rvwr_first_nm
		,job_title
		,annotation_color
		,annotation_font
		,annotation_font_wt
		,last_update_dtm
	FROM
		dbo.Reviewer
	ORDER BY
		 rvwr_last_nm
		,rvwr_first_nm
END