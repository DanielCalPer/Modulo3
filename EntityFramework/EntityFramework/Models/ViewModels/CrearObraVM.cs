using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models.ViewModels
{
    public class CrearObraVM
    {
        public Obra Obra { get; set; }
        public List<Autor> Autores { get; set; }
    }
}
