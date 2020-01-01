using GestionBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBox.Services
{
    public interface IClase
    {
        public Task<List<Clase>> GetClaseAsync();
        public Task<Clase> GetClaseByIdAsync(int? id);
        public Task CreateClaseAsync(Clase clase);
        public Task UpdateClaseAsync(Clase clase);
        public Task DeleteClaseAsync(Clase clase);
        public bool ClaseExist(int? id);
     
    }
}
