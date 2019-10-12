/* ArcGIS Online Datas */


/* 
 * 1.选择表中的若干列
 */
--SELECT * FROM Content; -- 查询整个内容表
 --SELECT Title, Type FROM Content; -- 查询内容表的Title列和Type列
 --SELECT Title 主题, Tags 关键字, Type 类型 FROM Content; -- 使用列别名改变查询结果的列标题



 /*
  * 2. 选择表中的若干元组
  */
--SELECT DISTINCT Type FROM Content; -- 消除取值重复的行 DISTINCT关键字不能对text数据类型使用
/* 比较 */
--SELECT Title FROM Content WHERE Type = 'Feature Layer'
--SELECT Title FROM Content WHERE [Object-ID] > 5
/* 范围 */
--SELECT Title, Type FROM Content WHERE Time BETWEEN '2019-10-11 17:50:00' AND '2019-10-11 18:15:00'
--SELECT Title, Type FROM Content WHERE Time NOT BETWEEN '2019-10-11 17:50:00' AND '2019-10-11 18:15:00'
/* 集合 */
--SELECT Title, Type FROM Content WHERE LOWER(Type) IN ('feature layer')
--SELECT Title, LOWER(Type) Type FROM Content WHERE Type NOT IN ('Feature Layer')
/* 字符匹配 */
--SELECT Title, Type FROM Content WHERE Tags LIKE '%线状要素%'
--SELECT Title, Type FROM Content WHERE Title NOT LIKE '%行政%'
--SELECT Title, Type FROM Content WHERE Title LIKE '_国%'
/* 涉及空值的查询 */
--SELECT * FROM Content WHERE Url IS NULL
--SELECT * FROM Content WHERE Url IS NOT NULL
/* 多重条件查询 */
--SELECT * FROM Content WHERE Type = 'Feature Layer' AND Tags LIKE '%面状要素%'
--SELECT * FROM Content WHERE Tags LIKE '%点状要素%' OR Tags LIKE '%面状要素%'


/*
 * 3. ORDER BY 子句
 */
--SELECT Title, Time FROM Content WHERE Type = 'Feature Layer' ORDER BY Time -- 升序
--SELECT Title, Time FROM Content WHERE Type = 'Feature Layer' ORDER BY Time DESC -- 降序
--SELECT Title, Type, Time FROM Content ORDER BY Time, Type DESC -- 降序


/*
 * 4. 聚集函数
 */
--SELECT COUNT(*) FROM Content -- 查询总数
--SELECT COUNT(DISTINCT Type) FROM Content


/*
 * 5. GROUP BY 子句
 */
--SELECT Type, COUNT(Type) FROM Content GROUP BY Type HAVING COUNT(*) <= 6