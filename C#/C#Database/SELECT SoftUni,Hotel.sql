SELECT Name FROM Towns
ORDER BY Name 

SELECT Name FROM Departments
ORDER BY Name

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC


UPDATE Employees
SET Salary+=Salary*10/100
SELECT Salary FROM Employees


UPDATE Payments
SET TaxRate-=TaxRate*3/100
SELECT TaxRate FROM Payments


TRUNCATE TABLE Occupancies