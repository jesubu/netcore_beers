using apibeers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibeers.Data
{
    public class BeersRespository : IBeersRespository
    {

        private List<Beer> _beers;
        public IEnumerable<Beer> Beers => _beers;

        public BeersRespository()
        {
            _beers = new List<Beer>();
            _beers.AddRange(new[] {
                new Beer{ Id=1, Name="Voll Damm",Abv=7.4},
                new Beer{ Id=2, Name="CruzCampo", Abv=4.5}
            });
        }

        public  void Add(Beer beer)
        {
            _beers.Add(beer);
            //throw new NotImplementedException();
        }

        public Beer GetBeerById(int id)
        {
            return _beers.SingleOrDefault(x => x.Id == id); //retorna null cuando no hay 
        }
    }
}
