USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_mods]    Script Date: 02/15/2010 20:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves a list of all modules>
-- Input Parameters:
--		none
-- =============================================
CREATE PROCEDURE [dbo].[list_mods] 
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
	ORDER BY
		module_nm
END

