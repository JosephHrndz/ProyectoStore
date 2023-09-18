using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//********************************
using Microsoft.EntityFrameworkCore;
using ProyectoStore.EN;

namespace ProyectoStore.DAL
{
    public class TabletsDAL
    {
        public static async Task<int> CrearAsync(Tablets pTablets)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pTablets);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Tablets pTablets)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var Tablets = await dbContexto.Tablets.FirstOrDefaultAsync(s => s.Id == pTablets.Id);
                Tablets.Nombre = pTablets.Nombre;
                Tablets.Detalle = pTablets.Detalle;
                Tablets.Precio = pTablets.Precio;
                Tablets.IdCarrito = pTablets.IdCarrito;
                dbContexto.Update(Tablets);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Tablets pTablets)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var Tablets = await dbContexto.Tablets.FirstOrDefaultAsync(s => s.Id == pTablets.Id);
                dbContexto.Tablets.Remove(Tablets);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<Tablets>> ObtenerTodosAsync()
        {
            var Tabletss = new List<Tablets>();
            using (var dbContexto = new DBContexto())
            {
                Tabletss = await dbContexto.Tablets.ToListAsync();
            }
            return Tabletss;
        }
        public static async Task<Tablets> ObtenerPorIdAsync(Tablets pTablets)
        {
            var Tablets = new Tablets();
            using (var dbContexto = new DBContexto())
            {
                Tablets = await dbContexto.Tablets.FirstOrDefaultAsync(s => s.Id == pTablets.Id);
            }
            return Tablets;
        }
        internal static IQueryable<Tablets> QuerySelect(IQueryable<Tablets> pQuery, Tablets pTablets)
        {
            if (pTablets.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pTablets.Id);
            if (!string.IsNullOrWhiteSpace(pTablets.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pTablets.Nombre));
            if (!string.IsNullOrWhiteSpace(pTablets.Detalle))
                pQuery = pQuery.Where(s => s.Detalle.Contains(pTablets.Detalle));
            if (pTablets.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pTablets.Precio);
            if (pTablets.IdCarrito > 0)
                pQuery = pQuery.Where(s => s.IdCarrito == pTablets.IdCarrito);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pTablets.Top_Aux > 0)
                pQuery = pQuery.Take(pTablets.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Tablets>> BuscarAsync(Tablets pTablets)
        {
            var Tabletss = new List<Tablets>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Tablets.AsQueryable();
                select = QuerySelect(select, pTablets);
                Tabletss = await select.ToListAsync();
            }
            return Tabletss;
        }


    }
}

