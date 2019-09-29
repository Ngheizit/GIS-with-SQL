CREATE TABLE  SC
      (Sno  CHAR(9), 
       Cno  CHAR(4),  
       Grade  SMALLINT,
       PRIMARY KEY (Sno,Cno),  
                      /* �������������Թ��ɣ�������Ϊ�������Խ��ж���*/
       FOREIGN KEY (Sno) REFERENCES Student(Sno),
                     /* ��������Լ��������Sno�����룬�����ձ���Student */
       FOREIGN KEY (Cno)REFERENCES Course(Cno)
                      /* ��������Լ�������� Cno�����룬�����ձ���Course*/
    ); 
