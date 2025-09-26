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
PreguntaActual = null;
ListaPreguntas = null; 
ListaRespuestas = null; 

}





































}

