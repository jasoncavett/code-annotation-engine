USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[trunc_staging]    Script Date: 03/27/2010 23:47:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Mar. 27, 2010>
-- Description:	<Truncates the Import_Staging table>
-- Input parameters:
--		none
-- =============================================
CREATE PROCEDURE [dbo].[trunc_staging]
AS
BEGIN
	SET NOCOUNT ON;

	TRUNCATE TABLE dbo.Import_Stage

END
