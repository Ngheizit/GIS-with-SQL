/*
	��Student�����ӡ���ѧʱ�䡱�У�����������Ϊ������
		���ܻ��������Ƿ��������ݣ������ӵ���һ��Ϊ����
*/

-- ALTER TABLE Student ADD S_entrance DATE;

-- �������ַ������͸�Ϊ������
--ALTER TABLE Student ALTER COLUMN Sage SMALLINT;

-- ���ӿγ����Ʊ���ȡΨһֵ��Լ������
ALTER TABLE Course ADD UNIQUE(Cname); 

