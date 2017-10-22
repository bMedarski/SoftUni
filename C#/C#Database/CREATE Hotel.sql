CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
)

INSERT INTO Employees VALUES
('Pesho','Peshev','Manager',NULL),
('Gosho','Goshev','Manager',NULL),
('Tosho','Toshev','Manager',NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	PhoneNumber INT NOT NULL, 
	EmergencyName NVARCHAR(50), 
	EmergencyNumber INT,  
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers VALUES
('Pesho','Peshev',0888888,NULL,NULL,NULL),
('Gosho','Goshev',0988988,NULL,NULL,NULL),
('Tosho','Toshev',0895565,NULL,NULL,NULL)

