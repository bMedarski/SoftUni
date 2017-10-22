CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR (255) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15, 2),
	Weight DECIMAL(15, 2),
	Gender BIT NOT NULL,
	Birthdate date,
	Biography NVARCHAR(MAX)
)

INSERT INTO People VALUES
('Pesho',NULL,155,85.5,1,'2039-07-10','Biografy'),
('Tosho',NULL,140.2,132.5,1,'2014-01-15','Biografy'),
('MIsho',NULL,152.2,85.5,1,'1990-06-09','Biografy'),
('Ivan',NULL,185.2,46.5,1,'1966-02-08','Biografy'),
('Boyan',NULL,163.2,77.5,1,'1988-12-31','Biografy')