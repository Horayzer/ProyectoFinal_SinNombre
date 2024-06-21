-- Procedimiento Almacenado para Obtener Información Detallada de un Partido
CREATE PROCEDURE ObtenerDetallePartido
    @ID_Partido INT
AS
BEGIN
    BEGIN TRY
        SELECT p.ID_Partido, p.Fecha, p.Hora, p.Estadio, p.Resultado,
               e.Nombre_Categoria AS Equipo,
               CASE p.Es_Local WHEN 1 THEN 'Local' ELSE 'Visitante' END AS Local_Visitante,
               STRING_AGG(j.Nombre_Jugador, ', ') WITHIN GROUP (ORDER BY j.Nombre_Jugador) AS Jugadores
        FROM Partido p
        JOIN CategoriaEquipo e ON p.ID_Equipo = e.ID_Categoria
        LEFT JOIN JugadorPartido jp ON p.ID_Partido = jp.ID_Partido
        LEFT JOIN Jugador j ON jp.ID_Jugador = j.ID_Jugador
        WHERE p.ID_Partido = @ID_Partido
        GROUP BY p.ID_Partido, p.Fecha, p.Hora, p.Estadio, p.Resultado, e.Nombre_Categoria, p.Es_Local;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS Mensaje;
    END CATCH
END;
