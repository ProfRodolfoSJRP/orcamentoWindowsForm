create database bd_orcamento

use bd_orcamento

CREATE TABLE Clientes (
    telefone nvarchar(20),
    endereco nvarchar(100),
    Id_Cliente int PRIMARY KEY identity(1,1),
    nome nvarchar(80)
);

CREATE TABLE Tecnicos (
    Id_tecnico int PRIMARY KEY identity(1,1),
    nome nvarchar(80),
    especializacao nvarchar(50),
    telefone nvarchar(20)
);

CREATE TABLE Orcamento (
    id_orcamento int PRIMARY KEY identity(1,1),
    setor nvarchar(80),
    descricao nvarchar(max),
    finalizado bit,
    fk_Clientes_Id_Cliente int,
    fk_Tecnicos_Id_tecnico int
);
 
ALTER TABLE Orcamento ADD CONSTRAINT FK_Orcamento_2
    FOREIGN KEY (fk_Clientes_Id_Cliente)
    REFERENCES Clientes (Id_Cliente)
 
ALTER TABLE Orcamento ADD CONSTRAINT FK_Orcamento_3
    FOREIGN KEY (fk_Tecnicos_Id_tecnico)
    REFERENCES Tecnicos (Id_tecnico)