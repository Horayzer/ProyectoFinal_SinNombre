-- Procedimiento Almacenado para Listar Equipos y sus Patrocinadores
CREATE PROCEDURE ListarEquiposPatrocinadores
AS
BEGIN
    BEGIN TRY
        SELECT e.Nombre_Categoria AS Equipo,
               STRING_AGG(p.Nombre_Patrocinador, ', ') WITHIN GROUP (ORDER BY p.Nombre_Patrocinador) AS Patrocinadores
        FROM CategoriaEquipo e
        LEFT JOIN Patrocinador p ON e.ID_Categoria = p.ID_Categoria
        GROUP BY e.Nombre_Categoria;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS Mensaje;
    END CATCH
END;
