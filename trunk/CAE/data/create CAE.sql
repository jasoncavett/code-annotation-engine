/*
 * ER/Studio 7.5 SQL Code Generation
 * Company :      Public
 * Project :      Practice.dm1
 * Author :       Joel 
 *
 * Date Created : Sunday, March 21, 2010 00:02:08
 * Target DBMS : Microsoft SQL Server 2005
 */

USE CAE
go

IF OBJECT_ID('Review_annotation') IS NOT NULL
BEGIN
    DROP TABLE Review_annotation
    PRINT '<<< DROPPED TABLE Review_annotation >>>'
END
go

IF OBJECT_ID('Review_event') IS NOT NULL
BEGIN
    DROP TABLE Review_event
    PRINT '<<< DROPPED TABLE Review_event >>>'
END
go

IF OBJECT_ID('Reviewer') IS NOT NULL
BEGIN
    DROP TABLE Reviewer
    PRINT '<<< DROPPED TABLE Reviewer >>>'
END
go

IF OBJECT_ID('Module_revision') IS NOT NULL
BEGIN
    DROP TABLE Module_revision
    PRINT '<<< DROPPED TABLE Module_revision >>>'
END
go

IF OBJECT_ID('Module') IS NOT NULL
BEGIN
    DROP TABLE Module
    PRINT '<<< DROPPED TABLE Module >>>'
END
go

IF OBJECT_ID('Codefile') IS NOT NULL
BEGIN
    DROP TABLE Codefile
    PRINT '<<< DROPPED TABLE Codefile >>>'
END
go

IF OBJECT_ID('Project') IS NOT NULL
BEGIN
    DROP TABLE Project
    PRINT '<<< DROPPED TABLE Project >>>'
END
go

/* 
 * TABLE: Codefile 
 */

CREATE TABLE Codefile(
    project_nm         varchar(20)    NOT NULL,
    codefile_nm        varchar(50)    NOT NULL,
    last_update_dtm    datetime       NOT NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (codefile_nm, project_nm)
)
go



IF OBJECT_ID('Codefile') IS NOT NULL
    PRINT '<<< CREATED TABLE Codefile >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Codefile >>>'
go

/* 
 * TABLE: Project 
 */

CREATE TABLE Project(
    project_nm         varchar(20)    NOT NULL,
    last_update_dtm    datetime       NOT NULL,
    CONSTRAINT PK7 PRIMARY KEY NONCLUSTERED (project_nm)
)
go



IF OBJECT_ID('Project') IS NOT NULL
    PRINT '<<< CREATED TABLE Project >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Project >>>'
go

/* 
 * TABLE: Review_annotation 
 */

CREATE TABLE Review_annotation(
    project_nm          varchar(20)      NOT NULL,
    codefile_nm         varchar(50)      NOT NULL,
    codefile_line_no    int              NOT NULL,
    rvwr_last_nm        varchar(20)      NOT NULL,
    rvwr_first_nm       varchar(20)      NOT NULL,
    annotation_txt      varchar(2000)    NOT NULL,
    last_update_dtm     datetime         NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (rvwr_last_nm, rvwr_first_nm, codefile_line_no, project_nm, codefile_nm)
)
go



IF OBJECT_ID('Review_annotation') IS NOT NULL
    PRINT '<<< CREATED TABLE Review_annotation >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Review_annotation >>>'
go

/* 
 * TABLE: Reviewer 
 */

CREATE TABLE Reviewer(
    project_nm          varchar(20)    NOT NULL,
    rvwr_last_nm        varchar(20)    NOT NULL,
    rvwr_first_nm       varchar(20)    NOT NULL,
    annotation_color    varchar(15)    NOT NULL,
    last_update_dtm     datetime       NOT NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (rvwr_last_nm, rvwr_first_nm, project_nm)
)
go



IF OBJECT_ID('Reviewer') IS NOT NULL
    PRINT '<<< CREATED TABLE Reviewer >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Reviewer >>>'
go

/* 
 * TABLE: Codefile 
 */

ALTER TABLE Codefile ADD CONSTRAINT RefProject5 
    FOREIGN KEY (project_nm)
    REFERENCES Project(project_nm) ON DELETE CASCADE
go


/* 
 * TABLE: Review_annotation 
 */

ALTER TABLE Review_annotation ADD CONSTRAINT RefReviewer4 
    FOREIGN KEY (rvwr_last_nm, rvwr_first_nm, project_nm)
    REFERENCES Reviewer(rvwr_last_nm, rvwr_first_nm, project_nm) ON DELETE CASCADE
go

ALTER TABLE Review_annotation ADD CONSTRAINT RefCodefile7 
    FOREIGN KEY (codefile_nm, project_nm)
    REFERENCES Codefile(codefile_nm, project_nm) ON DELETE NO ACTION
go


/* 
 * TABLE: Reviewer 
 */

ALTER TABLE Reviewer ADD CONSTRAINT RefProject6 
    FOREIGN KEY (project_nm)
    REFERENCES Project(project_nm) ON DELETE CASCADE
go


