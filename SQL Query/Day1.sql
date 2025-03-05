--create database
create database BookStoreDB;

create table  Authors(AuthorID int Primary key,Name varchar(20),Country varchar(20));
insert into Authors values
(1 ,'Chetan Bhagat','India'),
(2,'Ashok Banker','Japan'),
(3,'Nazi Boni','Canada'),
(4,'Rakesh','India'),
(5,'J.K. Rowling', 'United Kingdom')



select * from Authors;

--Create book Table
create table Books(
BookID int primary key ,
Title nvarchar(200) not null,
AuthorID int not null,
Price decimal(10,2) not null,
PublishedYear int not null,
constraint FK_Books_Author foreign key (AuthorID) references Authors(AuthorID) on delete cascade
);

-- Insert data into Books table
insert into Books values 
(1,'Harry Potter and the Sorcerer''s Stone', 1, 20.99, 1997),
(2,'1984', 2, 15.50, 1949),
(3,'Pride and Prejudice', 3, 18.75, 1813),
(4,'The Adventures of Tom Sawyer', 4, 12.99, 1876),
(5,'Murder on the Orient Express', 5, 22.99, 1934);

update Books 
set Title ='SQL Mastery'
where BookID =3;
select * from Books;
update Books 
set PublishedYear=2020
where BookID =1;
update Books 
set PublishedYear=2017
where BookID =5;
select * from Books;
update Books 
set Price= 3000
where BookID =4;
select * from Books;

--create Customers table
create table Customers(
CustomerID int identity(100,1) primary key,
Name nvarchar(255) not null,
Email nvarchar(255) not null unique,
PhoneNumber nvarchar(15) not null unique 
)


-- Insert data into Customers table
INSERT INTO Customers (Name, Email, PhoneNumber) VALUES 
('Alice Johnson', 'alice@example.com', '1234567890'),
('Bob Smith', 'bob@example.com', '9876543210'),
('Charlie Brown', 'charlie@example.com', '1122334455'),
('David Wilson', 'david@example.com', '5566778899'),
('Emma Davis', 'emma@example.com', '6677889900');

select * from Customers;
drop table Customers
drop database BookStoreDB

update Customers
set Name ='Ajay'
where CustomerID=102;


--create Orders table
create table Orders(
OrderID int identity(1,1) primary key,
CustomerID int not null,
OrderDate date not null default getdate(),
TotalAmount decimal(10,2) not null check (TotalAmount>=0),
constraint FK_Orders_Customer foreign key (CustomerID) references Customers(CustomerID) on delete cascade
);

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES 
(100, '2025-03-01', 41.98),
(101, '2025-03-02', 15.50),
(102, '2025-03-03', 18.75),
(103, '2025-03-04', 25.98),
(101, '2025-03-05', 45.98);


drop table Orders;
select * from Orders;

-- OrderItems (OrderItemID, OrderID, BookID, Quantity, SubTotal)
create table OrderItems(
OrderItemID int identity(1,1) primary key,
OrderID int not null,
BookID int not null,
Quantity int not null check(Quantity>0),
SubTotal decimal(10,2) not null check(SubTotal>0),
constraint FK_OrderItems_Order foreign key (OrderID) references Orders(OrderID) on delete cascade,
constraint FK_OrderItems_Book foreign key (BookID) references Books(BookID) on delete cascade

);

-- Insert data into OrderItems table
INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal) VALUES 
(1, 1, 2, 41.98),
(2, 2, 1, 15.50),
(3, 3, 1, 18.75),
(4, 4, 2, 25.98),
(5, 5, 2, 45.98);



select * from OrderItems;



-- Update the price of a book titled "SQL Mastery" by increasing it by 10%.

update Books
set Price=Price*1.10
where Title='SQL Mastery';
select *from Books


--Delete a customer who has not placed any orders.
delete from Customers
where CustomerID not in (select CustomerID from Orders)
select * from Customers


--Operators 
--1. Retrieve all books with a price greater than 2000
select * from Books where Price>2000

--2. Find the total number of books available

select count(*) as TotalBooks from Books

--3. Find books published between 2015 and 2023
select * from Books 
where PublishedYear between 2015 and 2023

--4. Find all customers who have placed at least one order

select distinct C.*
from Customers C
join Orders O
on C.CustomerId=O.CustomerID


--5. Retrieve books where the title contains the word "SQL"
select * from Books
where Title like '%SQL%'



--6. Find the most expensive book in the store

Select top 1 * from Books
order by Price desc

--7. Retrieve customers whose name starts with "A" or "J"

select * from Customers
where Name like 'A%' or Name like 'J%'


--8. Calculate the total revenue from all orders

select sum(TotalAmount) as TotalRevenue
from Orders;






