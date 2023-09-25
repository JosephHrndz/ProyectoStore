
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//****************************************
using ProyectoStore.DAL;
using ProyectoStore.EN;

namespace ProyectoStore.BL
{
    public class LaptopsBL
    {
        public async Task<int> CrearAsync(Laptops pLaptons)
        {
            return await LaptopsDAL.CrearAsync(pLaptons);
        }

        public async Task<int> ModificarAsync(Laptops pLaptons)
        {
            return await LaptopsDAL.ModificarAsync(pLaptons);
        }

        public async Task<int> EliminarAsync(Laptops pLaptons)
        {
            return await LaptopsDAL.EliminarAsync(pLaptons);
        }

        public async Task<List<Laptops>> ObtenerTodosAsync()
        {
            return await LaptopsDAL.ObtenerTodosAsync();
        }

        public async Task<Laptops> ObtenerPorIdAsync(Laptops pLaptons)
        {
            return await LaptopsDAL.ObtenerPorIdAsync(pLaptons);
        }

        public async Task<List<Laptops>> BuscarAsync(Laptops pLaptons)
        {

            return await LaptopsDAL.BuscarAsync(pLaptons);
        }
    }
}
