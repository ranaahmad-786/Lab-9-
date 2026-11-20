CREATE TABLE IF NOT EXISTS "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Description" TEXT NULL,
    "Price" TEXT NOT NULL,
    "StockQuantity" INTEGER NOT NULL
);

INSERT INTO "Products" ("Name", "Description", "Price", "StockQuantity")
SELECT 'Laptop', 'A lightweight computer for study and projects.', '55000', 12
WHERE NOT EXISTS (SELECT 1 FROM "Products");

INSERT INTO "Products" ("Name", "Description", "Price", "StockQuantity")
SELECT 'Notebook', 'A ruled notebook for lab notes.', '250', 30
WHERE NOT EXISTS (SELECT 1 FROM "Products" WHERE "Name" = 'Notebook');
