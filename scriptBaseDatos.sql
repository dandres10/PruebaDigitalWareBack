------------------------------------------->CREACION DE TABLAS
CREATE TABLE Producto  (
Codigo INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(50) NOT NULL,
Precio DECIMAL NOT NULL
);
GO

CREATE TABLE InventarioProducto (
Codigo INT IDENTITY(1,1) PRIMARY KEY,
CodigoProducto INT NOT NULL,
Cantidad INT,
CONSTRAINT FK_Productos_InventarioProductos_CodigoProducto FOREIGN KEY (CodigoProducto) REFERENCES Producto(Codigo)
);
GO

CREATE TABLE Cliente (
Codigo INT IDENTITY(1,1) PRIMARY KEY,
PrimerNombre NVARCHAR(50) NOT NULL,
SegundoNombre NVARCHAR(50),
PrimerApellido NVARCHAR(50) NOT NULL,
SegundoApellido NVARCHAR(50),
FechaNacimiento DATETIME,
Cedula INT NOT NULL UNIQUE
);
GO

CREATE TABLE Compra (
Codigo INT IDENTITY(1,1) PRIMARY KEY,
FechaCompra DATETIME NOT NULL,
Total DECIMAL NOT NULL
);
GO

CREATE TABLE Producto_Compra_Cliente (
	Codigo INT IDENTITY(1,1) PRIMARY KEY,
	CodigoProducto INT NOT NULL,
	CodigoCompra INT NOT NULL,
	CodigoCliente INT NOT NULL,
	CONSTRAINT FK_Productos_Compras_Clientes_CodigoProducto FOREIGN KEY (CodigoProducto) REFERENCES Producto(Codigo),
	CONSTRAINT FK_Productos_Compras_Clientes_CodigoCompra FOREIGN KEY (CodigoCompra) REFERENCES Compra(Codigo),
	CONSTRAINT FK_Productos_Compras_Clientes_CodigoCliente FOREIGN KEY (CodigoCliente) REFERENCES Cliente(Codigo)
);
------------------------------------------->CARGAR DATOS TABLAS
GO

INSERT 
INTO 
Producto (Nombre,Precio) 
VALUES 
('Lenteja Diana', 2590),
('Harina Pan', 3490),
('Leche x 6', 22590),
('Galletas Ducales Taco Extralargo', 7590),
('Aceite Gourmet Familia', 27993),
('Sal Refisal Bolsa', 1550),
('Fab florar poder acelerador', 14133),
('Avena Quaker hojuelas', 8190),
('Crema de leche bolsa Alqueria', 2890),
('Arroz supremo x 5kg', 18990),
('Papel Higiénico familia', 11893),
('Salchicha Ranchera x 14', 14390);
GO

INSERT 
INTO 
InventarioProducto (CodigoProducto,Cantidad) 
VALUES
(1,23),
(2,21),
(3,10),
(4,2),
(5,8),
(6,9),
(7,15),
(8,45),
(9,7),
(10,3),
(11,13),
(12,17);
GO

INSERT 
INTO 
Cliente (Cedula,FechaNacimiento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido)
VALUES 
(1233891911,'18/07/1997','Marlon','Andres','Leon','Leon'),
(1233891912,'17/08/1993','Margie','Andrea','Leon','Leon'),
(1233891913,'19/01/1999','Mariana','Alejandra','Leon','Leon');
GO

INSERT INTO 
Compra (FechaCompra,Total) 
VALUES 
('01/02/2000',28670), --'Lenteja Diana'-'Harina Pan'-'Leche x 6'
('11/02/2000',28670),
('14/02/2000',28670);

GO
INSERT INTO 
Producto_Compra_Cliente(CodigoCliente,CodigoCompra,CodigoProducto) 
values 
(1,1,1),
(1,1,2),
(1,1,3),
(2,2,1),
(2,2,2),
(2,2,3),
(3,3,1),
(3,3,2),
(3,3,3);


GO

-------------------------------------------------------------------->Procedimientos almacenados
--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)


CREATE PROCEDURE SP_ListaProductosCantidadMinimaPermitida
@cantidad int 
AS
BEGIN

select p.Codigo AS CodigoProducto , p.Nombre ,P.Precio,IPR.Cantidad FROM Producto AS p INNER JOIN InventarioProducto AS IPR ON p.Codigo = IPR.CodigoProducto where IPR.Cantidad <= @cantidad;
END;

execute SP_ListaProductosCantidadMinimaPermitida @cantidad = 10;

GO


--Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000



CREATE PROCEDURE SP_ListaClientesFiltroEdadFechaCompra
@fechaInicial date,
@fechaFinal date,
@edadNoMayor int
AS
BEGIN
select distinct
C.Codigo AS CodigoCliente, 
CONCAT(C.PrimerNombre, ' ',C.SegundoNombre, ' ', C.PrimerApellido, ' ', C.SegundoApellido) AS Nombre, 
YEAR( GETDATE())  - YEAR( CONVERT(date, C.FechaNacimiento)) AS Edad,
C.Cedula As Cedula
from 
Cliente AS C INNER JOIN Producto_Compra_Cliente AS PCC ON C.Codigo = PCC.CodigoCliente INNER JOIN Compra AS CO ON CO.Codigo = PCC.CodigoCompra 
where  
 @fechaInicial  >=  CONVERT(date, CO.FechaCompra ) AND    @fechaFinal  >= CONVERT(date, CO.FechaCompra) AND (  (YEAR( GETDATE())  - YEAR( CONVERT(date, C.FechaNacimiento))) < @edadNoMayor); 
END;
go
EXECUTE SP_ListaClientesFiltroEdadFechaCompra @fechaInicial = '2000-02-01' , @fechaFinal = '2000-05-25' , @edadNoMayor = 35;
go

--Obtener el valor total vendido por cada producto en el año 2000

CREATE PROCEDURE SP_ListaProductosVendidoAno
@ano int
AS
BEGIN
SELECT 
P.Codigo AS CodigoProducto,
P.Nombre AS Nombre,
SUM(P.Precio)AS Vendido , COUNT(PCC.CodigoProducto) AS Cantidad,
P.Precio AS ValorUnidad
from
Producto_Compra_Cliente AS PCC INNER JOIN Producto AS P ON PCC.CodigoProducto = P.Codigo INNER JOIN
Compra AS C ON PCC.CodigoCompra = C.Codigo 
WHERE YEAR(CONVERT(date,C.FechaCompra ) ) = @ano
Group by P.Codigo , P.Nombre,P.Precio;
END;
go

EXECUTE SP_ListaProductosVendidoAno @ano = 2000;


---Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar en qué fecha podría volver a comprar.
--consulta con linq


























