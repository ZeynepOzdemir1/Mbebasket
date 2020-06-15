Declare @starttime time;
--Declare @courseýd int,
Declare @studentId int;
declare @Id int;
declare @existId int;

Declare cursor_conflict Cursor
scroll for select t.TId,StartTime,StudentID
from Taken as t 
inner join TimeInt as tm on t.CouId=tm.Course 
inner join Student as s on t.StuId=s.StudentID


open cursor_conflict

Fetch first from cursor_conflict into @Id,@starttime,@studentId

while @@FETCH_STATUS = 0 
begin
set @existId = 0
print cast(@Id as varchar(25)) + ' - ' + cast(@studentId as varchar(25))+ ' - ' + cast(@starttime as varchar(25))


select @existId=t.TId
from Taken as t 
inner join TimeInt as tm on t.CouId=tm.Course 
inner join Student as s on t.StuId=s.StudentID
where StartTime = @starttime and StudentID = @studentId and T.TId!=@Id

if(@existId > 0)
print 'ders cakisti ' + cast(@existId as varchar(5))

fetch next from cursor_conflict into @Id,@starttime,@studentId

end
close cursor_conflict;
Deallocate cursor_conflict;

