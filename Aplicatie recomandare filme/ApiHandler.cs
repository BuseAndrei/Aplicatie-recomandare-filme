using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie_recomandare_filme
{
    public class ApiHandler
    {
        private HttpClient client = new HttpClient();

        public async Task<Movie> GetMovie(int id)
        {
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJjZDA1ZTA3YzM0YWFhMWQyY2UwODNlN2E5NTU1MmZhNyIsInN1YiI6IjY0YTViOTYzNWE5OTE1MDEwMDdkYWU4MCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.Qsp8ENmD9gHi3A3kV2AprWCrUVMYegB2u5RaEkB9wRY");
                HttpResponseMessage response = await client.GetAsync($"http://movieapi.example.com/movies/{id}?api_key=cd05e07c34aaa1d2ce083e7a95552fa7");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Movie movie = JsonConvert.DeserializeObject<Movie>(responseBody);
                return movie;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message: {0} ", e.Message);
                return null;
            }
        }

    }
}
