CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "receipts" (
    "_id" INTEGER NOT NULL CONSTRAINT "PK_receipts" PRIMARY KEY AUTOINCREMENT,
    "ingredients" TEXT NULL,
    "favorite" INTEGER NOT NULL DEFAULT 0,
    "steps" TEXT NULL,
    "title" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180627181332_Init', '2.0.3-rtm-10026');

ALTER TABLE "receipts" ADD "rating" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180627184321_V2', '2.0.3-rtm-10026');

