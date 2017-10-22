--01. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS 
	SELECT FirstName,LastName FROM Employees
	WHERE Salary>35000
GO

--02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@money MONEY)
AS
	SELECT FirstName,LastName FROM Employees
	WHERE Salary>=@money
GO

--03. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith (@startsWith VARCHAR(max))
AS
	SELECT Name FROM Towns
	WHERE Name LIKE @startsWith+'%'
GO

--04. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown  (@town VARCHAR(max))
AS
	SELECT FirstName, LastName FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.Name = @town
GO

--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(10)
BEGIN
	DECLARE @level VARCHAR(10)

	IF(@salary<30000)
	BEGIN
		SET @level = 'Low'
	END
	ELSE IF(@salary>50000)
	BEGIN
		SET @level = 'High'
	END
	ELSE
	BEGIN
		SET @level = 'Average'
	END

	RETURN @level
END
GO

--06. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@level_of_salary VARCHAR(10))
AS
	SELECT FirstName,LastName FROM Employees
	WHERE @level_of_salary = dbo.ufn_GetSalaryLevel(Salary)
GO

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters, @word)
RETURNS BIT
BEGIN
	
END
GO
--08. * Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
					)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
				   )


UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
				   )

DELETE FROM Employees
WHERE EmployeeID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
				    )

DELETE FROM Departments
WHERE DepartmentID = @departmentId
SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

--09. Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT FirstName+' '+LastName AS [Full Name] FROM AccountHolders
GO

--10. People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@money INT)
AS
	SELECT ah.FirstName,ah.LastName FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId=ah.Id
	GROUP BY ah.FirstName,ah.LastName
	HAVING Sum(a.Balance)>=@money
	ORDER BY ah.LastName, ah.FirstName 
GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan1 (@minBalance money)
AS
BEGIN
  WITH CTE_MinBalanceAccountHolders (HolderId) AS (
    SELECT AccountHolderId FROM Accounts
    GROUP BY AccountHolderId
    HAVING SUM(Balance) > @minBalance
  )

  SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
  FROM CTE_MinBalanceAccountHolders AS minBalanceHolders 
  JOIN AccountHolders AS ah ON ah.Id = minBalanceHolders.HolderId
  ORDER BY ah.LastName, ah.FirstName 
END


EXEC usp_GetHoldersWithBalanceHigherThan 1

SELECT ah.FirstName,ah.LastName,Sum(a.Balance) FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId=ah.Id
	GROUP BY ah.FirstName,ah.LastName
	HAVING Sum(a.Balance)>=1
	ORDER BY ah.LastName, ah.FirstName 

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY,@yearly_interest_rate FLOAT,@number_of_years INT )
RETURNS MONEY
	BEGIN
	 DECLARE @counter INT = 1
	 DECLARE @rate FLOAT = 1 + @yearly_interest_rate
	 DECLARE @result FLOAT = @rate

	WHILE @counter<@number_of_years
		BEGIN 
			SET @result *= @rate
			SET @counter +=1
		END

	RETURN @result*@sum
	END
GO

--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@accountId int, @interestRate float)
AS
BEGIN
  DECLARE @years int = 5;

  SELECT
    a.Id AS [Account Id],
    ah.FirstName AS [First Name],
    ah.LastName AS [Last Name], 
    a.Balance AS [Current Balance],
    dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, @years) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id = a.AccountHolderId
  WHERE a.Id = @accountId

END

--13. *Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@gameName nvarchar(50))
RETURNS table
AS
RETURN (
  WITH CTE_CashInRows (Cash, RowNumber) AS (
    SELECT ug.Cash, ROW_NUMBER() OVER (ORDER BY ug.Cash DESC)
    FROM UsersGames AS ug
    JOIN Games AS g ON ug.GameId = g.Id
    WHERE g.Name = @gameName
  )
  SELECT SUM(Cash) AS SumCash
  FROM CTE_CashInRows
  WHERE RowNumber % 2 = 1 -- odd row numbers only

)