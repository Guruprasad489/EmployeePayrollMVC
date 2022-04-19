-----Add Employee to database-----
create procedure spAddEmployee
(
    @Name varchar(200),
	@ProfileImage varchar(200),
	@Gender char(1),
	@Dept varchar(200),
	@Salary float,
	@StartDate date,
	@Notes varchar(200)
)
as
BEGIN TRY
	insert into employee_payroll (Name, ProfileImage, Gender, Dept, Salary, Startdate, Notes)
	values(@Name, @ProfileImage, @Gender, @Dept, @Salary, @StartDate, @Notes)
END TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ErrorNumber,
ERROR_SEVERITY() AS ErrorSeverity,
ERROR_STATE() AS ErrorState,
ERROR_PROCEDURE() AS ErrorProcedure,
ERROR_LINE() AS ErrorLine,
ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spAddEmployee;

--Update employee details in the database--
create procedure spUpdateEmployee
(
	@EmpId int,
	@Name varchar(200),
	@ProfileImage varchar(200),
	@Gender char(1),
	@Dept varchar(200),
	@Salary float,
	@StartDate date,
	@Notes varchar(200)
)
as
BEGIN TRY
	update employee_payroll 
	set Name = @Name,
		ProfileImage = @ProfileImage,
		Gender = @Gender,
		Dept = @Dept,
		Salary = @Salary,
		StartDate = @StartDate,
		Notes = @Notes
	where EmpId = @EmpId;
END TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ErrorNumber,
ERROR_SEVERITY() AS ErrorSeverity,
ERROR_STATE() AS ErrorState,
ERROR_PROCEDURE() AS ErrorProcedure,
ERROR_LINE() AS ErrorLine,
ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--Delete employee details from the database--
create procedure spDeleteEmployee
(
	@EmpId int
)
as
BEGIN TRY
	delete from employee_payroll where EmpId = @EmpId;
END TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ErrorNumber,
ERROR_SEVERITY() AS ErrorSeverity,
ERROR_STATE() AS ErrorState,
ERROR_PROCEDURE() AS ErrorProcedure,
ERROR_LINE() AS ErrorLine,
ERROR_MESSAGE() AS ErrorMessage;
END CATCH