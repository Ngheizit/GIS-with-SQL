/**
 * ��ֵ���� �� �ǵ�ֵ����
 * ��������� "="
 */
 
---- ��ѯÿ��ѧ������ѡ�޿ογ̵����
--SELECT Student.*, SC.* 
--	FROM Student, SC
--	WHERE Student.Sno = SC.Sno;
--SELECT  Student.*, SC.*
--	FROM Student INNER
--	JOIN SC ON Student.Sno = SC.Sno

-- ��Ȼ����
--SELECT Student.Sno,Sname,Ssex,Sage,Sdept,Cno,Grade
--	FROM Student,SC
--	WHERE Student.Sno = SC.Sno;

---- ��ѯѡ��2�ſγ��ҳɼ���90�����ϵ�����ѧ����ѧ�ź�����
--SELECT Student.Sno, Sname
--	FROM Student, SC
--	WHERE Student.Sno=SC.Sno AND    		               
--		SC.Cno='2' AND SC.Grade>80;


/**
 * ��������
 */
---- ��ѯÿһ�ſεļ�����޿Σ������޿ε����޿Σ�
--SELECT * FROM Course 
--SELECT FIRST.Cno, FIRST.Cpno, SECOND.Cpno
--	FROM Course FIRST, Course SECOND
--	WHERE FIRST.Cpno = SECOND.Cno;
	
/**
 * ������
 */
--SELECT Student.Sno,Sname,Ssex,Sage,Sdept,Cno,Grade
--	FROM Student LEFT OUTER JOIN SC ON    
--		(Student.Sno=SC.Sno); 
		
/**
 * ����ѯ
 */
---- ��ѯÿ��ѧ����ѧ�š�������ѡ�޵Ŀγ������ɼ�
SELECT Student.Sno, Sname, Cname, Grade
	FROM Student, SC, Course   
	WHERE Student.Sno = SC.Sno 
		AND SC.Cno = Course.Cno;
SELECT Student.Sno, Sname,Cname, Grade
	FROM Student INNER JOIN SC 
	ON Student.Sno = SC.Sno INNER JOIN Course 
	ON SC.Cno = Course.Cno




 



