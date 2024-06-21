--Procedimiento Almacenado para Insertar una Nueva Categoría de Equipo
CREATE PROCEDURE InsertarCategoriaEquipo
    @Nombre_Categoria NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Fundacion DATE,
    @Ciudad NVARCHAR(100),
    @Estadio NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        INSERT INTO CategoriaEquipo (Nombre_Categoria, Descripcion, Fundacion, Ciudad, Estadio)
        VALUES (@Nombre_Categoria, @Descripcion, @Fundacion, @Ciudad, @Estadio);
        
        -- Retornar el ID de la nueva categoría insertada
        DECLARE @NuevoID INT = SCOPE_IDENTITY();
        SELECT @NuevoID AS ID_Categoria, 'Categoría de equipo insertada exitosamente' AS Mensaje;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS Mensaje;
    END CATCH
END;
