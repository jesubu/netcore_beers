using apibeers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibeers.Data
{
    public static class BeersRespository
    {
        private static List<Beer> _beers;
        public static IEnumerable<Beer> Beers => _beers;

        static BeersRespository()
        {
            _beers = new List<Beer>();
            _beers.AddRange(new[] {
                new Beer{ Name="Voll Damm",Abv=7.4},
                new Beer{ Name="CruzCampo", Abv=4.5}
            });
        }

        public  static void Add(Beer beer)
        {
            _beers.Add(beer);
            //throw new NotImplementedException();
        }
    }
}
