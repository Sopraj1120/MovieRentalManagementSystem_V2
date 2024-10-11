Create database  MovieRentalManagement ;

create Table Movies(
MovieId INT  Primary Key,
Title NvarChar(50),
Director NvarChar(50),
RentalPrice decimal);

insert into Movies (MovieId,Title,Director,RentalPrice)
values ('Jeans','Shankar',1.00 );

select * from Movies;