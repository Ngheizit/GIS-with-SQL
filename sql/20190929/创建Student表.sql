CREATE TABLE Student
      (Sno   CHAR(9) PRIMARY KEY, /* �м�������Լ������,Sno������*/                  
        Sname CHAR(20) UNIQUE,    /* SnameȡΨһֵ*/
        Ssex    CHAR(2),
        Sage   SMALLINT,
        Sdept  CHAR(20)
      ); 
