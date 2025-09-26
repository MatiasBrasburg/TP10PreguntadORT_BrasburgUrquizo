using Microsoft.Data.SqlClient;
using Dapper;



public static class BD
{

private static string _connectionString = @"Server=localhost;
DataBase=PreguntadosBd(Prog);Integrated Security=True;TrustServerCertificate=True;";


// POR SI DESPUES NECESITAAMOS TRAER ALGO SOLO DE LA BD 
// public static Integrantes CompararUsuarioEnBD (string NombreUSU, string Contrasena)
// {
// Integrantes existe = null;
//     using (SqlConnection connection = new SqlConnection(_connectionString))
//     {
//         string query = "SELECT * FROM Integrantes where NombreUsuario = @pNombreusuarios AND Contrasena = @pContrasena ";
//         existe = connection.QueryFirstOrDefault<Integrantes>(query, new {pNombreusuarios = NombreUSU, pContrasena = Contrasena});
//     }
//     Console.WriteLine(existe);
//     return existe;
// }


public static List<Categoria> TraerCategorias ()
{
List<Categoria> ListCategorias = new List<Categoria>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Categorias";
        ListCategorias = connection.Query<Categoria>(query).ToList();
    }
    return ListCategorias;
}

public static List<Pregunta> ObtenerPreguntas (int IdCategoria)
{
List<Pregunta> ListPreguntas = new List<Pregunta>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Preguntas Where IdCategoria = @IdCategoria";
        ListPreguntas = connection.Query<Pregunta>(query, new{IdCategoria = IdCategoria}).ToList();
    }
    return ListPreguntas;
}

public static List<Respuesta> ObtenerRespestas (int IdPregunta)
{
List<Respuesta> ListRespuestas = new List<Respuesta>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Respuestas Where IdPregunta = @IdPregunta";
        ListRespuestas = connection.Query<Respuesta>(query, new{IdPregunta = IdPregunta}).ToList();
    }
    return ListRespuestas;
}

}
