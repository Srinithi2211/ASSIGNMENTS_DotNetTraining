use BikeStores;

--TASK3 User-Defined Function to Calculate the Total Price Based on ProductID and Quantity
CREATE FUNCTION CalculateTotalPrice
(
    @ProductID INT,
    @Quantity INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
DECLARE @TotalPrice DECIMAL(10, 2);
SELECT @TotalPrice = (list_price * @Quantity)
FROM production.products
WHERE product_id = @ProductID;
RETURN @TotalPrice;
END;

SELECT dbo.CalculateTotalPrice(1, 5);

--TASK4 User-Defined Function to Retrieve Orders for a Specific Customer with Order Details
CREATE FUNCTION ITVF_GetCustomerOrders
(
    @CustomerID INT
)
RETURNS TABLE
AS
RETURN
(
SELECT 
o.order_id,
o.order_date,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS TotalAmount
FROM sales.orders o
JOIN sales.order_items oi ON o.order_id = oi.order_id
WHERE o.customer_id = @CustomerID
GROUP BY o.order_id, o.order_date
);


SELECT * FROM dbo.ITVF_GetCustomerOrders(1);

--TASK5
CREATE FUNCTION CalculateTotalSalesForProducts()
RETURNS @TotalSalesTable TABLE
(
    product_id INT,
    product_name VARCHAR(255),
    total_sales DECIMAL(15, 2)
)
AS
BEGIN
INSERT INTO @TotalSalesTable (product_id, product_name, total_sales)
SELECT 
p.product_id,
p.product_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM production.products p
JOIN sales.order_items oi ON p.product_id = oi.product_id
GROUP BY p.product_id, p.product_name;
RETURN;
END;
SELECT * FROM dbo.CalculateTotalSalesForProducts();

-- TASK 6
CREATE FUNCTION GetCustomerTotalSpent()
RETURNS @CustomerTotalSpent TABLE
(
    customer_id INT,
    first_name VARCHAR(255),
	last_name VARCHAR(255),
    total_spent DECIMAL(15, 2)
)
AS
BEGIN
INSERT INTO @CustomerTotalSpent (customer_id, first_name,last_name, total_spent)
SELECT 
c.customer_id,
c.first_name, 
c.last_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_spent
FROM sales.customers c
JOIN sales.orders o ON c.customer_id = o.customer_id
JOIN sales.order_items oi ON o.order_id = oi.order_id
GROUP BY c.customer_id, c.first_name, c.last_name;
RETURN;
END;
SELECT * FROM dbo.GetCustomerTotalSpent();

