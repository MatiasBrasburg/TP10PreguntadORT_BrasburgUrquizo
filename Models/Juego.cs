using Newtonsoft.Json;

public class Juego
{
    [JsonProperty]
    public string Username { get; private set; }
    [JsonProperty]
    public int PuntajeActual { get; private set; }
    [JsonProperty]
    public int CantidadPreguntasCorrectas { get; private set; }
    [JsonProperty]
    public int ContadorNroPreguntaActual { get; private set; }
    [JsonProperty]
    public Pregunta PreguntaActual { get; private set; }
    [JsonProperty]
    public List<Pregunta> ListaPreguntas { get; private set; }
    [JsonProperty]
    public List<Respuesta> ListaRespuestas { get; private set; }
    [JsonProperty]
public Pregunta ProximaPregunta { get; private set; }

    public Juego()
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

    public List<Categoria> ObtenerCategorias()
    {
        List<Categoria> ListaCategorias = new List<Categoria>();
        ListaCategorias = BD.TraerCategorias();

        return ListaCategorias;
    }


    public void CargarPartida(string username, int categoria)
    {
        InicializarJuego();
        Username = username;
        ListaPreguntas = BD.ObtenerPreguntas(categoria);

    }

    public Pregunta ObtenerProximaPregunta(){

        ProximaPregunta = ListaPreguntas[ContadorNroPreguntaActual + 1];
       PreguntaActual = ProximaPregunta;
        return ProximaPregunta;
    }


public List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
{
ListaRespuestas = BD.ObtenerRespuestas(idPregunta);
    return ListaRespuestas;
}



public bool VerificarRespuesta(int idRespuesta)
{
     bool EstaCorrecta = false;
    if(ListaRespuestas[idRespuesta].Correcta)
    {
   EstaCorrecta = true;
  PuntajeActual += 10;
  CantidadPreguntasCorrectas ++;
    }
  
  ContadorNroPreguntaActual++; 
  PreguntaActual = ObtenerProximaPregunta();

    return EstaCorrecta;
}

























}

