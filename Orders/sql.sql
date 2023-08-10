CREATE TABLE [dbo].[Status] (
    [Id] INT PRIMARY KEY,
    [Name] VARCHAR(50),
    [Description] VARCHAR(255)
    );

INSERT INTO Status (Id, Name, Description)
VALUES
    (1, 'New', 'The task or item is in a new state, not yet started.'),
    (2, 'InProgress', 'The task or item is currently being worked on.'),
    (3, 'Done', 'The task or item has been completed successfully.'),
    (4, 'Canceled', 'The task or item has been canceled or terminated.');


CREATE TABLE [dbo].[Customer] (
    Id INT PRIMARY KEY, 
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20));


INSERT INTO [dbo].[Customer] (Id, FirstName, LastName, Email, PhoneNumber)
VALUES
    (1, 'John', 'Doe', 'john.doe@example.com', '123-456-7890'),
    (2, 'Jane', 'Smith', 'jane.smith@example.com', '987-654-3210'),
    (3, 'Michael', 'Johnson', 'michael.johnson@example.com', '555-123-4567');

SELECT * FROM dbo.Customer

CREATE TABLE [dbo].[Order] (
                               Id INT IDENTITY(1,1) PRIMARY KEY,
                               CustomerId INT,
                               OrderDate DATETIME,
                               TotalAmount DECIMAL(10, 2),
    StatusId INT,
    FOREIGN KEY (CustomerID) REFERENCES [dbo].[Customer](Id),
    FOREIGN KEY (StatusID) REFERENCES [dbo].[Status](Id)
    );


INSERT INTO [dbo].[Order] (CustomerId, OrderDate, TotalAmount, StatusID)
VALUES
    (1, '2023-07-01', 150.00, 1),
    (2, '2023-07-02', 200.50, 2),
    (3, '2023-07-03', 75.25, 1),
    (1, '2023-07-04', 300.00, 3),
    (1, '2023-07-05', 50.00, 1),
    (3, '2023-07-06', 180.75, 2),
    (2, '2023-07-07', 90.00, 1),
    (2, '2023-07-08', 500.25, 3),
    (1, '2023-07-09', 30.50, 1),
    (1, '2023-07-10', 210.00, 2),
    (3, '2023-07-25', 75.00, 1),
    (2, '2023-07-26', 120.50, 2),
    (2, '2023-07-27', 95.75, 1),
    (1, '2023-07-28', 180.00, 3),
    (1, '2023-07-29', 40.00, 1),
    (3, '2023-07-30', 300.25, 2),
    (2, '2023-07-31', 85.00, 1),
    (2, '2023-08-01', 175.50, 2),
    (1, '2023-08-02', 60.25, 1),
    (1, '2023-08-03', 240.00, 3),
    (3, '2023-08-04', 25.00, 1),
    (1, '2023-08-05', 300.75, 2),
    (2, '2023-08-06', 130.00, 1),
    (2, '2023-08-07', 50.25, 2),
    (1, '2023-08-08', 110.50, 1),
    (3, '2023-08-09', 90.00, 3);