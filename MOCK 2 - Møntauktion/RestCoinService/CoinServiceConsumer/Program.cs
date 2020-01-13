using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoinServiceConsumer
{
    class Program
    {
        private static string coinUri = "https://localhost:44358/api/Coins/";

        static void Main(string[] args)
        {
            HttpRequests();
            Console.ReadKey();
        }

        public static async void HttpRequests()
        {
            Console.WriteLine("GET ALL COINS REQUEST");
            List<Coin> coinList = GetCoinsRequest().Result;

            foreach (Coin coin in coinList)
            {
                Console.WriteLine(coin);
            }

            Console.WriteLine("\nGET ONE COIN REQUEST");
            Coin oneCoin = GetOneCoinRequest(2).Result;
            Console.WriteLine(oneCoin);
        }

        public static async Task<List<Coin>> GetCoinsRequest()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(coinUri);
                List<Coin> cList = JsonConvert.DeserializeObject<List<Coin>>(content);
                return cList;
            }
        }

        public static async Task<Coin> GetOneCoinRequest(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(coinUri + id);
                Coin coin = JsonConvert.DeserializeObject<Coin>(content);
                return coin;
            }
        }
    }
}
