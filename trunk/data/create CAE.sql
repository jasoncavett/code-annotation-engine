/*
 * ER/Studio 7.5 SQL Code Generation
 * Company :      Public
 * Project :      Practice.dm1
 * Author :       Joel 
 *
 * Date Created : Monday, February 08, 2010 19:05:17
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
 * TABLE: Module_version 
 */

CREATE TABLE Module_version(
    module_nm          varchar(50)      NOT NULL,
    version_no         numeric(6, 3)    NOT NULL,
    chg_desc           varchar(256)     NULL,
    devlpr_last_nm     varchar(20)      NOT NULL,
    devlpr_first_nm    varchar(20)      NOT NULL,
    last_update_dtm    datetime         NOT NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (version_no, module_nm)
)
go



IF OBJECT_ID('Module_version') IS NOT NULL
    PRINT '<<< CREATED TABLE Module_version >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Module_version >>>'
go

/* 
 * TABLE: Review_cmnt 
 */

CREATE TABLE Review_cmnt(
    module_nm          varchar(50)      NOT NULL,
    version_no         numeric(6, 3)    NOT NULL,
    module_line_no     int              NOT NULL,
    rvw_event_dt       datetime         NOT NULL,
    rvwr_last_nm       varchar(20)      NOT NULL,
    rvwr_first_nm      varchar(20)      NOT NULL,
    cmnt_txt           varchar(2000)    NOT NULL,
    last_update_dtm    datetime         NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (module_nm, version_no, rvw_event_dt, rvwr_last_nm, rvwr_first_nm, module_line_no)
)
go



IF OBJECT_ID('Review_cmnt') IS NOT NULL
    PRINT '<<< CREATED TABLE Review_cmnt >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Review_cmnt >>>'
go

/* 
 * TABLE: Review_event 
 */

CREATE TABLE Review_event(
    module_nm          varchar(50)      NOT NULL,
    version_no         numeric(6, 3)    NOT NULL,
    rvw_event_dt       datetime         NOT NULL,
    rvw_evnt_desc      varchar(256)     NULL,
    last_update_dtm    datetime         NOT NULL,
    CONSTRAINT PK5 PRIMARY KEY NONCLUSTERED (module_nm, version_no, rvw_event_dt)
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
    rvwr_last_nm       varchar(20)    NOT NULL,
    rvwr_first_nm      varchar(20)    NOT NULL,
    job_title          varchar(30)    NULL,
    cmnt_color         varchar(15)    NOT NULL,
    cmnt_font          varchar(20)    NOT NULL,
    cmnt_font_wt       varchar(15)    NOT NULL,
    last_update_dtm    datetime       NOT NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (rvwr_last_nm, rvwr_first_nm)
)
go



IF OBJECT_ID('Reviewer') IS NOT NULL
    PRINT '<<< CREATED TABLE Reviewer >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Reviewer >>>'
go

/* 
 * TABLE: Module_version 
 */

ALTER TABLE Module_version ADD CONSTRAINT RefModule1 
    FOREIGN KEY (module_nm)
    REFERENCES Module(module_nm)
go


/* 
 * TABLE: Review_cmnt 
 */

ALTER TABLE Review_cmnt ADD CONSTRAINT RefReview_event3 
    FOREIGN KEY (module_nm, version_no, rvw_event_dt)
    REFERENCES Review_event(module_nm, version_no, rvw_event_dt)
go

ALTER TABLE Review_cmnt ADD CONSTRAINT RefReviewer4 
    FOREIGN KEY (rvwr_last_nm, rvwr_first_nm)
    REFERENCES Reviewer(rvwr_last_nm, rvwr_first_nm)
go


/* 
 * TABLE: Review_event 
 */

ALTER TABLE Review_event ADD CONSTRAINT RefModule_version2 
    FOREIGN KEY (version_no, module_nm)
    REFERENCES Module_version(version_no, module_nm)
go


