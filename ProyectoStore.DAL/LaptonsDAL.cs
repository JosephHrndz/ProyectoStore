using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********************************
using Microsoft.EntityFrameworkCore;
using ProyectoStore.EN;


namespace ProyectoStore.DAL
{
    public class LaptonsDAL
    {
        public static async Task<int> CrearAsync(Laptons pLaptons)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pLaptons);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Laptons pLaptons)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var Laptons = await dbContexto.Laptons.FirstOrDefaultAsync(s => s.Id == pLaptons.Id);
                Laptons.Nombre = pLaptons.Nombre;
                Laptons.Detalle = pLaptons.Detalle;
                Laptons.Precio = pLaptons.Precio;
                Laptons.IdCarrito = pLaptons.IdCarrito;
                dbContexto.Update(Laptons);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Laptons pLaptons)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var laptons = await dbContexto.Laptons.FirstOrDefaultAsync(s => s.Id == pLaptons.Id);
                dbContexto.Laptons.Remove(laptons);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<Laptons>> ObtenerTodosAsync()
        {
            var laptonss = new List<Laptons>();
            using (var dbContexto = new DBContexto())
            {
                laptonss = await dbContexto.Laptons.ToListAsync();
            }
            return laptonss;
        }
        public static async Task<Laptons> ObtenerPorIdAsync(Laptons pLaptons)
        {
            var laptons = new Laptons();
            using (var dbContexto = new DBContexto())
            {
                laptons = await dbContexto.Laptons.FirstOrDefaultAsync(s => s.Id == pLaptons.Id);
            }
            return laptons;
        }
        internal static IQueryable<Laptons> QuerySelect(IQueryable<Laptons> pQuery, Laptons pLaptons)
        {
            if (pLaptons.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pLaptons.Id);
            if (!string.IsNullOrWhiteSpace(pLaptons.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pLaptons.Nombre));
            if (!string.IsNullOrWhiteSpace(pLaptons.Detalle))
                pQuery = pQuery.Where(s => s.Detalle.Contains(pLaptons.Detalle));
            if (pLaptons.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pLaptons.Precio);
            if (pLaptons.IdCarrito > 0)
                pQuery = pQuery.Where(s => s.IdCarrito == pLaptons.IdCarrito);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pLaptons.Top_Aux > 0)
                pQuery = pQuery.Take(pLaptons.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Laptons>> BuscarAsync(Laptons pLaptons)
        {
            var laptoness = new List<Laptons>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Laptons.AsQueryable();
                select = QuerySelect(select, pLaptons);
                laptoness = await select.ToListAsync();
            }
            return laptoness;
        }


    }
}
