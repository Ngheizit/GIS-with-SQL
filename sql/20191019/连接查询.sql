/*
 *	- ���Ӳ�ѯ
 *		-- ͬʱ�漰�������ϵı��ѯ
 */


/****************************************************************************/

/* ��ֵ��ǵ�ֵ��ѯ */

---- 3.49 ��ѯÿ��ѧ������ѡ�޿γ̵����
	---- ������
--SELECT Student.*, SC.*
--	FROM Student, SC
--	WHERE Student.Sno = SC.Sno
	---- ������
--SELECT Student.*, SC.*
--	FROM Student INNER
--	JOIN SC ON Student.Sno =SC.Sno
	---- ������ ��Ȼ����
--SELECT Student.Sno, Sname, Ssex, Sage, Sdept, SC.Cno, Course.Cname, Grade
--	FROM Student, SC, Course
--	WHERE Student.Sno = SC.Sno AND SC.Cno = Course.Cno

---- 3.51 ��ѯѡ�޿�2�ſγ��ҳɼ���90�ּ����ϵ�����ѧ����ѧ�ź�����
--SELECT Student.Sno, Sname
--	FROM Student, SC
--	WHERE Student.Sno = SC.Sno AND SC.Cno='2' AND SC.Grade >= 90

/****************************************************************************/

/* �������� */
---- 3.52 ��ѯÿһ�ſεļ�����޿Σ������޿ε����޿Σ�
--SELECT FIRST.Cname, SECOND.Cname, THRID.Cname
--	FROM Course FIRST, Course SECOND, Course THRID
--	WHERE FIRST.Cpno = SECOND.Cno AND SECOND.Cpno = THRID.Cno

/****************************************************************************/

/* ������ */
---- 3.53 ��ѯÿ��ѧ������ѡ�޿γ̵����
--SELECT Student.Sno, Sname, Ssex, Sage, Sdept, Cno, Grade
--	FROM Student LEFT OUTER 
--	JOIN SC ON (Student.Sno=SC.Sno)

/****************************************************************************/

/* ������� */

---- ��ѯÿ��ѧ��ѧ�š�������ѡ�޵Ŀγ������ɼ�
	---- ������
SELECT Student.Sno, Sname, Cname, Grade
	FROM Student, SC, Course
	WHERE Student.Sno=SC.Sno AND SC.Cno=Course.Cno
	---- ������
SELECT Student.Sno, Sname, Cname, Grade
	FROM Student INNER 
	JOIN SC ON Student.Sno=SC.Sno INNER
	JOIN Course ON SC.Cno=Course.Cno


