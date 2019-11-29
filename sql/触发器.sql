CREATE TRIGGER StudentTRIGGER1 ON Student
	FOR INSERT
AS 
BEGIN
   declare @Sno nvarchar(50)
   select @Sno=Sno from inserted
   update Student set Sdept = 'GIS' where Sno=@Sno
END
