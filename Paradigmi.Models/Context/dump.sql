CREATE TABLE Categoria (
    Id INT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL
);

CREATE TABLE Libro (
    Id INT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Autore VARCHAR(255) NOT NULL,
    Editore VARCHAR(255) NOT NULL,
    DataPubblicazione DATETIME NOT NULL
);

CREATE TABLE Utente (
    Id INT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Cognome VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE LibroCategoria (
    LibroId INT,
    CategoriaId INT,
    PRIMARY KEY (LibroId, CategoriaId),
    CONSTRAINT FK_LibroId FOREIGN KEY (LibroId) REFERENCES Libro(Id),
    CONSTRAINT FK_CategoriaId FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id)
);