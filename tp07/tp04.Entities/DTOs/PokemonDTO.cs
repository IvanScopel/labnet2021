using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp04.Entities
{
    public class PokemonDTO
    {



        public string name { get; set; }
        public string sprite { get; set; }
        public string firstAbility{ get; set; }
        public string secondAbility { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
    }
}