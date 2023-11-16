USE alumta_dein;

DROP TABLE IF EXISTS Empleados;
CREATE TABLE Empleados(
	id INTEGER PRIMARY KEY,
	user_name VARCHAR(20) NOT NULL,
	user_surname VARCHAR(20) NOT NULL,
	email VARCHAR(100) NOT NULL,
	phone VARCHAR(50) NOT NULL
);

DROP TABLE IF EXISTS Usuarios;
CREATE TABLE Usuarios(
	id INTEGER PRIMARY KEY,
	user_name VARCHAR(20) NOT NULL,
	user_surname VARCHAR(20) NOT NULL,
	email VARCHAR(100) NOT NULL,
	phone VARCHAR(50) NOT NULL,
	user_type VARCHAR(20) NOT NULL CHECK(user_type IN('employee', 'user'))
);

DROP TABLE IF EXISTS Articulos;
CREATE TABLE Articulos(
	id INTEGER PRIMARY KEY,
	product_name VARCHAR(20) NOT NULL,
	price DECIMAL(6,2) NOT NULL
);

ALTER TABLE Empleados ADD CONSTRAINT FK_id_employee FOREIGN KEY (id) REFERENCES Usuarios(id);

INSERT INTO Usuarios VALUES(1, 'Alberto', 'Perez', 'albertoperez@test.com', '+34600000000', 'employee');
INSERT INTO Usuarios VALUES(2, 'Maria', 'Fernandez', 'mariafernandez@test.com', '+34600000000', 'user');
INSERT INTO Usuarios VALUES(3, 'Roberto', 'Sanchez', 'robertosanchez@test.com', '+34600000000', 'user');
INSERT INTO Usuarios VALUES(4, 'Lucia', 'Recalde', 'luciarecalde@test.com', '+34600000000', 'employee');
INSERT INTO Usuarios VALUES(5, 'Aritz', 'Pascual', 'aritzpascual@test.com', '+34600000000', 'employee');

INSERT INTO Empleados VALUES(1, 'Alberto', 'Perez', 'albertoperez@test.com', '+34600000000');
INSERT INTO Empleados VALUES(4, 'Lucia', 'Recalde', 'luciarecalde@test.com', '+34600000000');
INSERT INTO Empleados VALUES(5, 'Aritz', 'Pascual', 'aritzpascual@test.com', '+34600000000');

INSERT INTO Articulos VALUES(1, 'Ordenador', 1200.87);
INSERT INTO Articulos VALUES(2, 'Portatil', 1700.00);
INSERT INTO Articulos VALUES(3, 'Condensador', 65.59);
INSERT INTO Articulos VALUES(4, 'Teclado', 20);
INSERT INTO Articulos VALUES(5, 'Raton', 14.99);