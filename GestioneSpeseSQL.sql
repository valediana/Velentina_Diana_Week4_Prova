create database GestioneSpese;

create table Categorie(
Id int not null identity(1,1),
Categoria varchar(100) not null,
constraint PK_Categoria primary key(Id)
);

create table Spese(
IdSpesa int not null identity(1,1),
Data datetime not null,
Descrizione varchar(500) not null,
Utente varchar(100) not null,
Importo decimal(5,2) not null,
Approvato bit not null,
IdCategoria int not null ,
constraint PK_Spese primary key(IdSpesa),
constraint FK_Categoria foreign key (IdCategoria) references Categorie(Id)
);
select * from Categorie;


