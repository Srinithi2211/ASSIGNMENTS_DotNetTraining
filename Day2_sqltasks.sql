--task 7

CREATE TRIGGER trg_UpdateStockOnNewOrder
ON sales.order_items
AFTER INSERT
AS
BEGIN
    UPDATE production.stocks
    SET quantity = s.quantity - i.quantity
    FROM production.stocks s
    JOIN inserted i ON s.product_id = i.product_id
    JOIN sales.orders o ON o.order_id = i.order_id
    WHERE s.store_id = o.store_id;

    
    IF EXISTS (SELECT 1 FROM production.stocks WHERE quantity < 0)
    BEGIN
        RAISERROR('Stock level cannot be negative!', 16, 1);
    END
END;

INSERT INTO sales.orders (customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES (137, 3, '2024-10-10', '2024-10-20', '2024-10-01', 1, 8);

INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES (SCOPE_IDENTITY(), 1, 153, 5, 1500.00, 0.10);  

--task 8
CREATE TRIGGER trg_PreventCustomerDeletion
ON sales.customers
INSTEAD OF DELETE
AS
BEGIN
  
    IF EXISTS (
        SELECT 1
        FROM deleted d
        INNER JOIN sales.orders o ON d.customer_id = o.customer_id
    )
    BEGIN
        
        RAISERROR('Cannot delete customer with existing orders.', 16, 1);
        RETURN;
    END

    DELETE FROM sales.customers
    WHERE customer_id IN (SELECT customer_id FROM deleted);
END;

DELETE FROM sales.customers WHERE customer_id = 137;

DELETE FROM sales.customers WHERE customer_id = 58;
select *from sales.orders

--task 9

CREATE TABLE Employee2 (
    employee_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50),
    department NVARCHAR(100),
    salary DECIMAL(10, 2)
);


CREATE TABLE Employee_Audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50),
    department NVARCHAR(100),
    salary DECIMAL(10, 2),
    operation NVARCHAR(10),   -- This will INSERT, UPDATE, or DELETE
    change_date DATETIME DEFAULT GETDATE() 
);
INSERT INTO Employee2 (first_name, last_name, department, salary)
VALUES
('Tom ', 'Holland', 'IT', 60000),
('Andrew', 'Garfield', 'HR', 55000),
('Robert', 'Johnson', 'Finance', 75000);
-- trigger 
CREATE TRIGGER trg_EmployeeAudit
ON Employee2
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO Employee_Audit (employee_id, first_name, last_name, department, salary, operation)
        SELECT i.employee_id, i.first_name, i.last_name, i.department, i.salary, 'INSERT'
        FROM inserted i;
    END

    
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Employee_Audit (employee_id, first_name, last_name, department, salary, operation)
        SELECT d.employee_id, d.first_name, d.last_name, d.department, d.salary, 'DELETE'
        FROM deleted d;
    END

    
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Employee_Audit (employee_id, first_name, last_name, department, salary, operation)
        SELECT i.employee_id, i.first_name, i.last_name, i.department, i.salary, 'UPDATE'
        FROM inserted i;
    END
END;
INSERT INTO Employee2 (first_name, last_name, department, salary)
VALUES ('Preethi', 'Kumar', 'Finance', 55000.00);

UPDATE Employee2
SET salary = 65000.00
WHERE employee_id = 2;

DELETE FROM Employee2
WHERE employee_id = 1;

--task 10
CREATE TABLE Room (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomType NVARCHAR(50),
    Availability BIT 
);
CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT,
    CustomerName NVARCHAR(100),
    CheckInDate DATE,
    CheckOutDate DATE,
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID)
);
INSERT INTO Room (RoomType, Availability) 
VALUES 
('Deluxe', 1), 
('Standard', 1), 
('Suite', 1); 

INSERT INTO Bookings (RoomID, CustomerName, CheckInDate, CheckOutDate)
VALUES 
(1, 'Anbu', '2024-10-10', '2024-10-18'),
(2, 'Iniya', '2024-10-16', '2024-10-19');

BEGIN TRANSACTION;
IF EXISTS (SELECT 1 FROM Room WHERE RoomID = 3 AND Availability = 1)
BEGIN
    INSERT INTO Bookings (RoomID, CustomerName, CheckInDate, CheckOutDate)
    VALUES (3, 'sri', '2024-10-20', '2024-10-25');

    UPDATE Room
    SET Availability = 0
    WHERE RoomID = 3;

    COMMIT;
    PRINT 'Room booked successfully and marked as unavailable';
END
ELSE
BEGIN
    ROLLBACK;
    PRINT 'The room is not available for booking.';
END;