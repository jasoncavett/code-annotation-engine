USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[add_mod]    Script Date: 02/15/2010 22:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 15, 2010>
-- Description:	<Adds a new module>
-- Input parameters:
--		module_nm
--		module_desc
--		lang
--		author_last_nm
--		author_first_nm
-- =============================================
CREATE PROCEDURE [dbo].[add_mod] 
	 @module_nm varchar(50)
	,@module_desc varchar(256)
	,@lang varchar(10)
	,@author_last_nm varchar(20)
	,@author_first_nm varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO
		dbo.Module
		(
		 module_nm
		,module_desc
		,lang
		,author_last_nm
		,author_first_nm
		,last_update_dtm
		)
	VALUES
		(
		 @module_nm
		,@module_desc
		,@lang
		,@author_last_nm
		,@author_first_nm
		,getdate()
		)
END
