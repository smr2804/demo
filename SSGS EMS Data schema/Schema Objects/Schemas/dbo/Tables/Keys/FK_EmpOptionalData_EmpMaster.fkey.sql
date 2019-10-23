ALTER TABLE [dbo].[EmpOptionalData]
    ADD CONSTRAINT [FK_EmpOptionalData_EmpMaster] FOREIGN KEY ([EmpId]) REFERENCES [dbo].[EmpMaster] ([EmpId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

