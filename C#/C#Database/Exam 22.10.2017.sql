CREATE DATABASE ReportService
USE ReportService

--01. DDL

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	Password NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50),
	Gender NVARCHAR(1) CHECK(Gender='M'OR Gender = 'F'),
	BirthDate DATETIME,
	Age INT,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender NVARCHAR(1) CHECK(Gender='M'OR Gender = 'F'),
	BirthDate DATETIME,
	Age INT,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id) 
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) 
)

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	Label NVARCHAR(30) NOT NULL,
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description NVARCHAR(200),
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--02. Insert
INSERT INTO Employees(FirstName,	LastName,	Gender,	Birthdate,	DepartmentId) VALUES
('Marlo','O’Malley','M','9/21/1958',1),
('Niki','Stanaghan','F','11/26/1969',4),
('Ayrton','Senna','M','03/21/1960 ',9),
('Ronnie','Peterson','M','02/14/1944',9),
('Giovanna','Amati','F','07/20/1959',5)

INSERT INTO Reports(CategoryId,	StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId) VALUES
(6,3,'09/05/2015','12/06/2015','Charity trail running',3,5),
(4,3,'07/03/2017','07/06/2017','Cut off streetlight on Str.11',1,1)


INSERT INTO Reports(CategoryId,	StatusId,OpenDate,Description,UserId,EmployeeId) VALUES
(1,1,'04/13/2017','Stuck Road on Str.133',6,2),
(14,2,'09/07/2015','Falling bricks on Str.58',5,2)

--03. Update
UPDATE Reports
SET StatusId = 2
WHERE StatusId = 1 AND CategoryId = 4

--04. Delete
DELETE FROM Reports
WHERE StatusId = 4 

--05. Users by Age
SELECT Username,Age FROM Users
ORDER BY Age,Username DESC

--06. Unassigned Reports
SELECT Description,OpenDate FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate,Description

--07. Employees & Reports
SELECT e.FirstName,e.LastName,r.Description,FORMAT ( r.OpenDate, 'yyy-MM-dd', 'en-us' )AS[OpenDate] FROM Employees AS e
JOIN Reports AS r ON r.EmployeeId = e.Id
ORDER BY e.Id,r.OpenDate,r.Id

--08. Most Reported Category
SELECT c.Name,COUNT(r.CategoryId) FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY COUNT(r.CategoryId) DESC,c.Name

--09. Employees in Category
/*SELECT c.Name,ISNULL(COUNT(e.Id),0) FROM Employees AS e
RIGHT JOIN Reports AS r ON r.EmployeeId = e.Id
RIGHT JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY c.Name*/


SELECT c.Name,ISNULL(COUNT(e.Id),0) FROM Employees AS e
RIGHT JOIN Departments AS d ON d.Id = e.DepartmentId
RIGHT JOIN Categories AS c ON c.DepartmentId = d.Id
GROUP BY c.Name
ORDER BY c.Name


--10. Users per Employee
SELECT CONCAT(e.FirstName,' ',e.LastName),u.Username FROM Employees AS e
JOIN Reports AS r ON r.EmployeeId = e.Id
JOIN Users AS u ON u.Id = r.UserId

SELECT CONCAT(e.FirstName,' ',e.LastName)AS[Name],COUNT(r.UserId)AS [Users Number] FROM Reports AS r
RIGHT JOIN Employees AS e ON e.Id=r.EmployeeId
GROUP BY e.FirstName,e.LastName
ORDER BY COUNT(r.UserId) DESC,e.FirstName,e.LastName

--11. Emergency Patrol
SELECT r.OpenDate,r.Description,u.Email AS [Reporter Email] FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
JOIN Departments AS d ON d.Id = c.DepartmentId
JOIN Users AS u ON u.Id = r.UserId
WHERE CloseDate IS NULL AND Description LIKE '%str%' AND LEN(Description)>20 AND d.Name IN ('Infrastructure','Emergency','Roads Maintenance')
ORDER BY r.OpenDate,u.Username,u.Id

--12. Birthday Report
SELECT DISTINCT c.Name FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE DATEPART(DAY,r.OpenDate) = DATEPART(DAY,u.BirthDate) AND DATEPART(MONTH,r.OpenDate) = DATEPART(MONTH,u.BirthDate)
ORDER BY c.Name

--13. Numbers Coincidence
SELECT DISTINCT u.Username FROM Users AS u
JOIN Reports AS r ON r.UserId = u.Id
WHERE (u.Username LIKE '[0-9]%' AND SUBSTRING(u.Username,1,1) = CAST(r.CategoryId AS VARCHAR(1))) 
OR (u.Username LIKE '%[0-9]' AND RIGHT(u.Username,1) = CAST(r.CategoryId AS VARCHAR(1)))
ORDER BY u.Username

