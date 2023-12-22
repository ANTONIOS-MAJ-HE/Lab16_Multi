using Lab12TODOLIST.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab12TODOLIST.Services
{
    public class ApiService
    {
        private HttpClient client = new HttpClient();
        private string apiUrl = "https://api-face-face.onrender.com/cursos/";

        public async Task<List<Curso>> GetCursosAsync()
        {
            var jsonResponse = await client.GetStringAsync(apiUrl);
            return JsonConvert.DeserializeObject<List<Curso>>(jsonResponse);
        }

        public async Task<bool> AddCursoAsync(Curso curso)
        {
            var jsonCurso = JsonConvert.SerializeObject(curso);
            var content = new StringContent(jsonCurso, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiUrl, content);
            return response.IsSuccessStatusCode;
        }
    }
}
