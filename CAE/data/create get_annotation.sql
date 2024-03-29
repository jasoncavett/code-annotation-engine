USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[get_annotation]    Script Date: 02/25/2010 23:23:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('get_annotation') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.get_annotation
    PRINT '<<< DROPPED PROCEDURE get_annotation>>>'
END
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<get a specific annotations for a Codefile, Line # & Reviewer>
-- Input Parameters:
--		project_nm
--		codefile_nm
--		codefile_line_no
--		rvwr_last_nm 
--		rvwr_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[get_annotation]
	 @project_nm varchar(20) 
	,@codefile_nm varchar(50)
	,@codefile_line_no int
	,@rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 ann.project_nm
		,ann.codefile_nm
		,ann.codefile_line_no
		,ann.rvwr_last_nm
		,ann.rvwr_first_nm
		,ann.annotation_txt
		,ann.last_update_dtm
	FROM
		dbo.Review_annotation ann
	WHERE
		ann.project_nm = @project_nm
			AND
		ann.codefile_nm = @codefile_nm
			AND
		ann.codefile_line_no = @codefile_line_no
			AND
		ann.rvwr_last_nm = @rvwr_last_nm
			AND
		ann.rvwr_first_nm = @rvwr_first_nm
END