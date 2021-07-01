USE BaseDeDatosFacturacionMVC;

CREATE PROC P_VENTAS_PRODUCTO_FILTRADO_CODIGOP @Id_Producto int
AS
	SELECT p.codigo_producto, p.nombre, CONVERT(DATE,f.fecha) AS Dia, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Productos p
	INNER JOIN factura_Productos fp ON fp.codigo_producto = p.codigo_producto
	INNER JOIN facturas f ON f.numero_factura = fp.numero_factura
	WHERE fp.codigo_producto = @Id_Producto
	AND f.anulada = 'N'
	GROUP BY p.codigo_producto, p.nombre, CONVERT(DATE,f.fecha)
	ORDER BY p.codigo_producto, Dia;
-- EXEC P_VENTAS_PRODUCTO_FILTRADO_CODIGOP 6

CREATE PROC P_VENTAS_PRODUCTO
AS
	SELECT p.codigo_producto, p.nombre, CONVERT(DATE,f.fecha) AS Dia, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Productos p
	INNER JOIN factura_Productos fp ON fp.codigo_producto = p.codigo_producto
	INNER JOIN facturas f ON f.numero_factura = fp.numero_factura
	WHERE f.anulada = 'N'
	GROUP BY p.codigo_producto, p.nombre, CONVERT(DATE,f.fecha)
	ORDER BY p.codigo_producto, Dia;
-- EXEC P_VENTAS_PRODUCTO

CREATE PROC P_VENTAS_PRODUCTO_FILTRADO_CODIGOP_FECHAS @Id_Producto int, @FechaInicio Datetime, @FechaFinal Datetime
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, p.codigo_producto, p.nombre, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Productos p
	INNER JOIN factura_Productos fp ON fp.codigo_producto = p.codigo_producto
	INNER JOIN facturas f ON f.numero_factura = fp.numero_factura
	WHERE fp.codigo_producto = @Id_Producto
	AND f.fecha BETWEEN  @FechaInicio AND DATEADD(DAY,1,@FechaFinal)
	AND f.anulada = 'N'
	GROUP BY p.codigo_producto, p.nombre, CONVERT(DATE,f.fecha)
	ORDER BY p.codigo_producto, Dia;

CREATE PROC P_VENTAS_PRODUCTO_FILTRADO_CODIGO_SOLOFECHAS @FechaInicio Datetime, @FechaFinal Datetime
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, p.codigo_producto, p.nombre, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Productos p
	INNER JOIN factura_Productos fp ON fp.codigo_producto = p.codigo_producto
	INNER JOIN facturas f ON f.numero_factura = fp.numero_factura
	WHERE f.fecha BETWEEN  @FechaInicio AND DATEADD(DAY,1,@FechaFinal)
	and f.anulada = 'N'
	GROUP BY p.codigo_producto, p.nombre, CONVERT(DATE,f.fecha)
	ORDER BY p.codigo_producto, Dia;

CREATE PROC P_VENTAS_CLIENTE
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, c.codigo_cliente, nombres+' '+c.apellidos AS nombres, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Clientes c
	INNER JOIN facturas f ON f.codigo_cliente = c.codigo_cliente
	INNER JOIN factura_Productos fp ON fp.numero_factura = f.numero_factura
	WHERE f.anulada = 'N'
	GROUP BY CONVERT(DATE,f.fecha), c.codigo_cliente, c.nombres, c.apellidos
	ORDER BY Dia, c.codigo_cliente;
-- EXEC P_VENTAS_CLIENTE

CREATE PROC P_VENTAS_CLIENTEP @id int
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, c.codigo_cliente, nombres+' '+c.apellidos AS nombres, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Clientes c
	INNER JOIN facturas f ON f.codigo_cliente = c.codigo_cliente
	INNER JOIN factura_Productos fp ON fp.numero_factura = f.numero_factura
	WHERE f.codigo_cliente = @id
	AND f.anulada = 'N'
	GROUP BY CONVERT(DATE,f.fecha), c.codigo_cliente, c.nombres, c.apellidos
	ORDER BY Dia, c.codigo_cliente;
-- EXEC P_VENTAS_CLIENTEP 3

CREATE PROC P_VENTAS_CLIENTEP_FILTRADO_CODIGOP_FECHAS @id int, @FechaInicio Datetime, @FechaFinal Datetime
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, c.codigo_cliente, nombres+' '+c.apellidos AS nombres, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Clientes c
	INNER JOIN facturas f ON f.codigo_cliente = c.codigo_cliente
	INNER JOIN factura_Productos fp ON fp.numero_factura = f.numero_factura
	WHERE f.codigo_cliente = @id
	AND f.fecha BETWEEN  @FechaInicio AND DATEADD(DAY,1,@FechaFinal)
	AND f.anulada = 'N'
	GROUP BY CONVERT(DATE,f.fecha), c.codigo_cliente, c.nombres, c.apellidos
	ORDER BY Dia, c.codigo_cliente;

CREATE PROC P_VENTAS_CLIENTEP_FILTRADO_CODIGO_SOLO_FECHAS @FechaInicio Datetime, @FechaFinal Datetime
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, c.codigo_cliente, nombres+' '+c.apellidos AS nombres, SUM(fp.cantidad*fp.precio_unitario) AS TotalVendido
	FROM Clientes c
	INNER JOIN facturas f ON f.codigo_cliente = c.codigo_cliente
	INNER JOIN factura_Productos fp ON fp.numero_factura = f.numero_factura
	WHERE f.fecha >= @FechaInicio
	AND f.fecha <= DATEADD(DAY,1,@FechaFinal)
	AND f.anulada = 'N'
	GROUP BY CONVERT(DATE,f.fecha), c.codigo_cliente, c.nombres, c.apellidos
	ORDER BY Dia, c.codigo_cliente;

CREATE PROC P_REPORTE_FACTURAS
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, COUNT(*) AS CantidadFacturas, SUM(f.total_factura) AS MontoFacturado, SUM(fp.cantidad) AS CantidadProductos
	FROM facturas f
	INNER JOIN factura_Productos fp ON fp.numero_factura = f.numero_factura
	WHERE f.anulada = 'N'
	GROUP BY CONVERT(DATE,f.fecha)
	ORDER BY Dia;

CREATE PROC P_REPORTE_FACTURAS_FECHAS @FechaInicio Datetime, @FechaFinal Datetime
AS
	SELECT CONVERT(DATE,f.fecha) AS Dia, COUNT(*) AS CantidadFacturas, SUM(f.total_factura) AS MontoFacturado, SUM(fp.cantidad) AS CantidadProductos
	FROM facturas f
	INNER JOIN factura_Productos fp ON fp.numero_factura = f.numero_factura
	WHERE f.fecha >= @FechaInicio
	AND f.fecha <= DATEADD(DAY,1,@FechaFinal)
	AND f.anulada = 'N'
	GROUP BY CONVERT(DATE,f.fecha)
	ORDER BY Dia; 