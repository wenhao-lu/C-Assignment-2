using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI1.Controllers
{
    public class J1Controller : ApiController
    {


        // Adapted J1 - The New CCC (Canadian Calorie Counting)
        // GET: api/J1/Menu/{burger}/{drink}/{side}/{dessert}
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public int Get(int burger, int drink, int side, int dessert)
        {
            int[] addBurger = {461, 431, 420, 0};
            int[] addDrink = {130, 160, 118, 0};
            int[] addSide = {100, 57, 70, 0};
            int[] addDessert = {167, 266, 75, 0};
            int sumCal = addBurger[burger - 1] + addDrink[drink - 1] + addSide[side - 1] + addDessert[dessert - 1];
            return sumCal;
        }

    }
}
