CREATE TABLE [dbo].[EmpMaster]
(
	EmpId int NOT NULL, 
	EmpFirstName char(20) NOT NULL,
	EmpLastName char(20) NOT NULL,
	EmpDesignation char(20) NOT NULL,
	EmpDepartment char(20) NOT NULL,
	EmpReportsTo char(20) NOT NULL
)
