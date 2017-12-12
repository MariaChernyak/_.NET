use BankDb 
go

create table Client(
	id int identity (1,1) not null primary key,
	first_name nvarchar(100) not null,
	second_nme nvarchar(100) not null,
	date_of_birth datetime not null
);
go

create table TypeOfBill(
	id int identity(1,1) not null primary key,
	name nvarchar(100) not null,
	cost_of_balance int not null,
	refill_of_balance int not null
);
go

create table BankAccount(
	id int identity(1,1) not null primary key,
	number nvarchar(100) not null unique,
	amount float not null,
	bonus int not null,
	typ_of_bill_id int not null foreign key references TypeOfBill(id),
	client_id int not null foreign key references Client(id)
);
go