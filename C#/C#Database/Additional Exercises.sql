--1. Number of Users for Email Provider
SELECT SUBSTRING(Email,(CHARINDEX('@',Email)+1),LEN(Email))AS [Email Provider],COUNT(*)AS[Number Of Users] FROM Users
GROUP BY SUBSTRING(Email,(CHARINDEX('@',Email)+1),LEN(Email))
ORDER BY COUNT(*) DESC,[Email Provider]

--02. All Users in Games
SELECT g.Name,gp.Name,u.Username,ug.Level,ug.Cash,c.Name FROM UsersGames AS ug
JOIN Characters AS c ON c.Id=ug.CharacterId
JOIN Users AS u ON u.Id=ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
JOIN GameTypes AS gp ON gp.Id = g.GameTypeId
ORDER BY ug.Level DESC,u.Username,g.Name

--03. Users in Games with Their Items
SELECT u.Username,g.Name AS [Game],COUNT(i.Id)AS[Items Count],SUM(i.Price)AS[Items Price] FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId=u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId
GROUP BY u.Username,g.Name
HAVING COUNT(i.Id)>=10
ORDER BY COUNT(i.Id) DESC,SUM(i.Price) DESC,u.Username

--04. * User in Games with Their Statistics
SELECT * FROM Items AS i
JOIN [Statistics] AS s ON s.Id = i.StatisticId

SELECT * FROM Characters AS c
JOIN [Statistics] AS s ON s.Id = c.StatisticId

SELECT * FROM GameTypes AS gp
JOIN [Statistics] AS s ON s.Id = gp.BonusStatsId



--05. All Items with Greater than Average Statistics
SELECT i.Name,i.Price,i.MinLevel,s.Strength,s.Defence,s.Speed,s.Luck,s.Mind FROM Items AS i
JOIN [Statistics] AS s ON s.Id = i.StatisticId
WHERE s.Speed>(SELECT AVG(Speed) FROM [Statistics] AS AvgSpeed)
AND	s.Mind>(SELECT AVG(Mind) FROM [Statistics] AS AvgMind)
AND s.Luck>(SELECT AVG(Luck) FROM [Statistics] AS AvgLuck)
ORDER BY i.Name

--06. Display All Items about Forbidden Game Type
SELECT i.Name AS [Item],i.Price,i.MinLevel,gp.Name AS [Forbidden Game Type] FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS f ON f.ItemId = i.Id
LEFT JOIN GameTypes AS gp ON gp.Id = f.GameTypeId
ORDER BY [Forbidden Game Type] DESC,[Item]

--07. Buy Items for User in Game
