create database BankDb
go
use BankDb 
go

create table Client(
	Id int identity (1,1) not null primary key,
	FirstName nvarchar(100) not null,
	SecondName nvarchar(100) not null,
	DateOfBirth datetime not null
);
go

create table TypeOfBill(
	Id int identity(1,1) not null primary key,
	Name nvarchar(100) not null,
	CostOfBalance int not null,
	RefillOfBalance int not null
);
go

create table BankAccount(
	Id int identity(1,1) not null primary key,
	Number nvarchar(100) not null unique,
	Amount float not null,
	Bonus int not null,
	IsActive bit,
	TypeOfBillId int not null foreign key references TypeOfBill(id),
	ClientId int not null foreign key references Client(id)
);
go

set identity_insert TypeOfBill on;
go
insert into TypeOfBill(Id, Name, CostOfBalance, RefillOfBalance)
select 1, 'Gold', 2,2
union all
select 2, 'Premium', 3,3
union all
select 3, 'Platinum', 4,4
set identity_insert TypeOfBill off;
go
set identity_insert Client on;
go
insert into Client(Id, FirstName, SecondName,DateOfBirth)
select 1, 'Anton', 'Borisov', '19920101'
union all
select 2, 'Valera', 'Antonov', '19931212'
union all
select 3, 'Inna', 'Rafieva', '19970303'
set identity_insert Client off;
insert into BankAccount
select newid(), 1000, 0, 1, 1,1
union all
select newid(), 3000, 0, 1, 2,2
union all
select newid(), 1500, 0, 1, 3,3
go

