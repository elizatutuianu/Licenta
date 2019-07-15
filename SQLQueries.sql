delete from Specializations;
delete from Faculties;
delete from RoomPreferreds;
delete from DormsPreferreds;
delete from Roommates;
delete from AccomodationRequests;
delete from IdCardStudents;
delete from Rooms;
delete from Dorms;
delete from Students;

select count(Students.Id) from Students where FacultyId = 682;
select count(AccomodationRequests.Id) from AccomodationRequests;
select * from Students where FirstName = 'Beatrice';
select * from AccomodationRequests where Id=1419;
select * from Roommates where FirstName='Eliza Ioana';
select * from AccomodationRequests where Id=1859;
select * from Students where AccomodationRequestId = 1459;

select a.SpecName, s.Year, s.FirstName, s.LastName,s.Initial, s.Media,s.Credits,s.Taxa_buget, s.IsMedicalCase,s.IsSocialCase from Students s, Specializations a where s.SpecializationId = a.Id order by s.Credits desc, s.Media desc;

select count(Students.Id) from Students where Year = 3 and FacultyId = 678;

select s.SpecName, s.Id from Specializations s, Students stud where s.Id = stud.SpecializationId and s.FacultyId = 678;
select SpecName from Specializations where Id = 1960;
select count(Students.Id) from Students where Year = 1 and SpecializationId = 1969;

select FirstName, LastName, Initial, Media from Students where Cnp = '2923416059733';
select * from Students where FirstName='Violeta' and LastName='Caplat' and Initial = 'S';

