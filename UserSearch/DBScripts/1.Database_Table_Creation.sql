use UMS
go

drop table tbl_SearchParameters
go

drop table tbl_User
go

create table tbl_User
(
	UserId	int primary key, 
	UserName varchar(100) not null UNIQUE,
	Role	varchar(50) not null,
	LastLogin	datetime null,
	FName	varchar(50) not null,
	LName	varchar(50) null,
	Department	varchar(50) not null,
	DOJ	date not null,
	MgrId	int null,
	Seniority	decimal(3,2) not null,
	EmpCode varchar(20) not null UNIQUE
)
go

create table tbl_SearchParameters
(
	Id int primary key identity(1,1),
	UserId int FOREIGN KEY REFERENCES tbl_User(UserId),
	SearchCriteria varchar(max)
)
go

