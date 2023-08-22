CREATE DATABASE Filmes
USE Filmes

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

INSERT INTO Genero(Nome)
Values('Terror'),('A��o')	

INSERT INTO Filme(Titulo,IdGEnero)
Values('A Freira',1),('John Wick',2)