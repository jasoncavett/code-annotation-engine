USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[list_mods]    Script Date: 02/11/2010 18:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Retrieves a list of all modules>
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
END

