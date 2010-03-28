/*
 * ER/Studio 7.5 SQL Code Generation
 * Company :      Public
 * Project :      Practice.dm1
 * Author :       Joel 
 *
 * Date Created : Saturday, March 27, 2010 14:23:25
 * Target DBMS : Microsoft SQL Server 2005
 */

USE CAE
go

IF OBJECT_ID('Import_Stage') IS NOT NULL
BEGIN
    DROP TABLE Import_Stage
    PRINT '<<< DROPPED TABLE Import_Stage >>>'
END
go

/* 
 * TABLE: Import_Stage 
 */

CREATE TABLE Import_Stage(
    project_nm          varchar(20)      NOT NULL,
    codefile_nm         varchar(50)      NOT NULL,
    codefile_line_no    int              NOT NULL,
    rvwr_last_nm        varchar(20)      NOT NULL,
    rvwr_first_nm       varchar(20)      NOT NULL,
    annotation_txt      varchar(2000)    NOT NULL,
    last_update_dtm     datetime         NOT NULL,
    CONSTRAINT PK8 PRIMARY KEY NONCLUSTERED (project_nm, codefile_nm, codefile_line_no, rvwr_last_nm, rvwr_first_nm)
)
go

IF OBJECT_ID('Import_Stage') IS NOT NULL
    PRINT '<<< CREATED TABLE Import_Stage >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Import_Stage >>>'
go

