using Newtonsoft.Json;

namespace Lab12TODOLIST.Models
{
    public class Curso
    {
        [JsonProperty("imagen")]
        public string Imagen { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("docente")]
        public string Docente { get; set; }

        [JsonProperty("ciclo")]
        public string Ciclo { get; set; }
    }
}
