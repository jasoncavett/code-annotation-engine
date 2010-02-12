USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[get_mod]    Script Date: 02/11/2010 18:40:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves all versions for a module>
-- =============================================
CREATE PROCEDURE [dbo].[get_mod] 
	@module_nm varchar(50) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		 module_nm
		,module_desc
		,lang
		,author_last_nm
		,author_first_nm
		,last_update_dtm
	FROM
		dbo.Module
	WHERE
		module_nm = @module_nm
END