--14. Open/Closed Statistics
SELECT CONCAT(e.FirstName,' ',e.LastName)AS [Name],CONCAT(CAST(COUNT(DATEPART(YEAR,r.CloseDate))AS NVARCHAR(2)),'/',(CAST(COUNT(DATEPART(YEAR,r.OpenDate))AS NVARCHAR(2)))) AS[Closed Open Reports] FROM Employees AS e
JOIN Reports AS r ON r.EmployeeId = e.Id
WHERE DATEPART(YEAR,r.CloseDate) = 2016 OR DATEPART(YEAR,r.OpenDate) = 2016
GROUP BY e.FirstName,E.LastName
ORDER BY [Name]

--15. Average Closing Time
SELECT [mid].Name AS [Department Name],CASE WHEN [mid].[AVG] = 0 THEN 'no info'
ELSE CAST([mid].[AVG]AS NVARCHAR(20)) END AS[Average Duration]
  FROM (SELECT d.Name, 
SUM(CASE WHEN r.CloseDate IS NULL THEN 0 ELSE 1 END)AS[NoN Null Count],
SUM(ISNULL(DATEDIFF(DAY,r.OpenDate,r.CloseDate),0))AS[average],
CASE WHEN SUM(CASE WHEN r.CloseDate IS NULL THEN 0 ELSE 1 END)<>0 THEN SUM(ISNULL(DATEDIFF(DAY,r.OpenDate,r.CloseDate),0))/SUM(CASE WHEN r.CloseDate IS NULL THEN 0 ELSE 1 END)
ELSE 0 END AS [AVG]
FROM Departments AS d
JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.Name) AS [Mid]

--16. Favorite Categories
SELECT d.Name,c.Name,COUNT(c.Name),COUNT(r.Id) FROM Departments AS d
JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.Name,c.Name
ORDER BY d.Name,c.Name

SELECT [Counts].[Department Name],[Counts].[Category Name] AS [Category Name],
(SUM([Counts].[CategoryCount]))AS[Sum],[Counts].[ReportsCount] AS [Percentage] FROM (SELECT d.Name AS [Department Name],c.Name AS [Category Name], COUNT(c.Name)AS[CategoryCount],COUNT(r.Id)AS[ReportsCount] 
FROM Departments AS d
JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.Name,c.Name) AS [Counts]
GROUP BY [Counts].[Department Name],[Counts].[Category Name],[Counts].[ReportsCount]
ORDER BY [Counts].[Department Name],[Counts].[Category Name]


--17. Employee's Load
GO

CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT) 
RETURNS INT
BEGIN
	DECLARE @Sum INT = (SELECT ISNULL(COUNT(r.Id),0) FROM Reports AS r
		WHERE r.EmployeeId = @employeeId AND r.StatusId = @statusId)

	RETURN @Sum
END
GO

--18. Assign Employee
CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS 
	 BEGIN TRANSACTION;

		DECLARE @Employee_Department INT = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
		DECLARE @Reports_Department INT = (SELECT c.DepartmentId FROM Reports AS r
												JOIN Categories AS c ON c.Id = r.EmployeeId
												WHERE r.Id = @reportId)

		IF(@Employee_Department <> @Reports_Department)
				BEGIN
					ROLLBACK;
					RAISERROR ('Employee doesn''t belong to the appropriate department!', 16, 1);
				END		
		UPDATE Reports
		SET EmployeeId = @employeeId
		WHERE Id = @reportId

	COMMIT
GO

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 2

GO
--19. Close Reports
ALTER TRIGGER tr_ChangeStatusToComplete ON Reports FOR UPDATE
AS
BEGIN

	IF UPDATE(CloseDate)
	BEGIN
		UPDATE Reports
		SET StatusId = 3
		WHERE Id = (SELECT Id FROM inserted)
	END

END
GO

--20. Categories Revision

SELECT [sub].Name AS [Category Name],[sub].[rep],
CASE 
WHEN [sub].one = [sub].two THEN 'equal'
WHEN [sub].one > [sub].two THEN 'waiting'
ELSE 'in progress' END
 AS [Main Status]
	FROM (SELECT c.Name,COUNT(r.Id) AS [rep],
	COUNT(
	Case
	WHEN r.StatusId = 1 THEN 1
	WHEN r.StatusId = 2 THEN NULL
	 END) AS[one],
	 COUNT(
	Case
	WHEN r.StatusId = 1 THEN NULL
	WHEN r.StatusId = 2 THEN 1
	 END) AS [two]
	FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
WHERE r.StatusId IN (1,2) 
GROUP BY c.Name
) AS [sub]


--------------

SELECT c.Name,COUNT(r.Id) AS [rep],
	COUNT(
	Case
	WHEN r.StatusId = 1 THEN 1
	WHEN r.StatusId = 2 THEN NULL
	 END) AS[one],
	 COUNT(
	Case
	WHEN r.StatusId = 1 THEN NULL
	WHEN r.StatusId = 2 THEN 1
	 END) AS [two]
	FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
WHERE r.StatusId IN (1,2) 
GROUP BY c.Name


