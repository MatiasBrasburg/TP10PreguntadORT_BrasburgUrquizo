using Newtonsoft.Json;

public class Respuesta
{
    [JsonProperty]
    public int Opcion { get; private set; }
    [JsonProperty]
    public string Contenido { get; private set; }
    [JsonProperty]
    public bool Correcta { get; private set; }
    public Respuesta(int Opcion, string Contenido, bool Correcta)
    {
        this.Opcion = Opcion;
        this.Contenido = Contenido;
        this.Correcta = Correcta;

    }




}