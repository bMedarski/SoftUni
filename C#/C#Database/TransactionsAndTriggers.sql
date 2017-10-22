
--01. Create Table Logs
CREATE TABLE Logs
(
	LogId INT, 
	AccountId INT, 
	OldSum Money, 
	NewSum Money
)
GO
CREATE TRIGGER Tr_SaveTransfer ON Accounts FOR UPDATE
AS
	BEGIN
		DECLARE @AccountId INT = (SELECT Id FROM deleted)
		DECLARE @OldSum Money = (SELECT Balance FROM deleted)
		DECLARE @NewSum Money = (SELECT Balance FROM inserted)

		INSERT INTO Logs VALUES
		(@AccountId,@OldSum,@NewSum)

	END
GO
--02. Create Table Emails
CREATE TRIGGER tr_LogsNotificationEmails ON Logs FOR INSERT
AS
BEGIN

  DECLARE @recipient int = (SELECT AccountId FROM inserted);
  DECLARE @oldBalance money = (SELECT OldSum FROM inserted);
  DECLARE @newBalance money = (SELECT NewSum FROM inserted);
  DECLARE @subject varchar(200) = CONCAT('Balance change for account: ', @recipient);
  DECLARE @body varchar(200) = CONCAT('On ', GETDATE(), ' your balance was changed from ', @oldBalance, ' to ', @newBalance, '.');  

  INSERT INTO NotificationEmails (Recipient, Subject, Body) 
  VALUES (@recipient, @subject, @body)
END
GO
--03. Deposit Money
CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY) 
AS 
BEGIN
	 BEGIN TRANSACTION;

		IF(@MoneyAmount<0)
		BEGIN
			ROLLBACK;
			RAISERROR ('Invalid ammount!', 16, 1);
			RETURN;
		END
		
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId

	COMMIT
END
GO
--04. Withdraw Money Procedure
CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY) 
AS 
BEGIN
	 BEGIN TRANSACTION;

		IF(@MoneyAmount<0)
		BEGIN
			ROLLBACK;
			RAISERROR ('Invalid ammount!', 16, 1);
			RETURN;
		END
		
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

	COMMIT
END
GO
--05. Money Transfer
CREATE PROCEDURE usp_TransferMoney (@SenderId INT,@ReceiverId INT, @MoneyAmount MONEY) 
AS 
BEGIN
	 BEGIN TRANSACTION;

		IF(@MoneyAmount<0)
		BEGIN
			ROLLBACK;
			RAISERROR ('Invalid ammount!', 16, 1);
			RETURN;
		END
		
		DECLARE @senderMoney MONEY = (Select Balance FROM Accounts WHERE Id = @SenderId)
		
		IF(@senderMoney<@MoneyAmount)
		BEGIN
			ROLLBACK;
			RAISERROR ('Insificient money!', 16, 2);
			RETURN;
		END

		UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @ReceiverId

		UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @SenderId

		IF(@@ROWCOUNT <> 1) 
	  BEGIN
		ROLLBACK; 
		RAISERROR('Could not make payment', 16, 3); 
		RETURN;
	  END

	COMMIT
END
GO
--07. *Massive Shopping
DECLARE @gameName nvarchar(50) = 'Safflower';
DECLARE @username nvarchar(50) = 'Stamat';

DECLARE @userGameId int = (
  SELECT ug.Id 
  FROM UsersGames AS ug
  JOIN Users AS u ON ug.UserId = u.Id
  JOIN Games AS g ON ug.GameId = g.Id
  WHERE u.Username = @username AND g.Name = @gameName

);

DECLARE @userGameLevel int = (SELECT Level FROM UsersGames WHERE Id = @userGameId);
DECLARE @itemsCost money, @availableCash money, @minLevel int, @maxLevel int;



-- Buy items from LEVEL 11-12
SET @minLevel = 11; SET @maxLevel = 12;
SET @availableCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
SET @itemsCost = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel);



/* begin transaction only if: enough game cash to buy all requested items & 
   high enough user game level to meet item minlevel requirement */

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel) 

BEGIN 
  BEGIN TRANSACTION  
  UPDATE UsersGames SET Cash -= @itemsCost WHERE Id = @userGameId; 
  IF(@@ROWCOUNT <> 1) 
  BEGIN
    ROLLBACK; RAISERROR('Could not make payment', 16, 1); --RETURN;
  END

  ELSE
  BEGIN

    INSERT INTO UserGameItems (ItemId, UserGameId) 
    (SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel) 

    IF((SELECT COUNT(*) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
    BEGIN
      ROLLBACK; RAISERROR('Could not buy items', 16, 1); --RETURN;
    END	

    ELSE COMMIT;

  END

END



-- Buy items from LEVEL 19-21
SET @minLevel = 19; SET @maxLevel = 21;
SET @availableCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
SET @itemsCost = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel);

/* begin transaction only if: enough game cash to buy all requested items & 
   high enough user game level to meet item minlevel requirement */

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel) 

BEGIN 
  BEGIN TRANSACTION  
  UPDATE UsersGames SET Cash -= @itemsCost WHERE Id = @userGameId; 

  IF(@@ROWCOUNT <> 1) 
  BEGIN
    ROLLBACK; RAISERROR('Could not make payment', 16, 1); --RETURN;
  END

  ELSE
  BEGIN

    INSERT INTO UserGameItems (ItemId, UserGameId) 
    (SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel) 

    IF((SELECT COUNT(*) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
    BEGIN
      ROLLBACK; RAISERROR('Could not buy items', 16, 1); --RETURN;
    END	

    ELSE COMMIT;
  END

END

-- select items in game
SELECT i.Name AS [Item Name]
FROM UserGameItems AS ugi
JOIN Items AS i ON i.Id = ugi.ItemId
JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
JOIN Games AS g ON g.Id = ug.GameId
WHERE g.Name = @gameName
ORDER BY [Item Name]
--08. Employees with Three Projects
CREATE PROCEDURE usp_AssignProject (@employeeID int, @projectID int)
AS
BEGIN

  DECLARE @maxEmployeeProjectsCount int = 3;
  DECLARE @employeeProjectsCount int;

  BEGIN TRAN
  INSERT INTO EmployeesProjects (EmployeeID, ProjectID) 
  VALUES (@employeeID, @projectID)

  SET @employeeProjectsCount = (
    SELECT COUNT(*)
    FROM EmployeesProjects
    WHERE EmployeeID = @employeeID

  )

  IF(@employeeProjectsCount > @maxEmployeeProjectsCount)

    BEGIN
      RAISERROR('The employee has too many projects!', 16, 1);
      ROLLBACK;
    END

  ELSE COMMIT

END
--