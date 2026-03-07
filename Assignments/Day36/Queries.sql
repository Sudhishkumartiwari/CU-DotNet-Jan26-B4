
-- Product Categories:
SELECT p.ProductName, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID; 

-- Customer Orders:
SELECT o.OrderID, c.CompanyName FROM Orders o JOIN Customers c ON o.CustomerID = c.CustomerID; 
  
-- Supplier Tracking:    
SELECT p.ProductName, s.CompanyName FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID;  
  
-- Employee Sales:    
SELECT o.OrderID, o.OrderDate, e.FirstName, e.LastName FROM Orders o JOIN Employees e ON o.EmployeeID = e.EmployeeID;  

-- International Logistics:    
SELECT o.OrderID, s.CompanyName FROM Orders o JOIN Shippers s ON o.ShipVia = s.ShipperID WHERE o.ShipCountry =  France ;  

-- Category Stock:    
SELECT c.CategoryName, SUM(p.UnitsInStock) FROM Categories c JOIN Products p ON c.CategoryID = p.CategoryID GROUP BY c.CategoryName;  
 
-- Customer Spend:    
SELECT c.CompanyName, SUM(od.UnitPrice * od.Quantity) AS TotalSpent FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN OrderDetails od ON o.OrderID = od.OrderID GROUP BY c.CompanyName;  

-- Employee Performance:    
SELECT e.LastName, COUNT(o.OrderID) FROM Employees e JOIN Orders o ON e.EmployeeID = o.EmployeeID GROUP BY e.LastName;  
 
-- Shipping Costs:    
SELECT s.CompanyName, SUM(o.Freight) FROM Shippers s JOIN Orders o ON s.ShipperID = o.ShipVia GROUP BY s.CompanyName;  
 
-- Top Products:    
SELECT TOP 5 p.ProductName, SUM(od.Quantity) AS TotalSold FROM Products p JOIN OrderDetails od ON p.ProductID = od.ProductID GROUP BY p.ProductName ORDER BY TotalSold DESC;  
  
-- Above Average:    
SELECT ProductName FROM Products WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);  
  
-- The Bosses (Self-Join):    
SELECT e.FirstName AS Employee, m.FirstName AS Manager FROM Employees e LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID;  

-- No Orders:    
SELECT CompanyName FROM Customers WHERE CustomerID NOT IN (SELECT CustomerID FROM Orders);  

-- High-Value Orders:    
SELECT OrderID FROM OrderDetails GROUP BY OrderID HAVING SUM(UnitPrice * Quantity) > (SELECT AVG(TotalValue) FROM (SELECT SUM(UnitPrice * Quantity) AS TotalValue FROM OrderDetails GROUP BY OrderID) AS AvgTable);  

-- Late Bloomers:    
SELECT ProductName FROM Products WHERE ProductID NOT IN (SELECT ProductID FROM OrderDetails od JOIN Orders o ON od.OrderID = o.OrderID WHERE YEAR(o.OrderDate) > 1997);  
  
-- Territory Coverage:    
SELECT e.FirstName, e.LastName, r.RegionDescription FROM Employees e JOIN EmployeeTerritories et ON e.EmployeeID = et.EmployeeID JOIN Territories t ON et.TerritoryID = t.TerritoryID JOIN Region r ON t.RegionID = r.RegionID;  
  
-- Duplicate Cities:    
SELECT c.CompanyName, s.CompanyName, c.City FROM Customers c JOIN Suppliers s ON c.City = s.City;  

-- Multi-Category Customers:    
SELECT c.CompanyName FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN OrderDetails od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID GROUP BY c.CompanyName HAVING COUNT(DISTINCT p.CategoryID) > 3;  
 
-- Discontinued Sales:    
SELECT SUM(od.UnitPrice * od.Quantity) FROM OrderDetails od JOIN Products p ON od.ProductID = p.ProductID WHERE p.Discontinued = 1;  
  
-- Correlated Subquery:    
SELECT CategoryID, ProductName, UnitPrice FROM Products p1 WHERE UnitPrice = (SELECT MAX(UnitPrice) FROM Products p2 WHERE p2.CategoryID = p1.CategoryID);  
