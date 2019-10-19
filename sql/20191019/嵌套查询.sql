/*
 * - 嵌套查询
 */

/****************************************************************************/

--SELECT Sname
--	FROM Student
--	WHERE Sno IN(
--		SELECT Sno
--			FROM SC
--			WHERE Cno='2'
--	)

---- 3.55 查询与“刘晨”在同一系学习的学生
	---- 方法①
--SELECT Sno, Sname, Sdept
--	FROM Student
--	WHERE Sdept IN(
--		SELECT Sdept
--			FROM Student
--			WHERE Sname='刘晨'
--	)
	---- 方法②自身连接
--SELECT S1.Sno, S1.Sname, S1.Sdept
--	FROM Student S1, Student S2
--	WHERE S1.Sdept=S2.Sdept AND S2.Sname = '刘晨'

---- 查询选修了课程名为“信息系统”的学生学号和姓名
--SELECT Sno, Sname -- ③ 最后在Student关系中取出Sno和Sname
--	FROM Student
--	WHERE Sno IN(
--		SELECT Sno -- ② 然后在CS关系中找出选修了3号课程的学生学号
--			FROM SC
--			WHERE Cno IN(
--				SELECT Cno -- ① 首先在Course关系中找出“信息系统”的课程号，为3号
--					FROM Course
--					WHERE Cname='信息系统'
--			)
--	)
	---- 用连接查询实现
--SELECT Student.Sno, Student.Sname
--FROM Student, SC, Course
--WHERE Student.Sno=SC.Sno AND SC.Cno=Course.Cno AND Course.Cname='信息系统'


/****************************************************************************/

/* 带有比较运算符的子查询 */

---- 找出每个学生超过他选修课平均成绩的课程号
SELECT Sno, Cno
FROM SC SC1
WHERE Grade >= (
	SELECT AVG(Grade)
	FROM SC SC2
	WHERE SC1.Sno=SC2.Sno
)
