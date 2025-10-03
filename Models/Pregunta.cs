using Newtonsoft.Json;

public class Pregunta
{

    [JsonProperty]
    public string Enunciado { get; private set; }
    
    [JsonProperty]
    public int Id { get; private set; }
    
    [JsonProperty]
    public int IdCategoria { get; private set; }
    



    public Pregunta()
    {
      

    }



}