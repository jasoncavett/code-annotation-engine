USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[load_tables]    Script Date: 02/17/2010 00:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('load_tables') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.load_tables
    PRINT '<<< DROPPED PROCEDURE load_tables>>>'
END
go
-- =============================================
-- Author:		<Joel Manon>
-- Create date: <Feb. 11, 2010>
-- Description:	<Loads Sample Data into Tables>
-- =============================================
CREATE PROCEDURE [dbo].[load_tables] 
	@replace_existing_data char(1),
	@file_path varchar(255)
AS
BEGIN
	DECLARE @SqlStatement nvarchar(4000)

	IF @replace_existing_data = 'Y'
		BEGIN
			DELETE FROM Project
			DELETE FROM Reviewer
		END

	SET @SqlStatement =
		'
		BULK INSERT Project
		FROM ''' + RTRIM(@file_path)+'\Project.txt' + '''
		'
	EXEC sp_executesql @SqlStatement

	SET @SqlStatement =
		'
		BULK INSERT Codefile
		FROM ''' + RTRIM(@file_path)+'\Codefile.txt' + '''
		'
	EXEC sp_executesql @SqlStatement


	SET @SqlStatement =
		'
		BULK INSERT Reviewer
		FROM ''' + RTRIM(@file_path)+'\Reviewer.txt' + '''
		'
	EXEC sp_executesql @SqlStatement

	SET @SqlStatement =
		'
		BULK INSERT Review_annotation
		FROM ''' + RTRIM(@file_path)+'\Review_annotation.txt' + '''
		'
	EXEC sp_executesql @SqlStatement

END