USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_annotations_by_evnt_rvwr]    Script Date: 02/17/2010 00:15:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('list_annotations_by_evnt_rvwr') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.list_annotations_by_evnt_rvwr
    PRINT '<<< DROPPED PROCEDURE list_annotations_by_evnt_rvwr>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<lists annotations for a Reviewer at a review event>
-- Input Parameters:
--		project_nm
--		module_nm
--		revision_no
--		rvw_event_dt
--		rvwr_last_nm
--		rvwr_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[list_annotations_by_evnt_rvwr]
	 @project_nm varchar(20) 
	,@module_nm varchar(50)
	,@revision_no numeric(6,3)
	,@rvw_event_dt datetime
	,@rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 mod.project_nm
		,mod.module_nm
		,mod.module_desc
		,mod.lang
		,mod.author_last_nm
		,mod.author_first_nm
		,mod.last_update_dtm
		,rev.revision_no
		,rev.chg_desc
		,rev.devlpr_last_nm
		,rev.devlpr_first_nm
		,rev.last_update_dtm
		,evnt.rvw_event_dt
		,evnt.rvw_event_desc
		,evnt.last_update_dtm
		,ann.module_line_no
		,ann.rvwr_last_nm
		,ann.rvwr_first_nm
		,ann.annotation_txt
		,ann.last_update_dtm
	FROM
		dbo.Module mod
	INNER JOIN
		dbo.Module_revision rev
	ON
		mod.module_nm = rev.module_nm
	INNER JOIN
		dbo.Review_event evnt
	ON
		evnt.module_nm = rev.module_nm
			AND
		evnt.revision_no = rev.revision_no
	INNER JOIN
		dbo.Review_annotation ann
	ON
		ann.module_nm = rev.module_nm
			AND
		ann.revision_no = rev.revision_no
			AND
		ann.rvw_event_dt = evnt.rvw_event_dt
	WHERE
		mod.project_nm = @project_nm
			AND
		mod.module_nm = @module_nm
			AND
		rev.revision_no = @revision_no
			AND
		evnt.rvw_event_dt = @rvw_event_dt
			AND
		ann.rvwr_last_nm = @rvwr_last_nm
			AND
		ann.rvwr_first_nm = rvwr_first_nm
	ORDER BY
		ann.module_line_no
END