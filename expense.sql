select * from expense
SELECT SUM(price) FROM expense where person = 'shad';
create table expense(serial int identity(1,1) primary key,person varchar(40),item varchar(40),expdate datetime,price decimal(10,2))
select * from history
select * from history where month(expdate)=october
select * from expense where person ='shad' and price!=0
select * from history where person ='pankaj' and month(expdate)=10
create table dues(serial int identity(1,1)primary key,person varchar(40),amount decimal(10,2))
select * from dues
select amount from dues where person = 'pankaj'
update dues set amount = -234.2 where person = 'pankaj'
insert into dues values('rahul',0)