CREATE DATABASE WMS
USE WMS

-- 01. DDL
CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone NVARCHAR(12) NOT NULL CHECK(LEN(Phone)=12)
)
CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Address NVARCHAR(255) NOT NULL
)
CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE NOT NULL,
)
CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status NVARCHAR(11) DEFAULT 'Pending' CHECK(Status IN ('Pending','In Progress' ,'Finished')) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)
CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)
CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL UNIQUE
)
CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber NVARCHAR(50) NOT NULL UNIQUE,
	Description NVARCHAR(255),
	Price MONEY NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 NOT NULL
)
CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT NOT NULL DEFAULT 1
)
CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT NOT NULL DEFAULT 1
)

ALTER TABLE OrderParts
ADD CONSTRAINT PK_OrdersParts PRIMARY KEY (OrderId,PartId);

ALTER TABLE PartsNeeded
ADD CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId,PartId);


--02. Insert
INSERT INTO Clients VALUES
('Teri','Ennaco','570-889-5187'),
('Merlyn','Lawler','201-588-7810'),
('Georgene','Montezuma','925-615-5185'),
('Jettie','Mconnell','908-802-3564'),
('Lemuel','Latzke','631-748-6479'),
('Melodie','Knipp','805-690-1682'),
('Candida','Corbley','908-275-8357')


INSERT INTO Parts(SerialNumber,Description,Price,VendorId) VALUES 
('WP8182119','Door Boot Seal',	117.86,2),
('W10780048','Suspension Rod',42.81,1),
('W10841140','Silicone Adhesive',6.77,4),
('WPY055980','High Temperature Adhesive',	13.94,3)

--03. Update
UPDATE Jobs
SET MechanicId = 3,
Status = 'In Progress'
WHERE Status = 'Pending'

--04. Delete
DELETE FROM OrderParts
WHERE OrderId=19

DELETE FROM Orders
WHERE OrderId=19

--05. Clients by Name
SELECT FirstName,LastName,Phone FROM Clients
ORDER BY LastName,ClientId

--06. Job Status
SELECT Status,IssueDate FROM Jobs
WHERE Status <> 'Finished'
ORDER BY IssueDate,JobId

--07. Mechanic Assignments
SELECT m.FirstName+' '+m.LastName AS [Mechanic],j.Status,j.IssueDate FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId

--08. Current Clients
SELECT  c.FirstName+' '+c.LastName AS [Client],DATEDIFF(DAY,j.IssueDate,'2017-04-24 23:59:59.9999999')AS [Days going],Status FROM Clients AS c
JOIN Jobs AS j ON j.ClientId =c.ClientId
WHERE j.Status<>'Finished'
ORDER BY DATEDIFF(DAY,j.IssueDate,'2017-04-24 23:59:59.9999999') DESC,j.ClientId

--09. Mechanic Performance
SELECT [Average].Mechanic,[Average].[Average Days] FROM (SELECT m.MechanicId, m.FirstName+' '+m.LastName AS [Mechanic],AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate))AS [Average Days] FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId,m.FirstName,m.LastName) AS [Average]
ORDER BY [Average].MechanicId

--10. Hard Earners
SELECT [Average].Mechanic,[Average].Jobs FROM 
(SELECT m.MechanicId, m.FirstName+' '+m.LastName AS [Mechanic],COUNT(j.Status) AS [Jobs] FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.Status <> 'Finished'
GROUP BY m.MechanicId,m.FirstName,m.LastName) AS [Average]
WHERE [Average].Jobs>1
ORDER BY [Average].Jobs DESC,[Average].MechanicId

