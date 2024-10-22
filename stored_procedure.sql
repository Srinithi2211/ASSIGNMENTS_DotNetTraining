
use BikeStores;

-- A list of all customers purchased a specific product
CREATE PROCEDURE GetCustomerbyProductID
@product_id int
AS
BEGIN
SELECT c.customer_id, c.first_name,c.last_name, o.required_date as Purchase_date
from sales.customers as c
JOIN sales.orders as o ON c.customer_id=o.customer_id
JOIN  sales.order_items oi ON o.order_id = oi.order_id
JOIN  production.products p ON oi.product_id = p.product_id
WHERE  p.product_id = @product_id
END;

EXEC GetCustomerbyProductID @product_id = 22;