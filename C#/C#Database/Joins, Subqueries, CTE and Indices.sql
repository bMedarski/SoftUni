--01. Employee Address
SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--02. Addresses with Towns
SELECT TOP 50 e.FirstName, e.LastName, t.Name, a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON T.TownID = a.TownID
ORDER BY e.FirstName,e.LastName

--03. Sales Employees
SELECT e.EmployeeID,e.FirstName,e.LastName,d.Name FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--04. Employee Departments
SELECT TOP 5 e.EmployeeID,e.FirstName,e.Salary,d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID ASC

--05. Employees Without Projects
SELECT TOP 3 e.EmployeeID,e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--06. Employees Hired After
SELECT e.FirstName,e.LastName,e.HireDate,d.Name AS DeptName FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance') AND (YEAR(e.HireDate)>1998)
ORDER BY e.HireDate

--07. Employees With Project
SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '20020813' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--08. Employee 24
SELECT e.EmployeeID, e.FirstName, CASE
WHEN YEAR(p.StartDate)>=2005 THEN NULL
ELSE p.Name
END AS [ProjectName] FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--09. Employee Manager
SELECT e.EmployeeID, e.FirstName,e.ManagerID,m.FirstName FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

--10. Employees Summary
SELECT TOP 50 e.EmployeeID, CONCAT(e.FirstName, ' ',e.LastName) AS EmployeeName ,CONCAT(m.FirstName, ' ',m.LastName) AS ManagerName,d.Name FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT TOP 1 AVG(e.Salary) AS MinAverageSalary FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary

--12. Highest Peaks in Bulgaria
SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation>2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT c.CountryCode,COUNT(m.MountainRange)AS MountainRanges FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN ('BG','US','RU')
GROUP BY c.CountryCode
ORDER BY MountainRanges DESC

--14. Countries With or Without Rivers
SELECT TOP 5 c.CountryName,CASE 
						WHEN r.RiverName IS NULL THEN NULL 
						ELSE r.RiverName
						END AS [RiverName]
FROM Countries AS c
FULL JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
FULL JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. *Continents and Currencies
SELECT ContinentCode,CurrencyCode,CurrencyUsage FROM (SELECT 
	c.ContinentCode AS [ContinentCode],
	cu.CurrencyCode AS [CurrencyCode],
	COUNT(cu.CurrencyCode)AS CurrencyUsage,
	DENSE_RANK() OVER   
		(PARTITION BY c.ContinentCode ORDER BY COUNT(cu.CurrencyCode) DESC) AS Rank FROM Countries AS c
JOIN Currencies AS cu ON c.CurrencyCode= cu.CurrencyCode
JOIN Continents AS co ON co.ContinentCode = c.ContinentCode

GROUP BY c.ContinentCode,cu.CurrencyCode
HAVING COUNT(cu.CurrencyCode)>1 ) AS [RankTable]
WHERE Rank=1
ORDER BY ContinentCode

--16. Countries Without any Mountains
SELECT COUNT(*)AS CountryCode FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE m.MountainRange IS NULL

--17. Highest Peak and Longest River by Country

SELECT TOP 5 c.CountryName,MAX(p.Elevation) AS HighestPeakElevation,MAX(r.Length)AS LongestRiverLength FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC, c.CountryName

--18. *Highest Peak Name and Elevation by Country
SELECT TOP 5 RankTable.CountryName,CASE 
							WHEN RankTable.PeakName IS NULL THEN '(no highest peak)'
							ELSE RankTable.PeakName
							END AS [HighestPeakName],
							CASE
							WHEN RankTable.Elevation IS NULL THEN 0
							ELSE RankTable.Elevation
							END AS [HighestPeakElevation],CASE 
							WHEN RankTable.MountainRange IS NULL THEN '(no mountain)'
							ELSE RankTable.MountainRange
							END AS [Mountain]
							  FROM (SELECT	c.CountryName AS CountryName,
									m.MountainRange,
									p.PeakName,
									p.Elevation,
									DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC)AS Rank 
							FROM Countries AS c
							LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
							LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
							LEFT JOIN Peaks AS p ON p.MountainId = m.Id
							GROUP BY c.CountryName,	m.MountainRange,p.PeakName,p.Elevation)AS [RankTable]
WHERE RankTable.Rank = 1
ORDER BY  RankTable.CountryName,[HighestPeakName]