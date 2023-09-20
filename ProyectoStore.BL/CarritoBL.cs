using ProyectoStore.DAL;
using ProyectoStore.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.BL
{
    public class CarritoBL
    {
        public async Task<int> CrearAsync(Carrito pCarrito)
        {
            return await CarritoDAL.CrearAsync(pCarrito);
        }

        public async Task<int> ModificarAsync(Carrito pCarrito)
        {
            return await CarritoDAL.ModificarAsync(pCarrito);
        }

        public async Task<int> EliminarAsync(Carrito pCarrito)
        {
            return await CarritoDAL.EliminarAsync(pCarrito);
        }

        public async Task<List<Carrito>> ObtenerTodosAsync()
        {
            return await CarritoDAL.ObtenerTodosAsync();
        }

        public async Task<Carrito> ObtenerPorIdAsync(Carrito pCarrito)
        {
            return await CarritoDAL.ObtenerPorIdAsync(pCarrito);
        }

        public async Task<List<Carrito>> BuscarAsync(Carrito pCarrito)
        {

            return await CarritoDAL.BuscarAsync(pCarrito);
        }
    }
}
