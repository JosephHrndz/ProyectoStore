
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
    public class LaptonsBL
    {
        public async Task<int> CrearAsync(Laptons pLaptons)
        {
            return await LaptonsDAL.CrearAsync(pLaptons);
        }

        public async Task<int> ModificarAsync(Laptons pLaptons)
        {
            return await LaptonsDAL.ModificarAsync(pLaptons);
        }

        public async Task<int> EliminarAsync(Laptons pLaptons)
        {
            return await LaptonsDAL.EliminarAsync(pLaptons);
        }

        public async Task<List<Laptons>> ObtenerTodosAsync()
        {
            return await LaptonsDAL.ObtenerTodosAsync();
        }

        public async Task<Laptons> ObtenerPorIdAsync(Laptons pLaptons)
        {
            return await LaptonsDAL.ObtenerPorIdAsync(pLaptons);
        }

        public async Task<List<Laptons>> BuscarAsync(Laptons pLaptons)
        {

            return await LaptonsDAL.BuscarAsync(pLaptons);
        }
    }
}
