using Newtonsoft.Json;

public class Juego
{
 [JsonProperty]
public string Username {get; private set;}
 [JsonProperty]
public int PuntajeActual {get; private set;}
 [JsonProperty]
public int CantidadPreguntasCorrectas {get; private set;}
 [JsonProperty]
public int ContadorNroPreguntaActual {get; private set;}
 [JsonProperty]
public Pregunta PreguntaActual {get; private set;}
 [JsonProperty]
public List<Pregunta> ListaPreguntas {get; private set;}
 [JsonProperty]
public List<Respuesta> ListaRespuestas {get; private set;}


public Juego ()
{


}

public void InicializarJuego()
{
Username = "";
PuntajeActual = 0; 
CantidadPreguntasCorrectas = 0;
ContadorNroPreguntaActual = 0; 
PreguntaActual = new Pregunta();
ListaPreguntas = new List<Pregunta>(); 
ListaRespuestas = new List<Respuesta>(); 

}

public List<Categoria> ObtenerCategoria()
{
List<Categoria> ListaCategorias = new List<Categoria>();
ListaCategorias = BD.TraerCategorias();

return ListaCategorias;
}


public void CargarPartida(string username, int categoria)
{
InicializarJuego();

ListaPreguntas = BD.ObtenerPreguntas(categoria);


}
































}

