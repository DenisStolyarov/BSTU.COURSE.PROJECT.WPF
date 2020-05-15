create database FileCabinet;
go

use FileCabinet;

create table Faculty
(    
	FacultyCode  varchar(10) constraint FACULTY_PK primary key,
	FacultyName varchar(100) default 'None'
);

insert into Faculty   (FacultyCode,   FacultyName )
	values	('����', '���������� ���������� � �������'),
			('���', '����������������� ���������'),
			('���', '���������-������������� ���������'),
			('����', '���������� � ������� ������ ��������������'),
			('���', '���������� ������������ �������'),
			('��', '��������� �������������� ����������'),
			('����', '������������ ���� � ����������');

create table  Pulpit 
(   
	PulpitCode  varchar(10) constraint PULPIT_PK  primary key,
    PulpitName  varchar(100) default 'None', 
    FacultyCode varchar(10) constraint FK_PULPIT_FACULTY foreign key
                         references Faculty(FacultyCode) 
);

insert into Pulpit(PulpitCode, PulpitName, FacultyCode )
	values	('����', '�������������� ������ � ����������','��'),
			('������','���������������� ������������ � ������ ��������� ����������', '����'),
			('��', '����������� ���������','����'),
			('���', '�����������-������������ ���������', '����'),            
			('��', '��������������� �����������','����'),                              
			('��', '�����������','���'),          
			('��', '��������������','���'),           
			('�����', '���������� � ����������������','���'),                
			('����', '������ ������� � ������������','���'), 
			('���', '������� � ������������������','���'),              
			('������','������������ �������������� � ������-��������� �������������','���'),          
			('��', '���������� ����', '����'),                          
			('�����','������ ����� � ���������� �������������','����'),  
			('���','���������� �������������������� �����������', '����'),   
			('�����','���������� � ������� ������� �� ���������','����'),    
			('��', '������������ �����','���'), 
			('���','���������� ����������� ���������','���'),             
			('�������','���������� �������������� ������� � ����� ���������� ����������','����'), 
			('�����','��������� � ��������� ���������� �����������','����'),                                               
			('����', '������������� ������ � ����������','���'),   
			('����', '����������� � ��������� ������������������','���'),
			('����', '����������� � ���-�������','��'),
			('��', '����������� ���������','��'),
			('��', '������ ����������','��');

create table Specialty
(
	SpecialtyCode  varchar(10) constraint SPECIALITY_PK  primary key,
    SpecialtyName  varchar(200) default 'None', 
    PulpitCode	   varchar(10) constraint FK_SPECIALITY_PULPIT foreign key
                         references Pulpit(PulpitCode) 
);

insert into Specialty(SpecialtyCode, SpecialtyName, PulpitCode )
	values	('����', '�������������� ������� � ����������','����'),
			('������', '����������� ����������� �������������� ������������ ��������� ������','����'),
			('����', '����������� ����������� �������������� ����������','��'),
			('�����', '������ ����������� � ���-�������','����'),
			('��', '������������ ����', '��' ),
			('������',  '��������������� ������������ � ������� ��������� ����������', '��' ),
			('������',    '��������������� � ������������ ������� �� �������������� ����������', '���' ),             
			('���������',  '������ � �������� ���������� ����������� � ����������� ������������ ����������', '���' ),
			('��',      '������ ���������', '��' ),
			('���',   '������-�������� �������������', '��' ),
			('���',     '������ � ������������������', '���' ),
			('����',  '��������� � ���������� �� �����������', '����' ),
			('�����',    '������������� ����, ������ � �����', '����' ),                   
			('�����',   '������ � ������������ ������� ���������', '���' ),
			('��',      '�������������� ����', '���' ),
			('����',  '���������� ���������� ������������ �������, ���������� � �������', '���' ),          
			('����',    '���������� ���������� ����������� ���������', '���' ),
			('��������',   '������-���������� ������ � ������� �������� �������� ���������', '�������' );

create table Groups 
(   
	GroupId  int  identity(1,1) constraint GROUP_PK primary key,              
    FacultyCode  varchar(10) constraint  GROUP_FACULTY_FK foreign key         
                                                         references Faculty(FacultyCode), 
    SpecialtyCode varchar(10) constraint  GROUP_SPECIALITY_FK foreign key         
                                                         references Specialty(SpecialtyCode),
    GroupNumber smallint  check (GroupNumber > 0),
	Course smallint check (Course > 0)
)

