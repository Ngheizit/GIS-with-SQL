/*
	向Student表增加“入学时间”列，其数据类型为日期型
		不管基本表中是否已有数据，新增加的列一律为空置
*/

-- ALTER TABLE Student ADD S_entrance DATE;

-- 将年龄字符串类型改为整数型
--ALTER TABLE Student ALTER COLUMN Sage SMALLINT;

-- 增加课程名称必须取唯一值的约束条件
ALTER TABLE Course ADD UNIQUE(Cname); 

