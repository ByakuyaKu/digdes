
--6----
ALTER PROCEDURE HumanResources.GetSingleInRnage
(@fromDate AS DATE, 
 @toDate AS DATE,
 @count AS INT OUTPUT)
AS
BEGIN
SELECT BusinessEntityID, MaritalStatus, BirthDate
FROM HumanResources.Employee
WHERE MaritalStatus = 'S' AND Gender = 'M' AND BirthDate BETWEEN @fromDate AND @toDate
SET @count = @@ROWCOUNT
END
GO

---5---
SELECT SalesOrderHeader.CustomerID, Person.FirstName, Person.LastName, SalesOrderHeader.SalesOrderID, Product.Name FROM Person.Person 
JOIN Sales.SalesOrderHeader ON (Sales.SalesOrderHeader.CustomerID = Person.Person.BusinessEntityID) 
JOIN Sales.SalesOrderDetail ON (SalesOrderDetail.SalesOrderID = Sales.SalesOrderHeader.SalesOrderID)
JOIN Production.Product ON (Production.Product.ProductID = Sales.SalesOrderDetail.ProductID) ORDER BY Person.FirstName, Person.LastName --как выбрать только первую запись не додумался

--3---
SELECT SalesOrderHeader.CustomerID, Person.FirstName, Person.LastName, Product.Name, SalesOrderDetail.OrderQty FROM Person.Person 
JOIN Sales.SalesOrderHeader ON (SalesOrderHeader.CustomerID = Person.BusinessEntityID) 
JOIN Sales.SalesOrderDetail ON (SalesOrderDetail.SalesOrderID = Sales.SalesOrderHeader.SalesOrderID)
JOIN Production.Product ON (Product.ProductID = SalesOrderDetail.ProductID)---тоже не додумал)