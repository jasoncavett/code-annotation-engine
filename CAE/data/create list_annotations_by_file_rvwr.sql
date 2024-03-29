USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_annotations_by_file_rvwr]    Script Date: 02/17/2010 00:15:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('list_annotations_by_file_rvwr') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.list_annotations_by_file_rvwr
    PRINT '<<< DROPPED PROCEDURE list_annotations_by_file_rvwr>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<lists annotations for a Codefile by a Reviewer>
-- Input Parameters:
--		project_nm
--		codefile_nm
--		rvwr_last_nm
--		rvwr_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[list_annotations_by_file_rvwr]
	 @project_nm varchar(20) 
	,@codefile_nm varchar(50)
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
		ann.rvwr_last_nm = @rvwr_last_nm
			AND
		ann.rvwr_first_nm = @rvwr_first_nm
	ORDER BY
		ann.codefile_line_no
END