--11. Available Mechanics
/* SELECT [Average].Mechanic FROM 
(SELECT m.MechanicId, m.FirstName+' '+m.LastName AS [Mechanic] FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.Status = 'Finished' OR j.Status = 'Pending'
GROUP BY m.MechanicId,m.FirstName,m.LastName) AS [Average]
ORDER BY [Average].MechanicId

SELECT m.FirstName+' '+m.LastName AS [Mechanic] FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE  EXISTS (SELECT Status FROM Jobs WHERE Status <> 'In Progress' ORDER BY MechanicId);


SELECT FirstName+' '+m.LastName AS [Mechanic] FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.MechanicId NOT IN (SELECT DISTINCT jobs.MechanicId FROM Jobs AS jobs WHERE jobs.Status <> 'Finished');


SELECT DISTINCT
           Mechanics.MechanicId
    FROM Mechanics
          JOIN Jobs ON Jobs.MechanicId = Mechanics.MechanicId
    WHERE Status <> 'Finished'

	SELECT DISTINCT jobs.MechanicId FROM Jobs AS jobs WHERE jobs.Status <> 'Finished'*/

SELECT CONCAT(FirstName, ' ', LastName) AS Available
FROM Mechanics
WHERE Mechanics.MechanicId NOT IN
(
    SELECT DISTINCT
           Mechanics.MechanicId
    FROM Mechanics
          JOIN Jobs ON Jobs.MechanicId = Mechanics.MechanicId
    WHERE Status <> 'Finished'
)
ORDER BY Mechanics.MechanicId;

--12. Parts Cost
SELECT ISNULL(SUM(p.Price*p.StockQty),0.00) FROM Parts AS p
JOIN OrderParts AS op ON op.PartId = p.PartId
JOIN Orders AS o ON o.OrderId = op.OrderId
WHERE DATEDIFF(DAY,o.IssueDate,'2017-04-24')<21

--13. Past Expenses

/*SELECT j.JobId,ISNULL(SUM(p.Price),0.00)AS [Total] FROM Jobs AS j
JOIN Orders AS o ON o.JobId = j.JobId
JOIN OrderParts AS op ON op.OrderId = o.OrderId
JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY SUM(p.Price) DESC,j.JobId*/

SELECT J.JobId,
       ISNULL(SUM((Quantity * Price)), 0.00) AS Total
FROM Orders AS o
     JOIN OrderParts AS op ON o.OrderId = op.OrderId
     JOIN Parts ON op.PartId = Parts.PartId
     RIGHT JOIN Jobs AS J ON J.JobId = O.JobId
WHERE Status = 'Finished'
GROUP BY J.JobId
ORDER BY Total DESC,
         J.JobId;

--14. Model Repair Time
SELECT m.ModelId,m.Name,CONCAT(AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)),' days') FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.Name,m.ModelId
ORDER BY AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate))

--15. Faultiest Model
/*SELECT m.Name,DENSE_RANK() OVER(PARTITION BY m.Name ORDER BY COUNT(j.JobId) DESC) AS Rank   FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.Name

SELECT m.ModelId, DENSE_RANK() OVER (PARTITION BY j.ModelId ORDER BY COUNT(j.JobId) DESC) AS [Rank] FROM (SELECT m.Name AS [ModelName],COUNT(j.JobId)AS[Count] FROM Jobs AS j)
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.Name)  AS j
GROUP BY ModelId


SELECT [subQuery].Model,DENSE_RANK() OVER (PARTITION BY [subQuery].Model ORDER BY [subQuery].[Count] DESC) AS [Rank] FROM (SELECT j.ModelId AS [Model],  COUNT(j.JobId)AS[Count] FROM Jobs AS j
GROUP BY j.ModelId) AS [subQuery]
GROUP BY [subQuery].Model,[subQuery].Count*/

SELECT TOP 1 WITH TIES m.Name, COUNT(*) AS [Times Serviced],
(SELECT ISNULL(SUM(p.Price * op.Quantity),0) FROM Jobs AS j
JOIN Orders AS o ON O.JobId = j.JobId
JOIN OrderParts AS op ON op.OrderId = o.OrderId
JOIN Parts AS p ON p.[PartId] = op.PartId
WHERE j.ModelId = m.ModelId) AS [Parts Total]
 FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.ModelId, m.Name
ORDER BY [Times Serviced] DESC

--16. Missing Parts

