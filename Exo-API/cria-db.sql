
CREATE DATABASE ExoApi;
GO


USE ExoApi;
GO


CREATE TABLE Projetos (
    Id INT PRIMARY KEY IDENTITY,
    NomeDoProjeto VARCHAR(150) NOT NULL,
    Area VARCHAR(150) NOT NULL,
    Status BIT
);
GO


INSERT INTO Projetos (NomeDoProjeto, Area, Status)
VALUES ('Projeto A - Obras BR', 'Construção Civil', 1);
GO

INSERT INTO Projetos (NomeDoProjeto, Area, Status)
VALUES ('Projeto B - SENAI Fest', 'Eventos', 0);
GO

INSERT INTO Projetos (NomeDoProjeto, Area, Status)
VALUES ('Projeto C - Hackathon Fest', 'Eventos', 1);
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(120) NOT NULL,
    Tipo VARCHAR(120) NOT NULL -- Esta era a coluna que faltava
);
GO

INSERT INTO Usuarios (Email, Senha, Tipo)
VALUES ('adm@email.com', '123', 'Administrador');
GO

INSERT INTO Usuarios (Email, Senha, Tipo)
VALUES ('usuario@email.com', '123', 'UsuarioComum');
GO