using Newtonsoft.Json;

public class Categoria
{
 [JsonProperty]
public string Nombre {get; private set;}

public Categoria (string Nombre)
{
this.Nombre = Nombre;

}
 





}