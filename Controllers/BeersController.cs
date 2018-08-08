using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apibeers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apibeers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        [Route("allBeers")]
        [HttpGet]
        public IEnumerable<Beer> GetAll()
        {
            return new[]
            {
                new Beer{ Name="Voll Damm",Abv=7.4},
                new Beer{ Name="CruzCampo", Abv=4.5}
            };

        }
    }
}