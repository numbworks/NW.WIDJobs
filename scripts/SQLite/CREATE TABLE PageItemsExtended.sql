CREATE TABLE "PageItemsExtended" (
    "RowId" INTEGER NOT NULL CONSTRAINT "PK_PageItemsExtended" PRIMARY KEY AUTOINCREMENT,
    "PageItemId" varchar(250) NOT NULL UNIQUE,               
    "Description" TEXT NOT NULL,
    "SeeCompleteTextAt" varchar(250) NULL,        
    "EmployerName" varchar(250) NULL,
    "NumberOfOpenings" smallint NULL,      
    "AdvertisementPublishDate" datetime NULL,     
    "ApplicationDeadline" datetime NULL,    
    "StartDateOfEmployment" varchar(250) NULL,      
    "Reference" varchar(250) NULL,     
    "Position" varchar(250) NULL,     
    "TypeOfEmployment" varchar(250) NULL,    
    "Contact" varchar(250) NULL,    
    "EmployerAddress" varchar(250) NULL,     
    "HowToApply" varchar(250) NULL,      
    "RowCreatedOn" datetime NOT NULL DEFAULT (datetime('now')),
    "RowModifiedOn" datetime NOT NULL DEFAULT (datetime('now')),
    FOREIGN KEY(PageItemId) REFERENCES PageItems(PageItemId)
);