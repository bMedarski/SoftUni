CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	Length DECIMAL(15,4) NOT NULL,
	GenreId INT,
	CategoryId INT,
	Rating DECIMAL(5,2),
	Notes NVARCHAR(MAX),
)

INSERT INTO Directors VALUES
('Steven Spielberg','notes'),
('Francis Copola','notes'),
('Luc Besson','notes'),
('George Lucas','notes'),
('Quentine Tarantino','notes')

INSERT INTO Genres VALUES
('Sci-Fi','notes'),
('Comedy','notes'),
('Horror','notes'),
('Drama','notes'),
('Adventure','notes')

INSERT INTO Categories VALUES
('BlockBuster','notes'),
('Asdfg','notes'),
('Zxcvb','notes'),
('Qwerty','notes'),
('12345','notes')

INSERT INTO Movies VALUES
('Star wars 1',4,1977,155.5,1,1,15.0,'notes'),
('Star wars 2',4,1980,155.5,1,1,15.0,'notes'),
('Star wars 3',4,1983,155.5,1,1,30.59,'notes'),
('Star wars 4',4,1999,155.5,1,1,49.8,'notes'),
('Star wars 5',4,2001,155.5,1,1,100,'notes')