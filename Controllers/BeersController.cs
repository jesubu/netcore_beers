using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apibeers.Data;
using apibeers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apibeers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        public BeersController()
        {

        }
        [Route("allBeers")]
        [HttpGet]
        public IEnumerable<Beer> GetAll() => BeersRespository.Beers;

        [HttpPost]
        public IActionResult AddBeer(Beer beer)
        {
            BeersRespository.Add(beer);
            return new StatusCodeResult((int)System.Net.HttpStatusCode.Created);
        }
    }
}