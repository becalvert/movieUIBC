using Microsoft.AspNetCore.Mvc;
using MoviesUI.Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviesUI.Services
{
    public class ActorsApiClient
    {
        public HttpClient Client { get; set; }
        
        public ActorsApiClient(HttpClient client) {

            client.BaseAddress = new System.Uri("https://localhost:7127");

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;

        }

        public async Task<IEnumerable<Actor>> GetActorsList()

        {
            return await Client.GetFromJsonAsync<IEnumerable<Actor>>("api/actors");
        }


        public async Task<Actor> GetActorItem(int ActorId)
       
        {
            var actorID = ActorId.ToString();
            return await Client.GetFromJsonAsync<Actor>("api/actors/"+actorID);
        }

        public async Task CreateActorItem(Actor actorItem)

        {
            await Client.PostAsJsonAsync<Actor>("api/actors", actorItem);
            return;
        }

        public async Task UpdateActorItem(int ActorId, Actor actorItem)

        {
           var actorID = ActorId.ToString();
           await Client.PutAsJsonAsync("api/actors/" + actorID, actorItem);
           return;

        }
        public async Task DeleteActorItem(int ActorId)

        {
            var actorID = ActorId.ToString();
            await Client.DeleteAsync("api/actors/" + actorID);
            return;
        }

    }
}
