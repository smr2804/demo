CREATE TABLE [dbo].[EmpMaster] (
    [EmpId]          INT           IDENTITY (1, 1) NOT NULL,
    [EmpFirstName]   NVARCHAR (50) NULL,
    [EmpLastName]    NVARCHAR (50) NULL,
    [EmpDesignation] NVARCHAR (50) NULL,
    [EmpDepartment]  NVARCHAR (50) NULL,
    [EmpReportsTo]   NVARCHAR (50) NULL,
    [Pwd]            NVARCHAR (10) NULL
);



