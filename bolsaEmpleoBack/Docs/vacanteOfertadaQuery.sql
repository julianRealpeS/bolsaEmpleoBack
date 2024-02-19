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
		   'Se requiere Ingeniero 2.500.000 Industrial con m�nimo 2 a�os de experiencia en Salud Ocupacional',
		   'EPM',
		   2500000),
		   ('RS002',
		   'Profesor de Qu�mica',
		   'Se requiere Qu�mico con m�nimo 3 a�os de experiencia en docencia.',
		   'INSTITUCI�N EDUCATIVA IES',
		   1900000),
		   ('RS003',
		   'Ingeniero de Desarrollo Junior',
		   'Se requiere Ingeniero de Sistemas con m�nimo 1 a�o de experiencia en Desarrollo de Software en tecnolog�a JAVA.',
		   'XRM SERVICES',
		   2600000),
		   ('RS004',
		   'Coordinador de Mercadeo',
		   'Se necesita Coordinador de Mercadeo con estudios Tecnol�gicos graduado y experiencia m�nima de un a�o.',
		   'INSERCOL',
		   1350000),
		   ('RS005',
		   'Profesor de Matem�ticas',
		   'Se requiere Licenciado en Matem�ticas o Ingeniero con m�nimo 2 a�os de experiencia en docencia.',
		   'SENA',
		   1750000),
		   ('RS006',
		   'Mensajero',
		   'Se requiere mensajero con moto, con documentos al d�a y buenas relaciones personales.',
		   'SERVIENTREGA',
		   950000),
		   ('RS007',
		   'Cajero',
		   'Se requiere cajero para almac�n de cadena con experiencia m�nima de un a�o, debe disponer de tiempo por cambios de turnos.',
		   'ALMACENES �XITO',
		   850000)
GO


