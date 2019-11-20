using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburgueseria.Models.ViewModel
{
    public class EleccionMenuVM
    {
        public List<Entrante> Entrantes { get; set; }
        public List<Principal> Principales { get; set; }
        public List<Postre> Postres { get; set; }
        public Menu Menu { get; set; }
    }
}
