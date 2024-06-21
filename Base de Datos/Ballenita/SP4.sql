--Procedimiento Almacenado para Actualizar la Información de un Jugador
CREATE PROCEDURE ActualizarJugador
    @ID_Jugador INT,
    @Nombre_Jugador NVARCHAR(100),
    @Posicion NVARCHAR(50),
    @Fecha_Nacimiento DATE,
    @Nacionalidad NVARCHAR(50),
    @ID_Categoria INT,
    @Foto_Jugador_URL NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        UPDATE Jugador
        SET Nombre_Jugador = @Nombre_Jugador,
            Posicion = @Posicion,
            Fecha_Nacimiento = @Fecha_Nacimiento,
            Nacionalidad = @Nacionalidad,
            ID_Categoria = @ID_Categoria,
            Foto_Jugador_URL = @Foto_Jugador_URL
        WHERE ID_Jugador = @ID_Jugador;
        
        SELECT @ID_Jugador AS ID_Jugador, 'Jugador actualizado exitosamente' AS Mensaje;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS Mensaje;
    END CATCH
END;