insert into Groups(FacultyCode,  SpecialtyCode, Course, GroupNumber)
	values	('����','��', 1, 1), 
			('����','������', 1, 1),
			('����','������', 1, 1),
			('����','���������',1 ,1),
			('����','��', 1,2),
			('����','������', 1,2),
			('����','������', 1,2),
			('����','���������', 1,2),
			('����','��', 1,3),
			('����','������', 1,3),
			('����','������', 1,3),
			('����','��������', 3,1),                                            
			('����','��������', 3,2),
			('����','��������', 3,3),
			('����','��������', 3,4),
			('���','����',2,1), 
			('���','����',2,1),
			('���','����',2,2),
			('���','����',2,2),
			('���','��',4,1),     
			('���','��',4,2),
			('���','���',1,1),
			('���','���',1,2),
			('���','���',1,3),  
			('����','��', 2,1),
			('����','��', 2,2),
			('����','��', 2,3),
			('���','����',1,1), 
			('���','����',1,2),     
			('���','����',2,1),
			('���','����',2,2),
			('���','����',3,1),
			('��','����',1,1), 
			('��','����',1,2),     
			('��','����',2,1),
			('��','����',2,2),
			('��','����',2,3),
			('��','����',2,4),     
			('��','����',2,1),
			('��','����',2,2),
			('��','����',3,1);

create table Student 
(    
	StudentId int identity(1,1) constraint STUDENT_PK  primary key,
    GroupId int constraint STUDENT_GROUP_FK foreign key         
                    references Groups(GroupId),        
    FirstName   nvarchar(100) NOT NULL, 
	LastName   nvarchar(100) NOT NULL, 
	Patronymic   nvarchar(100) default('None'), 
    Birthday date,
	PhoneNumber nvarchar(15) default('None'),
    Foto varbinary(max)
 ) 

