using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using tp04.Entities;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using tp04.Logic;
namespace tp07.MVC.Controllers
{
    public class PokeapiController : Controller
    {
        // GET: Pokeapi
        ShippersLogic shippersLogic = new ShippersLogic();

        PokemonLogic logic = new PokemonLogic();
 
        public async Task<ActionResult> Index()
        {
            string pokemonName = Request["name"].ToString().ToLower();

            return View("Index", await logic.Get(pokemonName));
        }

        public ActionResult Search()
        {
            return View("Search");
        }
    }
}