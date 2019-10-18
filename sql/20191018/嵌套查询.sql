--SELECT * /*外层查询/父查询*/
--	FROM Student
--	WHERE Sno IN (	
--		SELECT Sno /*内层查询/子查询*/
--			FROM SC
--			WHERE Cno= '2'
--		);
/*
 * 带有IN谓词的子查询
 */

---- 查询与"刘晨"在同一个系学习的学生
	---- ① 确定"刘晨"所在系名
--SELECT Sdept  
--	FROM Student                            
--	WHERE Sname= '刘晨';
	---- ② 查找所有在CS系学习的学生
--SELECT Sno, Sname, Sdept     
--	FROM Student                 
--	WHERE Sdept= 'CS';
	---- 嵌套使用①②
--SELECT Sno, Sname, Sdept
--	FROM Student
--	WHERE Sdept IN (
--		SELECT Sdept
--			FROM Student
--			WHERE Sname= '刘晨');
	---- 使用自身连接方式
--SELECT S1.Sno, S1.Sname,S1.Sdept
--	FROM Student S1,Student S2
--	WHERE S1.Sdept = S2.Sdept  AND
--		S2.Sname = '刘晨';

---- 查询选修了课程名为“信息系统”的学生学号和姓名
--SELECT Sno,Sname                 
--	FROM Student                         
--	WHERE Sno  IN (
--		SELECT Sno                    
--			FROM SC                         
--			WHERE Cno IN (
--				SELECT Cno             
--					FROM Course          
--					WHERE Cname= '信息系统'                      
--				)
--		);
	---- 使用连接查询实现
--SELECT Student .Sno, Student .Sname
--	FROM Student,SC,Course
--	WHERE Student.Sno = SC.Sno  AND
--		SC.Cno = Course.Cno AND
--		Course.Cname='信息系统';


/*
 * 带有比较运算符的子查询
 */
--SELECT Sno,Sname,Sdept
--	FROM Student
--	WHERE Sdept = (
--		SELECT Sdept
--			FROM Student
--			WHERE Sname= '刘晨'
--		);

---- 找出每个学生超过他选修课程平均成绩的课程号
--SELECT Sno, Cno
--	FROM SC  x
--	WHERE Grade >=(
--		SELECT AVG(Grade) 
--			FROM SC y
--			WHERE y.Sno=x.Sno
--		);
		
/*
 * 带有ANY(SOME)或ALL谓词的子查询
 */
---- 查询非计算机科学系中比计算机科学系任意一学生年龄小的学生的姓名和年龄
SELECT Sname,Sage
	FROM Student
	WHERE Sage < ANY (
		SELECT Sage
			FROM Student
			WHERE Sdept= 'CS'
		)
		AND Sdept <> 'CS';
	---- 使用聚集函数实现
SELECT Sname,Sage
	FROM Student
	WHERE Sage < (
		SELECT MAX(Sage)
		FROM Student
		WHERE Sdept= 'CS'
	)
	AND Sdept <> 'CS';





