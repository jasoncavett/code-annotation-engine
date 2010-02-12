/*
 * ER/Studio 7.5 SQL Code Generation
 * Company :      Public
 * Project :      Practice.dm1
 * Author :       Joel 
 *
 * Date Created : Friday, February 12, 2010 00:16:19
 * Target DBMS : Microsoft SQL Server 2005
 */

USE CAE
go
/* 
 * TABLE: Module 
 */

CREATE TABLE Module(
    module_nm          varchar(50)     NOT NULL,
    module_desc        varchar(256)    NULL,
    lang               varchar(10)     NOT NULL,
    author_last_nm     varchar(20)     NOT NULL,
    author_first_nm    varchar(20)     NOT NULL,
    last_update_dtm    datetime        NOT NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (module_nm)
)
go



IF OBJECT_ID('Module') IS NOT NULL
    PRINT '<<< CREATED TABLE Module >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Module >>>'
go

/* 
 * TABLE: Module_revision 
 */

CREATE TABLE Module_revision(
    module_nm          varchar(50)      NOT NULL,
    revision_no        numeric(6, 3)    NOT NULL,
    chg_desc           varchar(256)     NULL,
    devlpr_last_nm     varchar(20)      NOT NULL,
    devlpr_first_nm    varchar(20)      NOT NULL,
    last_update_dtm    datetime         NOT NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (revision_no, module_nm)
)
go



IF OBJECT_ID('Module_revision') IS NOT NULL
    PRINT '<<< CREATED TABLE Module_revision >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Module_revision >>>'
go

/* 
 * TABLE: Review_annotation 
 */

CREATE TABLE Review_annotation(
    module_nm          varchar(50)      NOT NULL,
    revision_no        numeric(6, 3)    NOT NULL,
    module_line_no     int              NOT NULL,
    rvw_event_dt       datetime         NOT NULL,
    rvwr_last_nm       varchar(20)      NOT NULL,
    rvwr_first_nm      varchar(20)      NOT NULL,
    annotation_txt     varchar(2000)    NOT NULL,
    last_update_dtm    datetime         NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (module_nm, revision_no, rvw_event_dt, rvwr_last_nm, rvwr_first_nm, module_line_no)
)
go



IF OBJECT_ID('Review_annotation') IS NOT NULL
    PRINT '<<< CREATED TABLE Review_annotation >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Review_annotation >>>'
go

/* 
 * TABLE: Review_event 
 */

CREATE TABLE Review_event(
    module_nm          varchar(50)      NOT NULL,
    revision_no        numeric(6, 3)    NOT NULL,
    rvw_event_dt       datetime         NOT NULL,
    rvw_evnt_desc      varchar(256)     NULL,
    last_update_dtm    datetime         NOT NULL,
    CONSTRAINT PK5 PRIMARY KEY NONCLUSTERED (module_nm, revision_no, rvw_event_dt)
)
go



IF OBJECT_ID('Review_event') IS NOT NULL
    PRINT '<<< CREATED TABLE Review_event >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Review_event >>>'
go

/* 
 * TABLE: Reviewer 
 */

CREATE TABLE Reviewer(
    rvwr_last_nm          varchar(20)    NOT NULL,
    rvwr_first_nm         varchar(20)    NOT NULL,
    job_title             varchar(30)    NULL,
    annotation_color      varchar(15)    NOT NULL,
    annotation_font       varchar(20)    NOT NULL,
    annotation_font_wt    varchar(15)    NOT NULL,
    last_update_dtm       datetime       NOT NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (rvwr_last_nm, rvwr_first_nm)
)
go



IF OBJECT_ID('Reviewer') IS NOT NULL
    PRINT '<<< CREATED TABLE Reviewer >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Reviewer >>>'
go

/* 
 * TABLE: Module_revision 
 */

ALTER TABLE Module_revision ADD CONSTRAINT RefModule1 
    FOREIGN KEY (module_nm)
    REFERENCES Module(module_nm)
go


/* 
 * TABLE: Review_annotation 
 */

ALTER TABLE Review_annotation ADD CONSTRAINT RefReview_event3 
    FOREIGN KEY (module_nm, revision_no, rvw_event_dt)
    REFERENCES Review_event(module_nm, revision_no, rvw_event_dt)
go

ALTER TABLE Review_annotation ADD CONSTRAINT RefReviewer4 
    FOREIGN KEY (rvwr_last_nm, rvwr_first_nm)
    REFERENCES Reviewer(rvwr_last_nm, rvwr_first_nm)
go


/* 
 * TABLE: Review_event 
 */

ALTER TABLE Review_event ADD CONSTRAINT RefModule_revision2 
    FOREIGN KEY (revision_no, module_nm)
    REFERENCES Module_revision(revision_no, module_nm)
go


