USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_revw_evnts]    Script Date: 02/15/2010 20:54:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<lists all review events for a module revision>
-- Input Parameters:
--     module_nm
--     revision_no
-- =============================================
CREATE PROCEDURE [dbo].[list_revw_evnts] 
	 @module_nm varchar(50)
	,@revision_no numeric(6,3) 
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
	WHERE
		mod.module_nm = @module_nm
			AND
		rev.revision_no = @revision_no
	ORDER BY
		evnt.rvw_event_dt
END