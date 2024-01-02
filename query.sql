

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SkiServiceManagement')
BEGIN
    CREATE DATABASE SkiServiceManagement;
END
GO

USE SkiServiceManagement;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Orders') AND type in (N'U'))
BEGIN
    CREATE TABLE Orders (
        OrderID INT PRIMARY KEY IDENTITY(1,1),
        CustomerName NVARCHAR(100),
        CustomerEmail NVARCHAR(100),
        CustomerPhone NVARCHAR(20),
        Priority NVARCHAR(50),
        ServiceType NVARCHAR(100),
        CreateDate DATETIME,
        PickupDate DATETIME,
        Status NVARCHAR(50) DEFAULT 'Offen',
		Comment NVARCHAR(100) DEFAULT ''
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Employees') AND type in (N'U'))
BEGIN
    CREATE TABLE Employees (
        EmployeeID INT PRIMARY KEY IDENTITY(1,1),
        Username NVARCHAR(50) NOT NULL,
        [Password] NVARCHAR(50) NOT NULL,
    );
END
GO

-- -------------------------- Fill Database with Test Data --------------------------


-- Inserting test data into the Orders table
INSERT INTO Orders (CustomerName, CustomerEmail, CustomerPhone, Priority, ServiceType, CreateDate, PickupDate, Status, Comment)
VALUES
    ('Arda Baselstadt 1', 'arda@baselstadt.com', '555-1234', 'High', 'Heisswachsen', '2023-12-21T08:00:00', '2023-12-23T15:00:00', 'Offen', 'BaselStadt'),
    ('Max Muster', 'max.muster@gmx.com', '0765868874', 'High', 'Fell zuschneiden', '2023-12-21T08:00:00', '2023-12-23T15:00:00', 'Offen', '')




-- Inserting admin into the Employees table
INSERT INTO Employees(Username, [Password])
VALUES
    ('admin', 'admin'), -- Default Admin-Benutzer
    ('julia.meier', 'Julia2024!'),
    ('max.klein', 'MaxGeheim#23'),
    ('sara.schmidt', 'Sara$Pass88'),
    ('lukas.gruber', 'Lukas_456'),
    ('emma.ziegler', 'EmmaZ2024'),
    ('leo.hofmann', 'Leo12345'),
    ('mia.wagner', 'Mia#Secure!9'),
    ('felix.weber', 'Felix$2024'),
    ('lena.schulz', 'LenaPasswort!'),
    ('niklas.fischer', 'Niklas1234');


-- Query to verify the inserted data
SELECT * FROM Orders;
SELECT * FROM Employees;
