/**
 * 等值连接 与 非等值连接
 * 连接运算符 "="
 */
 
---- 查询每个学生及其选修课课程的情况
--SELECT Student.*, SC.* 
--	FROM Student, SC
--	WHERE Student.Sno = SC.Sno;
--SELECT  Student.*, SC.*
--	FROM Student INNER
--	JOIN SC ON Student.Sno = SC.Sno

-- 自然连接
--SELECT Student.Sno,Sname,Ssex,Sage,Sdept,Cno,Grade
--	FROM Student,SC
--	WHERE Student.Sno = SC.Sno;

---- 查询选修2号课程且成绩在90分以上的所有学生的学号和姓名
--SELECT Student.Sno, Sname
--	FROM Student, SC
--	WHERE Student.Sno=SC.Sno AND    		               
--		SC.Cno='2' AND SC.Grade>80;


/**
 * 自身连接
 */
---- 查询每一门课的间接先修课（即先修课的先修课）
--SELECT * FROM Course 
--SELECT FIRST.Cno, FIRST.Cpno, SECOND.Cpno
--	FROM Course FIRST, Course SECOND
--	WHERE FIRST.Cpno = SECOND.Cno;
	
/**
 * 外连接
 */
--SELECT Student.Sno,Sname,Ssex,Sage,Sdept,Cno,Grade
--	FROM Student LEFT OUTER JOIN SC ON    
--		(Student.Sno=SC.Sno); 
		
/**
 * 多表查询
 */
---- 查询每个学生的学号、姓名、选修的课程名及成绩
SELECT Student.Sno, Sname, Cname, Grade
	FROM Student, SC, Course   
	WHERE Student.Sno = SC.Sno 
		AND SC.Cno = Course.Cno;
SELECT Student.Sno, Sname,Cname, Grade
	FROM Student INNER JOIN SC 
	ON Student.Sno = SC.Sno INNER JOIN Course 
	ON SC.Cno = Course.Cno




 



