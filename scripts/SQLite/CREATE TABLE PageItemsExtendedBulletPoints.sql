CREATE TABLE "PageItemsExtendedBulletPoints" (
    "RowId" INTEGER NOT NULL CONSTRAINT "PK_PageItemsExtendedBulletPoints" PRIMARY KEY AUTOINCREMENT,
    "PageItemId" varchar(250) NOT NULL UNIQUE,               
    "BulletPoint" varchar(250) NOT NULL,         
    "RowCreatedOn" datetime NOT NULL DEFAULT (datetime('now')),
    "RowModifiedOn" datetime NOT NULL DEFAULT (datetime('now')),
    FOREIGN KEY(PageItemId) REFERENCES PageItems(PageItemId)
);