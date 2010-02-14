USE [CAE]
GO
/****** Object:  StoredProcedure [dbo].[load_tables]    Script Date: 02/14/2010 00:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			DELETE FROM Module
			DELETE FROM Reviewer
		END

	SET @SqlStatement =
		'
		BULK INSERT Module
		FROM ''' + RTRIM(@file_path)+'\Module.txt' + '''
		'
	EXEC sp_executesql @SqlStatement

	SET @SqlStatement =
		'
		BULK INSERT Module_revision
		FROM ''' + RTRIM(@file_path)+'\Module_revision.txt' + '''
		'
	EXEC sp_executesql @SqlStatement

	SET @SqlStatement =
		'
		BULK INSERT Review_event
		FROM ''' + RTRIM(@file_path)+'\Review_event.txt' + '''
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