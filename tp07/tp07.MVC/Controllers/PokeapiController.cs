using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace tp07.MVC.Controllers
{
    public class PokeapiController : Controller
    {
        // GET: Pokeapi
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon/ditto");
            return View("Index", new { json });
        }
    }
}