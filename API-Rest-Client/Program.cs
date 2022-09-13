using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_Rest_Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Pressione qualquer teclado...");
            Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44391/api/Produto");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine($"response error code: {response.StatusCode}");
                }
            }
        }
    }
}
