using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCoinService.Model
{
    public class Coin
    {
        public int Id { get; set; }
        public string Genstand { get; set; }
        public int Bud { get; set; }
        public string Navn { get; set; }

        public Coin(int id, string genstand, int bud, string navn)
        {
            Id = id;
            Genstand = genstand;
            Bud = bud;
            Navn = navn;
        }

        public Coin()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Genstand)}: {Genstand}, {nameof(Bud)}: {Bud}, {nameof(Navn)}: {Navn}";
        }
    }
}
