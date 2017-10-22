--Problem 1.	Find Names of All Employees by First Name
SELECT FirstName,LastName FROM Employees
WHERE FirstName LIKE 'SA%'

--Problem 2.	  Find Names of All employees by Last Name 
SELECT FirstName,LastName FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3.	Find First Names of All Employees
SELECT FirstName FROM Employees
WHERE ((DepartmentID IN(3,10)) AND (YEAR(HireDate) BETWEEN 1995 AND 2005));
 
 --Problem 4.	Find All Employees Except Engineers
SELECT FirstName,LastName FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length
SELECT Name FROM Towns
WHERE Len(Name) IN (5,6)
ORDER BY Name

--Problem 6.	 Find Towns Starting With
SELECT TownId,Name FROM Towns
WHERE Name LIKE ('M%')OR Name LIKE ('K%')OR Name LIKE ('B%') OR Name LIKE ('E%')
ORDER BY Name

--Problem 7.	 Find Towns Not Starting With
SELECT TownId,Name FROM Towns
WHERE NOT Name LIKE ('B%') AND NOT Name LIKE ('D%') AND NOT Name LIKE ('R%')
ORDER BY Name

--Problem 8.	Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName FROM Employees
WHERE YEAR(HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

--Problem 9.	Length of Last Name
SELECT FirstName,LastName FROM Employees
WHERE LEN(LastName)=5

--Problem 10.	Countries Holding ‘A’ 3 or More Times
SELECT CountryName,IsoCode FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

--Problem 11.	 Mix of Peak and River Names
SELECT PeakName,RiverName,CONCAT(LOWER(SUBSTRING(PeakName,1,LEN(PeakName)-1)),LOWER(RiverName)) AS [Mix]
FROM Peaks AS [P],Rivers AS [R]
WHERE RIGHT(P.PeakName,1)=LEFT(R.RiverName,1)
ORDER BY Mix

--Problem 12.	Games from 2011 and 2012 year
SELECT TOP(50) Name,FORMAT(Start,'yyyy-MM-dd')AS [Start] FROM Games
WHERE YEAR(Start) BETWEEN 2011 AND 2012
ORDER BY Start,Name

--Problem 13.	 User Email Providers
SELECT Username,SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)-CHARINDEX('@',Email)+1) AS [Email Provide] FROM Users
ORDER BY [Email Provide],Username

--Problem 14.	 Get Users with IPAdress Like Pattern
SELECT Username,IpAddress AS [IP Address]FROM Users
WHERE IpAddress LIKE '___[.][1]%[.]%[.]___'
ORDER BY Username

--Problem 15.	 Show All Games with Duration and Part of the Day
SELECT Name AS [Game],
	   CASE
		WHEN DATEPART(HOUR, Start) >=0 AND DATEPART(HOUR, Start) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, Start) >=12 AND DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, Start) >=18 AND DATEPART(HOUR, Start) < 24 THEN 'Evening'
		END AS [Part of the Day],
       CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration > 3 AND Duration <=6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
		END AS [Duration]
FROM Games
ORDER BY [Game],[Duration],[Part of the Day]

--Problem 16.	 Orders Table
SELECT ProductName,OrderDate,DATEADD(DAY,3,OrderDate) AS [Pay Due],DATEADD(MONTH,1,OrderDate) AS [Deliver Due] FROM Orders