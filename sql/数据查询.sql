/* ArcGIS Online Datas */


/* 
 * 1.ѡ����е�������
 */
--SELECT * FROM Content; -- ��ѯ�������ݱ�
 --SELECT Title, Type FROM Content; -- ��ѯ���ݱ��Title�к�Type��
 --SELECT Title ����, Tags �ؼ���, Type ���� FROM Content; -- ʹ���б����ı��ѯ������б���



 /*
  * 2. ѡ����е�����Ԫ��
  */
--SELECT DISTINCT Type FROM Content; -- ����ȡֵ�ظ����� DISTINCT�ؼ��ֲ��ܶ�text��������ʹ��
/* �Ƚ� */
--SELECT Title FROM Content WHERE Type = 'Feature Layer'
--SELECT Title FROM Content WHERE [Object-ID] > 5
/* ��Χ */
--SELECT Title, Type FROM Content WHERE Time BETWEEN '2019-10-11 17:50:00' AND '2019-10-11 18:15:00'
--SELECT Title, Type FROM Content WHERE Time NOT BETWEEN '2019-10-11 17:50:00' AND '2019-10-11 18:15:00'
/* ���� */
--SELECT Title, Type FROM Content WHERE LOWER(Type) IN ('feature layer')
--SELECT Title, LOWER(Type) Type FROM Content WHERE Type NOT IN ('Feature Layer')
/* �ַ�ƥ�� */
--SELECT Title, Type FROM Content WHERE Tags LIKE '%��״Ҫ��%'
--SELECT Title, Type FROM Content WHERE Title NOT LIKE '%����%'
--SELECT Title, Type FROM Content WHERE Title LIKE '_��%'
/* �漰��ֵ�Ĳ�ѯ */
--SELECT * FROM Content WHERE Url IS NULL
--SELECT * FROM Content WHERE Url IS NOT NULL
/* ����������ѯ */
--SELECT * FROM Content WHERE Type = 'Feature Layer' AND Tags LIKE '%��״Ҫ��%'
--SELECT * FROM Content WHERE Tags LIKE '%��״Ҫ��%' OR Tags LIKE '%��״Ҫ��%'


/*
 * 3. ORDER BY �Ӿ�
 */
--SELECT Title, Time FROM Content WHERE Type = 'Feature Layer' ORDER BY Time -- ����
--SELECT Title, Time FROM Content WHERE Type = 'Feature Layer' ORDER BY Time DESC -- ����
--SELECT Title, Type, Time FROM Content ORDER BY Time, Type DESC -- ����


/*
 * 4. �ۼ�����
 */
--SELECT COUNT(*) FROM Content -- ��ѯ����
--SELECT COUNT(DISTINCT Type) FROM Content


/*
 * 5. GROUP BY �Ӿ�
 */
--SELECT Type, COUNT(Type) FROM Content GROUP BY Type HAVING COUNT(*) <= 6