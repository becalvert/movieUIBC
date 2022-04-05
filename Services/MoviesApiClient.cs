using MoviesUI.Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MoviesUI.Services
{
    public class MoviesApiClient
    {
        public HttpClient Client { get; set; }

        public MoviesApiClient(HttpClient client) {

            client.BaseAddress = new System.Uri("https://localhost:44310");

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;
        }

        public async Task<IEnumerable<Movie>> GetMovieList()
        {
            return await Client.GetFromJsonAsync<IEnumerable<Movie>>("/api/Movies");
        }



    }
}
