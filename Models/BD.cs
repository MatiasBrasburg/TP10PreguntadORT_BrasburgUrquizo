using Microsoft.Data.SqlClient;
using Dapper;



public static class BD
{

private static string _connectionString = @"Server=localhost;
DataBase=ProgTP6BaseDeDatos;Integrated Security=True;TrustServerCertificate=True;";



public static Integrantes CompararUsuarioEnBD (string NombreUSU, string Contrasena)
{
Integrantes existe = null;
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes where NombreUsuario = @pNombreusuarios AND Contrasena = @pContrasena ";
        existe = connection.QueryFirstOrDefault<Integrantes>(query, new {pNombreusuarios = NombreUSU, pContrasena = Contrasena});
    }
    Console.WriteLine(existe);
    return existe;
}


public static List<Categoria> TraerListaIntegrantes ()
{
List<Categoria> ListCategorias = new List<Categoria>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Categorias";
        ListCategorias = connection.Query<Categoria>(query).ToList();
    }
    return ListCategorias;
}

public static List<Preguntas> ObtenerPreguntas (int IdCategoria)
{
List<Preguntas> ListPreguntas = new List<Preguntas>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Preguntas Where IdCategoria = @IdCategoria";
        ListPreguntas = connection.Query<Preguntas>(query, new{IdCategoria = IdCategoria}).ToList();
    }
    return ListPreguntas;
}

public static List<Respuestas> ObtenerRespestas (int IdPregunta)
{
List<Respuestas> ListRespuestas = new List<Respuestas>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Respuestas Where IdPregunta = @IdPregunta";
        ListRespuestas = connection.Query<Respuestas>(query, new{IdPregunta = IdPregunta}).ToList();
    }
    return ListRespuestas;
}

}
