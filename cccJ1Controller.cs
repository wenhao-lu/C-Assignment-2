using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI1.Controllers
{
    public class cccJ1Controller : ApiController
    {
        // Problem J1: Cupcake Party
        // GET: api/J1/cupcake/{R}/{S}
        [HttpGet]
        [Route("api/J1/cupcake/{R}/{S}")]
        public int Get(int R, int S)
        {
            int cakes = (R * 8) + (S * 3);
            int left = cakes - 28;
            return left;
        }

    }
}
