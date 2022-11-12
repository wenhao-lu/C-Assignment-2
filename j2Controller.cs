using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WenhaoLu_Assign1.Controllers
{
    public class j2Controller : ApiController
    {
        /// <summary>
        /// Adapted j2 - Roll the Dice
        /// GET: api/j2/DiceGame/{m}/{n}
        /// </summary>
        /// <param name="m">the number of sides on the first die</param>
        /// <param name="n">the number of sides on the second die</param>
        /// <returns>the total ways when rolling the value of 10</returns>
        /// <example>
        /// api/J2/DiceGame/12/4    ->     4
        /// </example>
        [HttpGet]
        [Route("api/j2/DiceGame/{m}/{n}")]
        public string Get(int m, int n)
        {
            int diceCount = 0;
            for (int a = 1; a <= m; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    if (a + b == 10)
                    {
                        diceCount++;
                    }
                }
            }
            return "There are " + diceCount.ToString() + " ways to get the sum 10.";
        }
    }
}

