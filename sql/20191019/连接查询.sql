/*
 *	- 连接查询
 *		-- 同时涉及两个以上的表查询
 */


/****************************************************************************/

/* 等值与非等值查询 */

---- 3.49 查询每个学生及其选修课程的情况
	---- 方法①
--SELECT Student.*, SC.*
--	FROM Student, SC
--	WHERE Student.Sno = SC.Sno
	---- 方法②
--SELECT Student.*, SC.*
--	FROM Student INNER
--	JOIN SC ON Student.Sno =SC.Sno
	---- 方法③ 自然连接
--SELECT Student.Sno, Sname, Ssex, Sage, Sdept, SC.Cno, Course.Cname, Grade
--	FROM Student, SC, Course
--	WHERE Student.Sno = SC.Sno AND SC.Cno = Course.Cno

---- 3.51 查询选修课2号课程且成绩在90分及以上的所有学生的学号和姓名
--SELECT Student.Sno, Sname
--	FROM Student, SC
--	WHERE Student.Sno = SC.Sno AND SC.Cno='2' AND SC.Grade >= 90

/****************************************************************************/

/* 自身连接 */
---- 3.52 查询每一门课的简洁先修课（即先修课的先修课）
--SELECT FIRST.Cname, SECOND.Cname, THRID.Cname
--	FROM Course FIRST, Course SECOND, Course THRID
--	WHERE FIRST.Cpno = SECOND.Cno AND SECOND.Cpno = THRID.Cno

/****************************************************************************/

/* 外连接 */
---- 3.53 查询每个学生及其选修课程的情况
--SELECT Student.Sno, Sname, Ssex, Sage, Sdept, Cno, Grade
--	FROM Student LEFT OUTER 
--	JOIN SC ON (Student.Sno=SC.Sno)

/****************************************************************************/

/* 多表连接 */

---- 查询每个学生学号、姓名、选修的课程名及成绩
	---- 方法①
SELECT Student.Sno, Sname, Cname, Grade
	FROM Student, SC, Course
	WHERE Student.Sno=SC.Sno AND SC.Cno=Course.Cno
	---- 方法②
SELECT Student.Sno, Sname, Cname, Grade
	FROM Student INNER 
	JOIN SC ON Student.Sno=SC.Sno INNER
	JOIN Course ON SC.Cno=Course.Cno


