USE [Empleados]
GO
/****** Object:  Table [dbo].[Nomina]    Script Date: 19/06/2020 08:44:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomina](
	[Nombre_Completo] [varchar](30) NULL,
	[Cedula] [varchar](50) NULL,
	[Sueldo_Bruto] [money] NULL,
	[Borrado] [bit] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Nomina] ON 

INSERT [dbo].[Nomina] ([Nombre_Completo], [Cedula], [Sueldo_Bruto], [Borrado], [ID]) VALUES (N'Benjamin Baez', N'402-0910015-1', 25000.0000, 1, 1)
INSERT [dbo].[Nomina] ([Nombre_Completo], [Cedula], [Sueldo_Bruto], [Borrado], [ID]) VALUES (N'Bienvenido Baez', N'402-1234567-8', 85000.0000, 0, 2)
INSERT [dbo].[Nomina] ([Nombre_Completo], [Cedula], [Sueldo_Bruto], [Borrado], [ID]) VALUES (N'Migdalia Baez', N'402-2345678-9', 71000.0000, 0, 3)
SET IDENTITY_INSERT [dbo].[Nomina] OFF
/****** Object:  StoredProcedure [dbo].[CreateEmpleado]    Script Date: 19/06/2020 08:44:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateEmpleado] @Nombre_Completo varchar (30), @Cedula varchar (50), @Sueldo_Bruto money
as
INSERT INTO Nomina (Nombre_Completo, Cedula, Sueldo_Bruto, Borrado) VALUES (@Nombre_Completo, @Cedula, @Sueldo_Bruto, 0)
GO
/****** Object:  StoredProcedure [dbo].[FindByCedula]    Script Date: 19/06/2020 08:44:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FindByCedula] @Cedula varchar (50)
as
SELECT Cedula, Nombre_Completo, Sueldo_Bruto, (Sueldo_Bruto * 0.0287) as AFP, (Sueldo_Bruto * 0.0304) as ARS, ((Sueldo_Bruto * 0.0287) + (Sueldo_Bruto * 0.0304)) as Total_Retencion, (Sueldo_Bruto - ((Sueldo_Bruto * 0.0287) + (Sueldo_Bruto * 0.0304))) as Sueldo_Neto FROM Nomina WHERE Cedula = @Cedula AND borrado = 0
GO
/****** Object:  StoredProcedure [dbo].[SoftDelete]    Script Date: 19/06/2020 08:44:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SoftDelete] @Cedula varchar (50)
as
UPDATE Nomina SET Borrado = 1 WHERE Cedula = @Cedula
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmpleado]    Script Date: 19/06/2020 08:44:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateEmpleado] @Nombre_Completo varchar (30), @Sueldo_Bruto money, @Cedula varchar (50)
as
UPDATE Nomina SET Nombre_Completo = @Nombre_Completo, Sueldo_Bruto = @Sueldo_Bruto WHERE Cedula = @Cedula AND Borrado=0
GO
