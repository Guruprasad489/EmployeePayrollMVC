--Create Emp Payroll Database
create database empPayrollMVC;

--Show databases
EXEC sp_databases;

--Switch(To Use) to database
use empPayrollMVC;

--Create table
create table employee_payroll(
	EmpId int identity (1,1) primary key,
	Name varchar(200),
	ProfileImage varchar(200),
	Gender char(1),
	Dept varchar(200),
	Salary float,
	StartDate date,
	Notes varchar(200));

--Insert employee_payroll data as part of CURD Operation
insert into employee_payroll(Name, ProfileImage, Gender, Dept, Salary, StartDate, Notes) values
('Guru', 'image1', 'M', 'Dev', 30000.00, '2017-07-03', 'mvc web applications'),
('Guruprasad', 'image2', 'M', 'Dev', 36000.00, '2017-08-19', 'mvc web applications'),
('Raj', 'image3', 'M', 'IT', 37000.00, '2018-07-03', 'asp.net web api'),
('Nitish', 'image4', 'M', 'Dev', 35000.00, '2019-04-03', 'mvc web applications'),
('Pratik', 'image5', 'M', 'Dev', 33000.00, '2020-03-04', 'DBMS mssql'),
('Vikas', 'image6', 'M', 'Dev', 34000.00, '2016-01-05', 'No notes'),
('kiran', 'image7', 'M', 'Dev', 37000.00, '2019-06-07', 'Database engr'),
('Deepak', 'image8', 'M', 'Dev', 32000.00, '2016-09-02', 'database');

--Retrieve employee_payroll data
select * from employee_payroll;



