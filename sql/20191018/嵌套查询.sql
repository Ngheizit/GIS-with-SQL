--SELECT * /*����ѯ/����ѯ*/
--	FROM Student
--	WHERE Sno IN (	
--		SELECT Sno /*�ڲ��ѯ/�Ӳ�ѯ*/
--			FROM SC
--			WHERE Cno= '2'
--		);
/*
 * ����INν�ʵ��Ӳ�ѯ
 */

---- ��ѯ��"����"��ͬһ��ϵѧϰ��ѧ��
	---- �� ȷ��"����"����ϵ��
--SELECT Sdept  
--	FROM Student                            
--	WHERE Sname= '����';
	---- �� ����������CSϵѧϰ��ѧ��
--SELECT Sno, Sname, Sdept     
--	FROM Student                 
--	WHERE Sdept= 'CS';
	---- Ƕ��ʹ�â٢�
--SELECT Sno, Sname, Sdept
--	FROM Student
--	WHERE Sdept IN (
--		SELECT Sdept
--			FROM Student
--			WHERE Sname= '����');
	---- ʹ���������ӷ�ʽ
--SELECT S1.Sno, S1.Sname,S1.Sdept
--	FROM Student S1,Student S2
--	WHERE S1.Sdept = S2.Sdept  AND
--		S2.Sname = '����';

---- ��ѯѡ���˿γ���Ϊ����Ϣϵͳ����ѧ��ѧ�ź�����
--SELECT Sno,Sname                 
--	FROM Student                         
--	WHERE Sno  IN (
--		SELECT Sno                    
--			FROM SC                         
--			WHERE Cno IN (
--				SELECT Cno             
--					FROM Course          
--					WHERE Cname= '��Ϣϵͳ'                      
--				)
--		);
	---- ʹ�����Ӳ�ѯʵ��
--SELECT Student .Sno, Student .Sname
--	FROM Student,SC,Course
--	WHERE Student.Sno = SC.Sno  AND
--		SC.Cno = Course.Cno AND
--		Course.Cname='��Ϣϵͳ';


/*
 * ���бȽ���������Ӳ�ѯ
 */
--SELECT Sno,Sname,Sdept
--	FROM Student
--	WHERE Sdept = (
--		SELECT Sdept
--			FROM Student
--			WHERE Sname= '����'
--		);

---- �ҳ�ÿ��ѧ��������ѡ�޿γ�ƽ���ɼ��Ŀγ̺�
--SELECT Sno, Cno
--	FROM SC  x
--	WHERE Grade >=(
--		SELECT AVG(Grade) 
--			FROM SC y
--			WHERE y.Sno=x.Sno
--		);
		
/*
 * ����ANY(SOME)��ALLν�ʵ��Ӳ�ѯ
 */
---- ��ѯ�Ǽ������ѧϵ�бȼ������ѧϵ����һѧ������С��ѧ��������������
SELECT Sname,Sage
	FROM Student
	WHERE Sage < ANY (
		SELECT Sage
			FROM Student
			WHERE Sdept= 'CS'
		)
		AND Sdept <> 'CS';
	---- ʹ�þۼ�����ʵ��
SELECT Sname,Sage
	FROM Student
	WHERE Sage < (
		SELECT MAX(Sage)
		FROM Student
		WHERE Sdept= 'CS'
	)
	AND Sdept <> 'CS';





