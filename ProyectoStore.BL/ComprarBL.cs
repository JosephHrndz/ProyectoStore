using ProyectoStore.DAL;
using ProyectoStore.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.BL
{
    public class ComprarBL
    {

        public async Task<int> CrearAsync(Comprar pComprar)
        {
            return await ComprarDAL.CrearAsync(pComprar);
        }

        public async Task<int> ModificarAsync(Comprar pComprar)
        {
            return await ComprarDAL.ModificarAsync(pComprar);
        }

        public async Task<int> EliminarAsync(Comprar pComprar)
        {
            return await ComprarDAL.EliminarAsync(pComprar);
        }

        public async Task<List<Comprar>> ObtenerTodosAsync()
        {
            return await ComprarDAL.ObtenerTodosAsync();
        }

        public async Task<Comprar> ObtenerPorIdAsync(Comprar pComprar)
        {
            return await ComprarDAL.ObtenerPorIdAsync(pComprar);
        }

        public async Task<List<Comprar>> BuscarAsync(Comprar pComprar)
        {

            return await ComprarDAL.BuscarAsync(pComprar);
        }
    }
}
