USE [BolsaEmpleoDB]
GO
TRUNCATE TABLE [dbo].[vacante_ofertada];
INSERT INTO [dbo].[vacante_ofertada]
           ([codigo]
           ,[cargo]
           ,[descripcion]
           ,[empresa]
           ,[salario]) VALUES
           ('RS001',
		   'Ingeniero Industrial',
		   'Se requiere Ingeniero 2.500.000 Industrial con mínimo 2 años de experiencia en Salud Ocupacional',
		   'EPM',
		   2500000),
		   ('RS002',
		   'Profesor de Química',
		   'Se requiere Químico con mínimo 3 años de experiencia en docencia.',
		   'INSTITUCIÓN EDUCATIVA IES',
		   1900000),
		   ('RS003',
		   'Ingeniero de Desarrollo Junior',
		   'Se requiere Ingeniero de Sistemas con mínimo 1 año de experiencia en Desarrollo de Software en tecnología JAVA.',
		   'XRM SERVICES',
		   2600000),
		   ('RS004',
		   'Coordinador de Mercadeo',
		   'Se necesita Coordinador de Mercadeo con estudios Tecnológicos graduado y experiencia mínima de un año.',
		   'INSERCOL',
		   1350000),
		   ('RS005',
		   'Profesor de Matemáticas',
		   'Se requiere Licenciado en Matemáticas o Ingeniero con mínimo 2 años de experiencia en docencia.',
		   'SENA',
		   1750000),
		   ('RS006',
		   'Mensajero',
		   'Se requiere mensajero con moto, con documentos al día y buenas relaciones personales.',
		   'SERVIENTREGA',
		   950000),
		   ('RS007',
		   'Cajero',
		   'Se requiere cajero para almacén de cadena con experiencia mínima de un año, debe disponer de tiempo por cambios de turnos.',
		   'ALMACENES ÉXITO',
		   850000)
GO


