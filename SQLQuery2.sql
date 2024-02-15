use AdventureWorks2019
go

-- 1.      How many products can you find in the Production.Product table?
select distinct count(productID) from Production.Product

-- 2.      Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
select count(*) from (select * from Production.Product where ProductSubcategoryID is not null) as a

-- 3.      How many Products reside in each SubCategory? Write a query to display the results with the following titles.
--			ProductSubcategoryID CountedProducts
select ProductSubcategoryID, count(ProductSubcategoryID) as CountedProducts 
from Production.Product where ProductSubcategoryID is not null 
group by ProductSubcategoryID
-- -------------------- ---------------

-- 4.      How many products that do not have a product subcategory.
select count(*) from Production.Product where ProductSubcategoryID is null

-- 5.      Write a query to list the sum of products quantity in the Production.ProductInventory table.
select sum(Quantity) from Production.ProductInventory

-- 6.    Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
--               ProductID    TheSum
--               -----------        ----------
select ProductID, sum(Quantity) as TheSum from Production.ProductInventory where LocationID = 40 group by ProductID having sum(Quantity) < 100

-- 7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
--     Shelf      ProductID    TheSum
--     ----------   -----------        -----------
select shelf, ProductID, sum(Quantity) as TheSum from Production.ProductInventory where LocationID = 40 group by shelf, ProductID having sum(Quantity) < 100

-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
select ProductID, avg(Quantity) from Production.ProductInventory where LocationID = 10 group by ProductID 

-- 9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
--     ProductID   Shelf      TheAvg
--     ----------- ---------- -----------
select ProductID, shelf, avg(Quantity) as TheAvg from Production.ProductInventory group by productID, shelf

-- 10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
--     ProductID   Shelf      TheAvg
--     ----------- ---------- -----------
select ProductID, shelf, avg(Quantity) as TheAvg from Production.ProductInventory where shelf != 'N/A' group by productID, shelf

-- 11.  List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
--     Color                        Class              TheCount          AvgPrice
select Color, Class, count(*) as TheCount, avg(ListPrice) as AvgPrice from Production.Product where color is not null and class is not null group by color, class

--Joins:

--12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
--    Country                        Province
select c.name, s.name from person.CountryRegion as c join person.StateProvince as s on c.CountryRegionCode = s.CountryRegionCode

--13.  Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
--    Country                        Province
select c.name, s.name from person.CountryRegion as c join person.StateProvince as s on c.CountryRegionCode = s.CountryRegionCode
where c.name in ('Germany', 'Canada')

--  Using Northwnd Database: (Use aliases for all the Joins)
use Northwind
go

select * from Products
select * from Orders
select * from [Order Details]
select * from Region
select * from Customers
-- 14.  List all Products that has been sold at least once in last 25 years.
select p.ProductID, p.ProductName from Products p
join [Order Details] as o on p.ProductID = o.productID
join Orders as o2 on o.OrderID = o2.OrderID
where o2.OrderDate > DATEADD(YEAR, -25, GETDATE())
-- no records shown as no order made after 1998

-- 15.  List top 5 locations (Zip Code) where the products sold most.
select o.ShipPostalCode, count(*) from Orders as o join [Order Details] as o2 on o.OrderID = o2.OrderID
-- add "WHERE o.ShipPostalCode is not null" to exclude null postal code if needed as the 5th one is null
group by o.ShipPostalCode
order by count(*) desc

-- 16.  List top 5 locations (Zip Code) where the products sold most in last 25 years.
select o.ShipPostalCode, count(*) from Orders as o join [Order Details] as o2 on o.OrderID = o2.OrderID
where o.OrderDate > DATEADD(YEAR, -25, GETDATE())
group by o.ShipPostalCode
order by count(*) desc

-- 17.   List all city names and number of customers in that city.     
select shipcity, count(distinct CustomerID) as numberOfCustomers from Orders group by ShipCity

-- 18.  List city names which have more than 2 customers, and number of customers in that city
select shipcity, count(distinct CustomerID) as numberOfCustomers from Orders group by ShipCity having count(distinct CustomerID)>2

-- 19.  List the names of customers who placed orders after 1/1/98 with order date.
select c.CompanyName, o.OrderDate from Customers c join Orders o on o.CustomerID = c.CustomerID where o.OrderDate > '1998-01-01'

-- 20.  List the names of all customers with most recent order dates
select c.CompanyName, max(o.OrderDate) from Customers c join Orders o on o.CustomerID = c.CustomerID 
group by c.CompanyName

-- 21.  Display the names of all customers  along with the  count of products they bought
select c.CompanyName, sum(o2.Quantity) as CountOfProducts from Customers c 
join Orders o on o.CustomerID = c.CustomerID 
join [Order Details] o2 on o.OrderID = o2.OrderID
group by c.CompanyName

-- 22.  Display the customer ids who bought more than 100 Products with count of products.
select CustomerID, sum(o2.Quantity) from Orders o join [Order Details] o2 on o2.OrderID = o.OrderID
group by CustomerID having sum(o2.Quantity) > 100

-- 23.  List all of the possible ways that suppliers can ship their products. Display the results as below
--     Supplier Company Name                Shipping Company Name
select distinct s.companyName as [supplier company name], sh.companyName as [Shipping Company Name] from Suppliers s  
join Products p on p.SupplierID = s.SupplierID 
join [Order Details] od on od.ProductID = p.ProductID
join Orders o on o.OrderID = od.OrderID
join Shippers sh on o.ShipVia = sh.ShipperID


-- 24.  Display the products order each day. Show Order date and Product Name.
select o.OrderDate, p.ProductName
from Orders o
join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
order by o.OrderDate, p.ProductName;

-- 25.  Displays pairs of employees who have the same job title.
select e1.employeeid as employee1id, e1.firstname as employee1firstname, e1.lastname as employee1lastname,
       e2.employeeid as employee2id, e2.firstname as employee2firstname, e2.lastname as employee2lastname,
       e1.title
from employees e1
join employees e2 on e1.title = e2.title and e1.employeeid != e2.employeeid;

-- 26.  Display all the Managers who have more than 2 employees reporting to them.
select m.firstName, m.lastName, m.EmployeeID, count(*) as numberofemployees from Employees m
join Employees e on m.EmployeeID = e.ReportsTo
group by m.firstName, m.lastName, m.EmployeeID
having count(*) > 2

-- 27.  Display the customers and suppliers by city. The results should have the following columns
-- City
-- Name
-- Contact Name,
-- Type (Customer or Supplier)
select city, CompanyName, ContactName, 'Customer' as Type from Customers c 
union all
select city, CompanyName, ContactName, 'Supplier' from Suppliers s 
order by city
