USE Alexa_Tarea3_Lenguajes_2024
GO

--productos
BEGIN

	CREATE TABLE Productos(
		IDProducto INT PRIMARY KEY IDENTITY,
		NombreProducto NVARCHAR(50) NOT NULL,
		Precio DECIMAL(18,2) NOT NULL,
		Stock INT DEFAULT(0)
	)

	--Inserts
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Camiseta', 20.99, 50);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Pantalón', 34.99, 30);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Zapatos', 49.99, 20);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Gorra', 9.99, 100);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Bufanda', 14.99, 40);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Calcetines', 7.99, 80);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Abrigo', 89.99, 10);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Pantalones cortos', 24.99, 60);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Suéter', 39.99, 25);
	INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES ('Vestido', 54.99, 15);

	--VER INFORMACION
	SELECT TOP (1000) [IDProducto]
		  ,[NombreProducto]
		  ,[Precio]
		  ,[Stock]
	  FROM [dbo].[Productos]

END

--listaDeDeseos
BEGIN

	CREATE TABLE ListaDeDeseos(
		IDDeseo BIGINT PRIMARY KEY IDENTITY,
		IDProducto INT NOT NULL,
		CONSTRAINT fk_producto_listaDeseos
		FOREIGN KEY (IDProducto) 
		REFERENCES Productos(IDProducto),
		Cantidad INT,
	)

	--Inserts
	INSERT INTO ListaDeDeseos (IDProducto, Cantidad) VALUES (1, 2);
	INSERT INTO ListaDeDeseos (IDProducto, Cantidad) VALUES (3, 1);
	INSERT INTO ListaDeDeseos (IDProducto, Cantidad) VALUES (5, 3);
	INSERT INTO ListaDeDeseos (IDProducto, Cantidad) VALUES (7, 1);
	INSERT INTO ListaDeDeseos (IDProducto, Cantidad) VALUES (9, 2);

	
	SELECT [IDDeseo]
		  ,[IDProducto]
		  ,[Cantidad]
	  FROM [dbo].[ListaDeDeseos]

END


