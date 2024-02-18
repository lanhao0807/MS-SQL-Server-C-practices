use Northwind
go

-- 1.      List all cities that have both Employees and Customers.
select distinct city from Employees where city in (select city from Customers)

-- 2.      List all cities that have Customers but no Employee.
-- a.      Use sub-query
select distinct city from Customers where city not in (select city from Employees)

-- b.      Do not use sub-query
select distinct city from Customers except select city from Employees

-- 3.      List all products and their total order quantities throughout all orders.
select p.productName, sum(o.Quantity) total_quantities from Products p 
left join [Order Details] o on o.ProductID = p.ProductID
group by p.productName

-- 4.      List all Customer Cities and total products ordered by that city.
select c.city, sum(o2.quantity) total_product_ordered 
from Customers c join Orders o on o.CustomerID = c.CustomerID 
join [Order Details] o2 on o.OrderID = o2.OrderID
group by c.city

-- 5.      List all Customer Cities that have at least two customers.
-- a.      Use union
select city from Customers group by city having count(*) = 2
union
select city from Customers group by city having count(*) > 2

-- b.      Use sub-query and no union
select distinct city
from (
  select city, count(*) over (partition by city) customer_count
  from Customers
) as customer_counts
where customer_count > 1;

-- 6.      List all Customer Cities that have ordered at least two different kinds of products.
select c.city
from Customers c join Orders o on o.CustomerID = c.CustomerID 
join [Order Details] o2 on o.OrderID = o2.OrderID
group by c.city having count(distinct o2.ProductID) > 1

-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
select distinct c.CustomerID from Customers c join Orders o on o.CustomerID = c.CustomerID
where c.City <> o.ShipCity

-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
select top 5
    p.productName,
    avg(o.UnitPrice) as avg_price,
    c.city
from
    Products p
join
    [Order Details] o on o.ProductID = p.ProductID
join
    Orders o2 on o2.OrderID = o.OrderID
join
    Customers c on o2.CustomerID = c.CustomerID
group by
    p.productName, c.city
order by
    sum(o.Quantity) desc;

-- 9.      List all cities that have never ordered something but we have employees there.
-- a.      Use sub-query
select e.city from Employees e where city not in 
(select o.shipCity from Orders o)
-- b.      Do not use sub-query
select e.city from Employees e
except select o.shipCity from Orders o

-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
declare @topcityfromorders nvarchar(255);
declare @topcityfromemployees nvarchar(255);

select top 1 @topcityfromorders = shipcity
from orders o
join [order details] o2 on o.orderid = o2.orderid
group by shipcity
order by sum(o2.quantity) desc;

select top 1 @topcityfromemployees = e.city
from employees e
join orders o on o.employeeid = e.employeeid
group by e.city
order by count(*) desc;

if (@topcityfromorders = @topcityfromemployees)
begin
    select @topcityfromorders;
end
else
begin
    print 'the top cities are not equal.';
end;

-- 11. How do you remove the duplicates record of a table?
-- suppose table Orders has only two columns shipCity and shipCountry
select distinct shipCity, shipCountry
into #TempOrders
FROM Orders;
-- delete the original table
truncate table Orders;
-- push distinct values back to the new created Orders table
insert Orders (shipCity, shipCountry)
select shipCity, shipCountry
from #TempOrders;
drop table #TempOrders;