insert into Student (GroupId, FirstName, LastName, Patronymic, Birthday)
	values	(1, '����������','���������','�������������', '11.03.1995'),        
			(1, '������', '���������', '�������', '07.12.1995'),
			(1, '������', '��������', '����������', '12.10.1995'),
			(1, '�����', '���������', '���������', '08.01.1995'),
			(1, '�����', '�����', '��������', '02.08.1995'),     
			(2, '�����', '�������', '��������','12.07.1994'),
			(2, '�������     ','��������   ','����������','06.03.1994'),
			(2, '��������    ','�����      ','�����������', '09.11.1994'),
			(2, '�������     ','�����      ','���������',   '04.10.1994'),
			(2, '���������   ','���������  ','����������', '08.01.1994'),
			(2, '�������     ','������     ','���������',   '02.08.1993'),
			(2, '�������     ','���        ','����������',     '07.12.1993'),
			(2, '�������     ','�����      ','�����������',  '02.12.1993'),
			(4, '�������     ','������     ','�����������', '08.03.1992'),
			(4, '�������     ','�����      ','�������������','02.06.1992'),
			(4, '��������    ','�����      ','�����������', '11.12.1992'),
			(4, '��������    ','�������    ','�������������','11.05.1992'),
			(4, '����������� ','�������    ','��������', '09.11.1992'),
			(4, '��������    ','�������    ','����������','01.11.1992'),
			(5, '��������    ','�����      ','������������','08.07.1995'),
			(5, '������      ','�������    ','����������',   '02.11.1995'),
			(5, '������      ','���������  ','�����������','07.05.1995'),
			(5, '�����       ','���������  ','���������',   '04.08.1995'),
			(6, '����������  ','�����      ','����������', '08.11.1994'),
			(6, '��������    ','������     ','��������',    '02.03.1994'),
			(6, '����������  ','�����      ','����������', '04.06.1994'),
			(6, '���������   ','���������� ','���������', '09.11.1994'),
			(6, '�����       ','���������  ','�������',   '04.07.1994'),
			(7, '����������� ','�����      ','������������', '03.01.1993'),
			(7, '�������     ','����       ','��������',  '12.09.1993'),
			(7, '���������   ','������     ','��������', '12.06.1993'),
			(7, '����������  ','���������  ','����������','09.02.1993'),
			(7, '�������     ','������     ','���������',  '04.07.1993'),
			(8, '������      ','�������    ','���������',  '08.01.1992'),
			(8, '���������   ','�����      ','����������','12.05.1992'),
			(8, '��������    ','�����      ','����������', '08.11.1992'),
			(8, '�������     ','�������    ','���������', '12.03.1992'),
			(9, '��������    ','�����      ','�������������','10.08.1995'),
			(9, '����������  ','������     ','��������','02.05.1995'),
			(9, '������      ','�������    ','�������������', '08.01.1995'),
			(9, '���������   ','���������  ','��������', '11.09.1995'),
			(10, '������     ','�������    ','������������','08.01.1994'),
			(10, '������     ','������     ','����������', '11.09.1994'),
			(10, '�����      ','����       ','�������������','06.04.1994'),
			(10, '�������    ','������     ','����������', '12.08.1994'),
			(11, '���������  ','���������  ','����������','07.11.1993'),
			(11, '������     ','�������    ','����������', '04.06.1993'),
			(11, '�������    ','�����      ','����������',  '10.12.1993'),
			(11, '�������    ','������     ','����������', '04.07.1993'),
			(11, '�������    ','�����      ','���������',   '08.01.1993'),
			(11, '�����      ','�������    ','����������',  '02.09.1993'),
			(12, '����       ','������     ','�����������', '11.12.1995'),
			(12, '�������    ','����       ','�������������',  '10.06.1995'),
			(12, '���������  ','����       ','���������',   '09.08.1995'),
			(12, '�����      ','�����      ','���������',      '04.07.1995'),
			(12, '���������  ','������     ','����������','08.03.1995'),
			(12, '�����      ','�����      ','��������',       '12.09.1995'),
			(13, '������     ','�����      ','������������',     '08.10.1994'),
			(13, '���������� ','�����      ','����������',   '10.02.1994'),
			(13, '��������   ','�������    ','�������������','11.11.1994'),
			(13, '���������� ','�����      ','����������',   '10.02.1994'),
			(13, '�����������','�����      ','��������',    '12.01.1994'),
			(14, '��������   ','�������    ','�������������','11.09.1993'),
			(14, '������     ','��������   ','����������',    '01.12.1993'),
			(14, '����       ','�������    ','����������',       '09.06.1993'),
			(14, '��������   ','���������� ','����������','05.01.1993'),
			(14, '�����������','�����      ','����������',  '01.07.1993'),
			(15, '�������    ','���������  ','���������',   '07.04.1992'),
			(15, '������     ','��������   ','���������',     '10.12.1992'),
			(15, '���������  ','�����      ','����������',    '05.05.1992'),
			(15, '���������� ','�����      ','������������', '11.01.1992'),
			(15, '��������   ','�����      ','����������',     '04.06.1992'),
			(33, '�����      ','�����      ','����������',        '08.01.1994'),
			(33, '���������  ','���������  ','���������', '07.02.1994'),
			(33, '������     ','������     ','�����������','12.06.1994'),
			(33, '�������    ','�����      ','��������',   '03.07.1994'),
			(33, '������     ','������     ','���������',  '04.07.1994'),
			(33, '�������    ','���������  ','����������',  '08.11.1993'),
			(33, '������     ','�����      ','����������',  '02.04.1993'),
			(33, '������     ','����       ','��������',     '03.06.1993'),
			(33, '�������    ','������     ','���������', '05.11.1993'),
			(33, '������     ','������     ','�������������',   '03.07.1993'),
			(33, '���������  ','�����      ','��������',      '08.01.1995'),
			(33, '���������� ','���������  ','���������','06.09.1995'),
			(33, '��������   ','���������  ','����������', '08.03.1995'),
			(33, '���������  ','�����      ','��������',      '07.08.1995');
go
			-----------------------------------------------------------------

declare curs cursor global 
	for select S.StudentId from Student as S
	for update; 

open curs; 
declare @stub int,@number nvarchar(15) = '+375', @count int = 0; 
fetch curs into @stub;
while @@FETCH_STATUS = 0
begin
	while (@count < 7)
		begin
			set @number += cast(FLOOR(rand()*10) as nvarchar(1))
			set @count += 1;
		end;
	update Student set PhoneNumber = @number where current of curs;
	set @number = '+375';
	set @count = 0;
	fetch curs into @stub;
end
close curs;
deallocate curs;
go

					-----------------------------------------------------------------

create table Authorizations
(
	Login nvarchar(50),
	Password nvarchar(50),
	Role nvarchar(5) check(Role in ('admin', 'user')) default('user'),
	UserId int constraint FK_USER_STUDENT foreign key
                         references Student(StudentId),
	constraint PK_USER primary key(Login, Password)
)

insert into Authorizations(Login, Password, Role, UserId)
		values('admin', 'admin', 'admin', null),
			  ('user', 'user', 'user', 87);

create table Teacher
(   
	 TeacherCode    varchar(10)  constraint TEACHER_PK  primary key,
     TeacherName    varchar(100),
     PulpitCode			varchar(10) constraint TEACHER_PULPIT_FK foreign key 
                         references Pulpit(PulpitCode),
     Foto varbinary(max)
) 

