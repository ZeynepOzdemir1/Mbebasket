create database project
use project
alter table student
add primary key (StudentId);
 select CourseName from Course as c inner join Taken as t on c.CourseId=t.CouId inner join Student as s on s.StudentId=t.StuId
 where StudentName = 'Zeynep Özdemir'
 Alter table TimeInt

 select * from Student
 drop table TimeInt
 alter table TimeInt	
 add primary key (TId);
 add foreign key (Course) references Course(CourseId);
 alter table Taken
 drop column TDate;

 -- view for selected course
create view SelectedCourse as
select StudentName,CourseName, StartTime,EndTime
from Course as c inner join TimeInt as tý on c.CourseId=tý.TId inner join Taken as t on t.CouId=c.CourseId inner join Student as s on s.StudentID=t.StuId

select * from SelectedCourse

-- create cursor for conflict

Declare @starttime time,
--Declare @courseýd int,
--Declare @studentýd int;

Declare cursor_conflict Cursor
for select StartTime
from Taken as t inner join TimeInt as tm on t.CouId=tm.Course inner join Student as s on t.StuId=s.StudentID
open cursor_conflict;

Fetch next from cursor_conflict into @starttime


while @@FETCH_STATUS = 0 
begin
print ''

fetch next from cursor_conflict into

end;
close cursor_conflict;
Deallocate cursor_product;


