ALTER TABLE Employees ADD Password [nvarchar](50) --add column
ALTER TABLE Employees ADD UserGuid [uniqueidentifier] DEFAULT (newsequentialid()) --add column