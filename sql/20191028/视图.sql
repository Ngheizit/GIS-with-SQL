/*
 * ������ͼ
 */
 SELECT * FROM Student
---- �����������ѧϵѧ��
CREATE VIEW CS_Student AS
SELECT Sno,Sname,Sage
FROM Student
WHERE Sdept= 'CS';

 SELECT * FROM CS_Student

---- �����������ѧϵѧ������ͼ,��Ҫ������޸ĺͲ������ʱ���豣֤����ͼֻ����Ϣϵ��ѧ��
CREATE VIEW CS_Student_Only AS 
SELECT Sno,Sname,Sage
FROM Student
WHERE Sdept= 'CS'
WITH CHECK OPTION;

 SELECT * FROM CS_Student_Only


/* ���ڶ���������ͼ */
---- ������Ϣϵѡ����1�ſγ̵�ѧ������ͼ������ѧ�š��������ɼ�
CREATE VIEW CS_S1(Sno,Sname,Grade) AS 
SELECT Student.Sno,Sname,Grade
FROM  Student,SC
WHERE  Sdept= 'CS' AND
                Student.Sno=SC.Sno AND
                SC.Cno= '1';

 SELECT * FROM CS_S1

