/*
 * 建立视图
 */
 SELECT * FROM Student
---- 建立计算机科学系学生
CREATE VIEW CS_Student AS
SELECT Sno,Sname,Sage
FROM Student
WHERE Sdept= 'CS';

 SELECT * FROM CS_Student

---- 建立计算机科学系学生的视图,并要求进行修改和插入操作时仍需保证该视图只有信息系的学生
CREATE VIEW CS_Student_Only AS 
SELECT Sno,Sname,Sage
FROM Student
WHERE Sdept= 'CS'
WITH CHECK OPTION;

 SELECT * FROM CS_Student_Only


/* 基于多个基表的视图 */
---- 建立信息系选修了1号课程的学生的视图（包括学号、姓名、成绩
CREATE VIEW CS_S1(Sno,Sname,Grade) AS 
SELECT Student.Sno,Sname,Grade
FROM  Student,SC
WHERE  Sdept= 'CS' AND
                Student.Sno=SC.Sno AND
                SC.Cno= '1';

 SELECT * FROM CS_S1

