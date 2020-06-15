select t.TId,StartTime,StudentID
from Taken as t 
inner join TimeInt as tm on t.CouId=tm.Course 
inner join Student as s on t.StuId=s.StudentID
