CREATE TABLE "PageItems" (
    "RowId" INTEGER NOT NULL CONSTRAINT "PK_PageItems" PRIMARY KEY AUTOINCREMENT,
    "RunId" varchar(250) NOT NULL,
    "PageNumber" smallint NOT NULL,    
    "Url" varchar(250) NOT NULL UNIQUE,    
    "Title" varchar(250) NOT NULL,    
    "CreateDate" datetime NOT NULL,
    "ApplicationDate" datetime NULL,        
    "WorkArea" varchar(250) NOT NULL,    
    "WorkAreaWithoutZone" varchar(250) NOT NULL,    
    "WorkingHours" varchar(250) NOT NULL,
    "JobType" varchar(250) NOT NULL,    
    "JobId" bigint NOT NULL,  
    "PageItemNumber" smallint NOT NULL,   
    "PageItemId" varchar(250) NOT NULL UNIQUE,    
    "RowCreatedOn" datetime NOT NULL DEFAULT (datetime('now')),
    "RowModifiedOn" datetime NOT NULL DEFAULT (datetime('now'))
);