using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCoinService.Model;

namespace RestCoinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        public static List<Coin> coinList = new List<Coin>()
        {
            new Coin(1, "Gold DK 1640", 2500, "Mike"),
            new Coin(2, "Gold NL 1764", 5000, "Anbo"),
            new Coin(3, "Gold FR 1644", 35000, "Hammer"),
            new Coin(4, "Gold FR 1644", 0, "Auction"),
            new Coin(5, "Silver GR 333", 2500, "Mike")
        };

        [HttpGet]
        [Route("/api/Coins")]
        public List<Coin> GetCoins()
        {
            return coinList;
        }

        [HttpGet]
        [Route("/api/Coins/{id}")]
        public Coin GetOneCoin(int id)
        {
            return coinList.Find(c => c.Id == id);
        }

        [HttpPost]
        [Route("/api/AddCoin")]
        public void AddCoin(Coin newCoin)
        {
            coinList.Add(newCoin);
        }

        [HttpPut]
        [Route("/api/EditCoin/{id}")]
        public void EditCoin(int id, Coin editCoin)
        {
            Coin coin = coinList.Find(c => c.Id == id);
            
        }
    }
}
