using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using ProyectoStore.EN;

namespace ProyectoStore.DAL
{
    public class CarritoDAL
    {
        public static async Task<int> CrearAsync(Carrito pCarrito)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pCarrito);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Carrito pCarrito)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var carrito = await dbContexto.Carrito.FirstOrDefaultAsync(s => s.Id == pCarrito.Id);
                carrito.NombreProducto = pCarrito.NombreProducto;
                carrito.Precio = pCarrito.Precio;
                carrito.Envio = pCarrito.Envio;
                carrito.TotalApagar = pCarrito.TotalApagar;
                dbContexto.Update(carrito);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Carrito pCarrito)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var carrito = await dbContexto.Carrito.FirstOrDefaultAsync(s => s.Id == pCarrito.Id);
                dbContexto.Carrito.Remove(carrito);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }


        public static async Task<List<Carrito>> ObtenerTodosAsync()
        {
            var carritos = new List<Carrito>();
            using (var dbContexto = new DBContexto())
            {
                carritos = await dbContexto.Carrito.ToListAsync();
            }
            return carritos;
        }

        public static async Task<Carrito> ObtenerPorIdAsync(Carrito pCarrito)
        {
            var carrito = new Carrito();
            using (var dbContexto = new DBContexto())
            {
                carrito = await dbContexto.Carrito.FirstOrDefaultAsync(s => s.Id == pCarrito.Id);
            }
            return carrito;
        }

        internal static IQueryable<Carrito> QuerySelect(IQueryable<Carrito> pQuery, Carrito pCarrito)
        {
            if (pCarrito.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCarrito.Id);
            if (!string.IsNullOrWhiteSpace(pCarrito.NombreProducto))
                pQuery = pQuery.Where(s => s.NombreProducto.Contains(pCarrito.NombreProducto));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pCarrito.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pCarrito.Precio);


            if (pCarrito.Envio > 0)
                pQuery = pQuery.Where(s => s.Envio == pCarrito.Envio);

            if (pCarrito.TotalApagar > 0)
                pQuery = pQuery.Where(s => s.TotalApagar == pCarrito.TotalApagar);

            return pQuery;
        }
        public static async Task<List<Carrito>> BuscarAsync(Carrito pCarrito)
        {
            var carrito = new List<Carrito>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Carrito.AsQueryable();
                select = QuerySelect(select, pCarrito);
                carrito = await select.ToListAsync();
            }
            return carrito;
        }
    }
}
