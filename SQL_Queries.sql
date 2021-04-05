create table users(userId int identity primary key, userName nvarchar(50), psword nvarchar(50))

create table notes(noteId int identity primary key, noteName nvarchar(50), description nvarchar(500), usrId int)

alter table notes
add constraint FK_UserNotes
foreign key (usrId) references users(userId)


--drop table notes

select * from users
select * from notes

insert into users values
('Bob', 'passw0rd'),
('admin', 'admin'),
('Jack', 'Passw0rd')

insert into notes values
('Test1', 'This is test note 1', 1)