insert into  Teacher(TeacherCode, TeacherName, PulpitCode)
	values	('����', '������ �������� �������������', '����'),
			('�����', '�������� ��������� ��������', '����'),
			('�����', '���������� ������� ����������', '����'),
			('�����', '�������� ������ ��������', '����'),
			('���', '����� ��������� ����������', '����'),
			('���', '��������� ����� ��������', '����'),
			('���', '����� ������� ��������', '����'),
			('���', '����� ������� �������������',  '����'),                     
			('���', '����� ����� �������������',    '����'),
			('������', '���������� ��������� �������������','������'),
			('���', '��������� ������� �����������', '������'),                       
			('������', '����������� ��������� ��������', '����'),
			('����', '������� ��������� ����������', '����'),
			('����', '������� ������ ����������',   '������'),
			('���', '���������� ������� ��������', '������'),
			('���', '������ ������ ���������� ', '��'),                      
			('�����', '��������� �������� ���������', '�����'), 
			('������', '���������� �������� ����������', '��'), 
			('�����', '�������� ������ ����������', '��'),      
			('����',   '������ ������ ��������', '��');   
			
create table Subject
(     
	SubjectCode varchar(10)  constraint SUBJECT_PK  primary key, 
    SubjectName varchar(200) unique,
    PulpitCode      varchar(10)  constraint SUBJECT_PULPIT_FK foreign key 
                         references Pulpit(PulpitCode)   
)

insert into Subject (SubjectCode, SubjectName, PulpitCode)
	values	('����', '������� ���������� ������ ������', '����'),
			('��', '���� ������','����'),
			('���', '�������������� ����������','����'),
			('����', '������ �������������� � ����������������', '����'),
			('��', '������������� ������ � ������������ ��������', '����'),
			('���', '���������������� ������� ����������','����'),
			('����', '������������� ������ ��������� ����������', '����'),
			('���', '�������������� �������������� ������', '����'),
			('��', '������������ ��������� ','����'),
			('�����', '��������. ������, �������� � �������� �����', '������'),
			('���', '������������ �������������� �������', '����'),
			('���', '����������� ��������. ������������', '������'),
			('��', '���������� ����������', '����'),
			('��', '�������������� ����������������','����'),  
			('����', '���������� ������ ���',  '����'),                 
			('���', '��������-��������������� ����������������', '����'),
			('��', '��������� ������������������','����'),
			('��', '������������� ������','����'),
			('������OO','�������� ������ ������ � ���� � ���. ������.','��'),
			('�������','������ ������-��������� � ������������� ���������',  '������'),
			('��', '���������� �������� ','��'),
			('��', '�����������', '�����'), 
			('��', '������������ �����', '��'),   
			('���', '������ ��������� ����','��'),
			('����', '���������� � ������������ �������������', '�����'), 
			('����', '���������� ���������� �������� ���������� ','�������'); 

create table TeacherSubject
(
	TeacherCode	varchar(10) Not Null foreign key references Teacher(TeacherCode),
	SubjectCode	varchar(10) Not Null foreign key references Subject(SubjectCode),
	Course int Not Null check(Course > 0)
)

insert into TeacherSubject(TeacherCode, SubjectCode, Course)
			values('���','���',2),
				  ('����','���',2),
				  ('���','��',2),
				  ('���','����',2),
				  ('���','���',2),
				  ('����','���',2),
				  ('���','����',1),
				  ('����','��',1),
				  ('����','��',1),
				  ('�����','���',1),
				  ('�����','���',1),
				  ('�����','����',3),
				  ('�����','��',3),
				  ('���','����',3),
				  ('���','��',3),
				  ('���','���',3),
				  ('���','����',3);
go

create procedure GetSubjectsOfStudent @StudentId int
as select T.TeacherCode, T.TeacherName, S.SubjectCode, S.SubjectName, S.PulpitCode from Teacher as T
	inner join TeacherSubject as TS on T.TeacherCode = TS.TeacherCode
	inner join Subject as S on S.SubjectCode = TS.SubjectCode
	where TS.Course = (select G.Course from Groups as G 
		inner join Student as ST on G.GroupId = ST.GroupId 
		where ST.StudentId = @StudentId);
return;
go 
--drop procedure GetSubjectsOfStudent
declare @StudentId int = 87
exec GetSubjectsOfStudent @StudentId
go

create procedure GetStudentsOfGroup @GroupId int
as select * from Student as S where S.GroupId = @GroupId;
return;
go 
--drop procedure GetStudentsOfGroup;
declare @GroupId int = 1
exec GetStudentsOfGroup @GroupId
go