using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibeers.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Abv { get; set; }
    }
}
