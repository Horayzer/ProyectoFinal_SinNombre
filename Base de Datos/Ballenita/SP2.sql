--Procedimiento Almacenado para Asignar un Jugador a un Partido
CREATE PROCEDURE AsignarJugadorAPartido
    @ID_Jugador INT,
    @ID_Partido INT
AS
BEGIN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM JugadorPartido WHERE ID_Jugador = @ID_Jugador AND ID_Partido = @ID_Partido)
        BEGIN
            INSERT INTO JugadorPartido (ID_Jugador, ID_Partido)
            VALUES (@ID_Jugador, @ID_Partido);
            
            SELECT 'Jugador asignado exitosamente al partido' AS Mensaje;
        END
        ELSE
        BEGIN
            SELECT 'El jugador ya está asignado a este partido' AS Mensaje;
        END
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS Mensaje;
    END CATCH
END;
