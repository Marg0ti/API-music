CREATE DATABASE "Chinook_modificada";
USE "Chinook_modificada";

-- Tabla de Artistas
CREATE TABLE Artista (
    ArtistaId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL
);

-- Tabla de Álbumes
CREATE TABLE Album (
    AlbumId INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    ArtistaId INT NOT NULL,
    FOREIGN KEY (ArtistaId) REFERENCES Artista(ArtistaId)
);

-- Tabla de Géneros
CREATE TABLE Genero (
    GeneroId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL
);

-- Tabla de Pistas
CREATE TABLE Pista (
    PistaId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,
    AlbumId INT NOT NULL,
    GeneroId INT NOT NULL,
    Duracion INT NOT NULL,
    FOREIGN KEY (AlbumId) REFERENCES Album(AlbumId),
    FOREIGN KEY (GeneroId) REFERENCES Genero(GeneroId)
);
-- Insertar datos en Artista
INSERT INTO Artista (Nombre) VALUES 
('The Beatles'), 
('Queen'), 
('Led Zeppelin'), 
('Pink Floyd'), 
('Michael Jackson'), 
('Taylor Swift'), 
('AC/DC'), 
('The Rolling Stones'), 
('Adele'), 
('Eminem');

-- Insertar datos en Album
INSERT INTO Album (Titulo, ArtistaId) VALUES 
('Abbey Road', 1), 
('Revolver', 1), 
('A Night at the Opera', 2), 
('News of the World', 2), 
('Led Zeppelin IV', 3), 
('Houses of the Holy', 3), 
('The Dark Side of the Moon', 4), 
('The Wall', 4), 
('Thriller', 5), 
('Bad', 5), 
('1989', 6), 
('Folklore', 6), 
('Back in Black', 7), 
('Highway to Hell', 7), 
('Sticky Fingers', 8), 
('Let It Bleed', 8), 
('25', 9), 
('21', 9), 
('The Eminem Show', 10), 
('Recovery', 10);

-- Insertar datos en Genero
INSERT INTO Genero (Nombre) VALUES 
('Rock'), 
('Pop'), 
('Blues'), 
('Hip-Hop'), 
('Jazz'), 
('Classical'), 
('Electronic');

-- Insertar datos en Pista
INSERT INTO Pista (Nombre, AlbumId, GeneroId, Duracion) VALUES 
-- Abbey Road
('Come Together', 1, 1, 259), 
('Something', 1, 1, 183), 
('Here Comes the Sun', 1, 1, 185), 
-- Revolver
('Eleanor Rigby', 2, 1, 138), 
('Yellow Submarine', 2, 1, 144), 
('Tomorrow Never Knows', 2, 1, 179), 
-- A Night at the Opera
('Bohemian Rhapsody', 3, 1, 354), 
('Love of My Life', 3, 2, 213), 
-- News of the World
('We Will Rock You', 4, 1, 121), 
('We Are the Champions', 4, 1, 179), 
('Spread Your Wings', 4, 1, 277), 
-- Led Zeppelin IV
('Stairway to Heaven', 5, 1, 482), 
('Black Dog', 5, 1, 296), 
('Rock and Roll', 5, 1, 224), 
-- Houses of the Holy
('The Rain Song', 6, 1, 424), 
('Over the Hills and Far Away', 6, 1, 256), 
-- The Dark Side of the Moon
('Time', 7, 1, 412), 
('Money', 7, 1, 382), 
('Us and Them', 7, 1, 461), 
-- The Wall
('Another Brick in the Wall', 8, 1, 210), 
('Comfortably Numb', 8, 1, 384), 
('Run Like Hell', 8, 1, 268), 
-- Thriller
('Thriller', 9, 2, 358), 
('Billie Jean', 9, 2, 293), 
('Beat It', 9, 2, 258), 
-- Bad
('Bad', 10, 2, 254), 
('Man in the Mirror', 10, 2, 302), 
('Smooth Criminal', 10, 2, 257), 
-- 1989
('Shake It Off', 11, 2, 219), 
('Blank Space', 11, 2, 231), 
('Style', 11, 2, 230), 
-- Folklore
('Cardigan', 12, 2, 239), 
('The 1', 12, 2, 211), 
('Exile', 12, 2, 275), 
-- Back in Black
('Back in Black', 13, 1, 255), 
('You Shook Me All Night Long', 13, 1, 210), 
('Hells Bells', 13, 1, 312), 
-- Highway to Hell
('Highway to Hell', 14, 1, 207), 
('Touch Too Much', 14, 1, 240), 
-- Sticky Fingers
('Brown Sugar', 15, 1, 212), 
('Wild Horses', 15, 1, 342), 
-- Let It Bleed
('Gimme Shelter', 16, 1, 271), 
('Midnight Rambler', 16, 3, 411), 
-- 25
('Hello', 17, 2, 295), 
('Send My Love', 17, 2, 223), 
('When We Were Young', 17, 2, 292), 
-- 21
('Rolling in the Deep', 18, 2, 228), 
('Someone Like You', 18, 2, 285), 
('Set Fire to the Rain', 18, 2, 242), 
-- The Eminem Show
('Without Me', 19, 4, 290), 
('Superman', 19, 4, 336), 
-- Recovery
('Not Afraid', 20, 4, 242), 
('Love the Way You Lie', 20, 4, 263), 
('No Love', 20, 4, 286);

INSERT INTO Pista (Nombre, AlbumId, GeneroId, Duracion) VALUES 
('You''re My Best Friend', 3, 2, 169), 
('D''yer Mak''er', 6, 1, 263), 
('Can''t You Hear Me Knocking', 15, 3, 431), 
('Cleanin'' Out My Closet', 19, 4, 297), 
('If You Want Blood (You''ve Got It)', 14, 1, 274);