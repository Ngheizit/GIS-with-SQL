/*
 * - Ƕ�ײ�ѯ
 */

/****************************************************************************/

--SELECT Sname
--	FROM Student
--	WHERE Sno IN(
--		SELECT Sno
--			FROM SC
--			WHERE Cno='2'
--	)

---- 3.55 ��ѯ�롰��������ͬһϵѧϰ��ѧ��
	---- ������
--SELECT Sno, Sname, Sdept
--	FROM Student
--	WHERE Sdept IN(
--		SELECT Sdept
--			FROM Student
--			WHERE Sname='����'
--	)
	---- ��������������
--SELECT S1.Sno, S1.Sname, S1.Sdept
--	FROM Student S1, Student S2
--	WHERE S1.Sdept=S2.Sdept AND S2.Sname = '����'

---- ��ѯѡ���˿γ���Ϊ����Ϣϵͳ����ѧ��ѧ�ź�����
--SELECT Sno, Sname -- �� �����Student��ϵ��ȡ��Sno��Sname
--	FROM Student
--	WHERE Sno IN(
--		SELECT Sno -- �� Ȼ����CS��ϵ���ҳ�ѡ����3�ſγ̵�ѧ��ѧ��
--			FROM SC
--			WHERE Cno IN(
--				SELECT Cno -- �� ������Course��ϵ���ҳ�����Ϣϵͳ���Ŀγ̺ţ�Ϊ3��
--					FROM Course
--					WHERE Cname='��Ϣϵͳ'
--			)
--	)
	---- �����Ӳ�ѯʵ��
--SELECT Student.Sno, Student.Sname
--FROM Student, SC, Course
--WHERE Student.Sno=SC.Sno AND SC.Cno=Course.Cno AND Course.Cname='��Ϣϵͳ'


/****************************************************************************/

/* ���бȽ���������Ӳ�ѯ */

---- �ҳ�ÿ��ѧ��������ѡ�޿�ƽ���ɼ��Ŀγ̺�
SELECT Sno, Cno
FROM SC SC1
WHERE Grade >= (
	SELECT AVG(Grade)
	FROM SC SC2
	WHERE SC1.Sno=SC2.Sno
)
