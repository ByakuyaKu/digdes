
CREATE TABLE Adresses 
( AdressID int IDENTITY(0 ,1) CONSTRAINT PK_AdressID PRIMARY KEY NOT NULL, 
City NVARCHAR (50) NOT NULL, 
Street NVARCHAR (50) NOT NULL,
NumberOfHouse INT NOT NULL)
GO

CREATE TABLE Customers
( CustomerID INT IDENTITY(0 ,1) CONSTRAINT PK_CustomerID PRIMARY KEY NOT NULL, 
FirstName NVARCHAR (50) NOT NULL, 
LastName NVARCHAR (50) NOT NULL,
ThirdName NVARCHAR (50) NULL,
Sex Nchar NOT NULL,
AdressID INT NOT NULL,
FOREIGN KEY ( AdressID ) REFERENCES Adresses( AdressID ))
GO

CREATE TABLE Goods 
( GoodsID INT IDENTITY(0 ,1) CONSTRAINT PK_GoodsID PRIMARY KEY NOT NULL, 
[Name] NVARCHAR (50) NOT NULL,
PriceForOne MONEY NOT NULL)
GO

CREATE TABLE Orders 
( OrderID INT CONSTRAINT PK_OrderID PRIMARY KEY NOT NULL, 
Qnty INT NOT NULL,
GoodsID INT NOT NULL,
CustomerID INT NOT NULL,
TotalPrice INT NULL,
FOREIGN KEY ( GoodsID ) REFERENCES Goods( GoodsID ),
FOREIGN KEY ( CustomerID ) REFERENCES Customers( CustomerID ))
GO