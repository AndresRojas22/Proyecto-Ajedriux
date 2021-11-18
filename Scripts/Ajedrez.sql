create database Ajedriux;
use Ajedriux;
create table Pais(
id_pais int primary key,
Nombre varchar(100),
N_Clubes int,
Fk_Pais int,
foreign key (Fk_pais) references Pais(id_pais));

create table participante(
id_participante int primary key,
Nombre varchar(100),
Direccion varchar(100),
telefono varchar(15),
Competencia varchar(100),
Rol varchar(50),
Fk_pais int,
foreign key (FK_pais) references Pais(Fk_Pais));

create table Hotel(
id_Hotel int primary key,
Nombre varchar(100),
Telefono varchar (15),
Direccion varchar(100));

create table Sala(
id_sala int primary key,
Capacidad int,
Medios varchar(100),
Fk_Hotel int,
foreign key (Fk_Hotel) references Hotel(id_Hotel)on delete cascade);

create table Partida(
Fecha varchar(15),
JugadorN varchar(100),
JugadorB varchar(100),
N_Partida int,
Duracion int,
Ganador varchar(100),
primary key(Fecha,JugadorN,JugadorB,N_Partida));

create table Movimientos(
Fecha varchar(15),
JugadorN varchar(100),
JugadorB varchar(100),
N_Movimiento int,
CasillaI varchar(10),
CasillaF varchar(10),
foreign key(Fecha,JugadorN,JugadorB)references Partida(Fecha,JugadorN,JugadorB)on delete cascade,
primary key(Fecha,JugadorN,JugadorB,N_Movimiento));