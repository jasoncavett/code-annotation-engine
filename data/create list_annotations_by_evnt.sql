USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_annotations_by_evnt]    Script Date: 02/15/2010 20:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<lists annotations for a review event>
-- Input Parameters:
--		module_nm
--		revision_no
--		rvw_event_dt
-- =============================================
CREATE PROCEDURE [dbo].[list_annotations_by_evnt] 
	 @module_nm varchar(50)
	,@revision_no numeric(6,3)
	,@rvw_event_dt datetime
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 mod.module_nm
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
		mod.module_nm = @module_nm
			AND
		rev.revision_no = @revision_no
			AND
		evnt.rvw_event_dt = @rvw_event_dt
	ORDER BY
		 ann.module_line_no
		,ann.rvwr_last_nm
		,ann.rvwr_first_nm
END