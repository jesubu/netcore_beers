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
    // https://localhost:44335/api/Beers/allBeers


        //la dependencia permite injectar servicios.
        //en netcore esta implementado de serie, una diferencia con mvc5
        //vamos a injectar las depencias de nuestros controladores automaticamente
        //
        //
        //

        //PRINCIPIO DE RESPOSABILIDAD UNICA
        //cada clase deberia hacer una única tarea.
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeersRespository _beersRespository;

        public BeersController( IBeersRespository beersRespository)
        {
            this._beersRespository = beersRespository;

        }
        [Route("allBeers")]
        [HttpGet]
        public IEnumerable<Beer> GetAll() => _beersRespository.Beers;

        //se podría poner una llamada a un servicio y no ponerlo en el constructor [FromServices] IEmail email
        [HttpPost]
        public IActionResult AddBeer([FromBody]Beer beer)
        {
            if (ModelState.IsValid)
            {
                _beersRespository.Add(beer);
                return new StatusCodeResult((int)System.Net.HttpStatusCode.Created);
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("BeerById/{id}")]
        [HttpGet]
        public IActionResult GetBeerById(int id)
        {
            var beer= _beersRespository.GetBeerById(id);
            if (beer == null)
            {
                return NotFound($"Beer with Id:{id} not found");
            }
            return Ok(beer);

        }

        [HttpDelete("{id}")]
        public  IActionResult DeleteBeer(int id)
        {
            if (_beersRespository.ContainsBeer(id))
            {
                _beersRespository.DeleteBeer(id);
                return Ok($"Beer with id:{id} delete.");
            }
            return NotFound($"Beer with id: {id} not found.");
        }
    }
}