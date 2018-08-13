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
    //modalbinding a lo WebAPI
    //  --> si el content-type es application x-www-url-formencoded Al enviar JSON
    //      en el controlador tenemos que poner la clausula:  AddBeer([FromBody]Beer beer) 
    //      Existe un bindeo a lo webapi al existir la clausula FromBody
    //modalbinding a lo MVC
    //  --> Si el content-type es cualquier otro...estamos en una APIRest, 
    //      no tenemos que poner clausula ninguna.
    //

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
        public IActionResult AddBeer([FromBody]Beer beer)
        {
            BeersRespository.Add(beer);
            return new StatusCodeResult((int)System.Net.HttpStatusCode.Created);
        }

        [Route("BeerById/{id}")]
        [HttpGet]
        public IActionResult GetBeerById(int id)
        {
            var beer= BeersRespository.GetBeerById(id);
            if (beer == null)
            {
                return NotFound($"Beer with Id:{id} not found");
            }
            return Ok(beer);

        }
    }
}