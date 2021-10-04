using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using tp04.Entities;

namespace tp04.Logic
{
    public class PokemonLogic
    {

        public async Task<PokemonDTO> Get(string name)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
            dynamic data = JObject.Parse(json);

            PokemonDTO pokemon = new PokemonDTO
            {
                name = data.name,
                sprite = data.sprites.other.dream_world.front_default,
                firstAbility = data.abilities[0].ability.name,
                secondAbility = data.abilities[1].ability.name,
                height = (double)data.height / 10,
                weight = (double)data.weight / 10
            };

            return pokemon;

        }
    }
}
