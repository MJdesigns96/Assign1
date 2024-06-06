using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign1.Controllers
{
    public class AssignmentController : ApiController
    {
        /// <summary>
            /// Takes input from the URI and returns 10 more than the integer
        /// </summary>
        /// <param name="id">The user input that will have 10 added ot it</param>
        /// <returns> the integer sum of id + 10 </returns>
        /// <example>
            /// GET : /api/AddTen/5 -> 15;
            /// GET : /api/AddTen/21 -> 31;     
        /// </example>
        [Route("api/AddTen/{id}")]
        [HttpGet]
        public int AddTen (int id)
        {
            int sum = id + 10;
            return sum;
        }

        /// <summary>
            /// Takes User input and squares the integer input 
        /// </summary>
        /// <param name="id">The integer input to be squared</param>
        /// <returns> The squared integer of id </returns>
        /// <example>
            /// GET : /api/Square/2 -> 4;
            /// GET : /api/Square/-2 -> 4;
            /// GET : /api/Square/10 -> 100;
        /// </example>
        [Route("api/Square/{id}")]
        [HttpGet]
        public int Square(int id) {
            int square = id * id;
            return square;
        }

        /// <summary>
            /// Returns a post reponse greeting to the user
        /// </summary>
        /// <returns> "Hello World!" </returns>
        /// <example>
            /// POST : /api/Greeting/ -> "Hello World!";
        /// </example>
        [Route("api/Greeting")]
        [HttpPost]
        public string Greeting()
        {
            return "Hello World!";
        }

        /// <summary>
            /// Returns a string with {id} number of people; id is an integer value
        /// </summary>
        /// <param name="id">the integer input</param>
        /// <returns> "Greetings to {id} people!"</returns>
        /// <example>
            /// GET : api/Greeting/3 -> "Greetings to 3 people!";
            /// GET : api/Greeting/6 -> "Greetings to 6 people!";
            /// GET : api/Greeting/0 -> "Greetings to 0 people!";
        /// </example>
        [Route("api/Greeting/{id}")]
        [HttpGet]
        public string Greeting(int id)
        {
            return "Greetings to " + id + " people!";
        }

        /// <summary>
            /// A method that takes in an integer then adds itself, squares the sum, subtracts itself, then divides itself to return a number
        /// </summary>
        /// <param name="id">the integer that is being manipulated</param>
        /// <returns>
            /// ((id + id)^2 - id)/id
        /// </returns>
        /// <example>
            /// GET : api/NumberMachine/10 -> 39;
            /// GET : api/NumberMachine/-5 -> -21;
            /// GET : api/NumberMachine/30 -> 119;
        /// </example>
        [Route("api/NumberMachine/{id}")]
        [HttpGet]
        public int NumberMachine(int id)
        {
            int sum = id + id;
            int square = sum * sum;
            int subtract = square - id;
            int divide = subtract / id;

            return divide;
        }
        /// <summary>
        /// Take user input and return three lines of cost breakdown for hosting their site.
        /// </summary>
        /// <param name="id">how many days</param>
        /// <param name="fn">forthnight</param>
        /// <param name="tax">tax of 13%</param>
        /// <returns>
        ///     X is computed total
        ///     response 1 -> "{id} fortnights at $5.50/FN = X CAD"
        ///     response 2 -> "HST 13% = $X CAD"
        ///     response 3 -> "Total = $X CAD"
        /// </returns>
        /// <examples>
        ///     GET : /api/HostingCost/0 -> "1 fortnights at $5.50/FN = 5.50 CAD HST 13% = 0.72 CAD Total = 6.22"
        ///     GET : /api/HostingCost/14 -> "2 fortnights at $5.50/FN = 11.00 CAD HST 13% = 1.43 CAD Total = 12.43"
        ///     GET : /api/HostingCost/28 -> "3 fortnights at $5.50/FN = 16.50 CAD HST 13% = 2.14 CAD Total = 18.64"
        /// </examples>
        /// <sources>
        ///     MATH -> https://www.w3schools.com/cs/cs_math.php
        ///     .ToString -> https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring?view=net-8.0
        /// </sources>
        [Route("api/HostingCost/{id}")]
        [HttpGet]
        public IEnumerable<string> HostingCost(int id) {
            //add 1 to id because it counts days since hosting
            double temp = id + 1;

            //set variables and calculate totals
            double days = Math.Ceiling(temp / 14);
            double fort =(days * 5.50);
            fort = Math.Round(fort, 2);
            double tax = fort * 0.13;
            tax = Math.Round(tax, 2);
            double total = fort + tax;
            
            //compile the variables into strings
            string ans1 = days + " fortnights at $5.50/FN = " + fort.ToString("0.00") + " CAD ";
            string ans2 = "HST 13% = " + tax + " CAD ";
            string ans3 = "Total = " + total;

            //return totals
            return new string[] { ans1, ans2, ans3 };
        }
    }
}
