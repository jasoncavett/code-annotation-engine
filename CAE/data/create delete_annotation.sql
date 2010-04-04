USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[delete_annotation]    Script Date: 04/04/2010 02:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<deletes a specific annotations for a Codefile, Line # & Reviewer>
-- Input Parameters:
--		project_nm
--		codefile_nm
--		codefile_line_no
--		rvwr_last_nm 
--		rvwr_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[delete_annotation]
	 @project_nm varchar(20) 
	,@codefile_nm varchar(50)
	,@codefile_line_no int
	,@rvwr_last_nm varchar(20)
	,@rvwr_first_nm varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	IF	
		(		
		SELECT
			COUNT(*)
		FROM
			dbo.Review_annotation
		WHERE
			project_nm = @project_nm
				AND
			codefile_nm = @codefile_nm
				AND
			codefile_line_no = @codefile_line_no
				AND
			rvwr_last_nm = @rvwr_last_nm
				AND
			rvwr_first_nm = @rvwr_first_nm
		)		
		> 0
	BEGIN
		DELETE
		FROM
			dbo.Review_annotation
		WHERE
			project_nm = @project_nm
				AND
			codefile_nm = @codefile_nm
				AND
			codefile_line_no = @codefile_line_no
				AND
			rvwr_last_nm = @rvwr_last_nm
				AND
			rvwr_first_nm = @rvwr_first_nm
	END
END
