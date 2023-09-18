using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//*******************************************
using ProyectoStore.DAL;
using ProyectoStore.EN;

namespace ProyectoStore.BL
{
    public class TabletsBL
    {
        public async Task<int> CrearAsync(Tablets pTablets)
        {
            return await TabletsDAL.CrearAsync(pTablets);
        }

        public async Task<int> ModificarAsync(Tablets pTablets)
        {
            return await TabletsDAL.ModificarAsync(pTablets);
        }

        public async Task<int> EliminarAsync(Tablets pTablets)
        {
            return await TabletsDAL.EliminarAsync(pTablets);
        }

        public async Task<List<Tablets>> ObtenerTodosAsync()
        {
            return await TabletsDAL.ObtenerTodosAsync();
        }

        public async Task<Tablets> ObtenerPorIdAsync(Tablets pTablets)
        {
            return await TabletsDAL.ObtenerPorIdAsync(pTablets);
        }

        public async Task<List<Tablets>> BuscarAsync(Tablets pTablets)
        {

            return await TabletsDAL.BuscarAsync(pTablets);
        }
    }
}
