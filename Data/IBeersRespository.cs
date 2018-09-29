using System.Collections.Generic;
using apibeers.Models;

namespace apibeers.Data
{
    public interface IBeersRespository
    {
        IEnumerable<Beer> Beers { get; }

        void Add(Beer beer);
        Beer GetBeerById(int id);
        bool ContainsBeer(int id);
        void DeleteBeer(int id);
    }
}