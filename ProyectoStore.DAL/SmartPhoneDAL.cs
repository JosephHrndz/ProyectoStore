using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//******************************************
using Microsoft.EntityFrameworkCore;
using ProyectoStore.EN;

namespace ProyectoStore.DAL
{
    public class SmartPhoneDAL
    {
        public static async Task<int> CrearAsync(SmartPhone pSmartPhone)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pSmartPhone);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(SmartPhone pSmartPhone)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var SmartPhone = await dbContexto.SmartPhone.FirstOrDefaultAsync(s => s.Id == pSmartPhone.Id);
                SmartPhone.Nombre = pSmartPhone.Nombre;
                SmartPhone.Detalle = pSmartPhone.Detalle;
                SmartPhone.Precio = pSmartPhone.Precio;
                SmartPhone.IdCarrito = pSmartPhone.IdCarrito;
                dbContexto.Update(SmartPhone);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(SmartPhone pSmartPhone)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var SmartPhone = await dbContexto.SmartPhone.FirstOrDefaultAsync(s => s.Id == pSmartPhone.Id);
                dbContexto.SmartPhone.Remove(SmartPhone);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<SmartPhone>> ObtenerTodosAsync()
        {
            var SmartPhones = new List<SmartPhone>();
            using (var dbContexto = new DBContexto())
            {
                SmartPhones = await dbContexto.SmartPhone.ToListAsync();
            }
            return SmartPhones;
        }
        public static async Task<SmartPhone> ObtenerPorIdAsync(SmartPhone pSmartPhone)
        {
            var SmartPhone = new SmartPhone();
            using (var dbContexto = new DBContexto())
            {
                SmartPhone = await dbContexto.SmartPhone.FirstOrDefaultAsync(s => s.Id == pSmartPhone.Id);
            }
            return SmartPhone;
        }
        internal static IQueryable<SmartPhone> QuerySelect(IQueryable<SmartPhone> pQuery, SmartPhone pSmartPhone)
        {
            if (pSmartPhone.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pSmartPhone.Id);
            if (!string.IsNullOrWhiteSpace(pSmartPhone.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pSmartPhone.Nombre));
            if (!string.IsNullOrWhiteSpace(pSmartPhone.Detalle))
                pQuery = pQuery.Where(s => s.Detalle.Contains(pSmartPhone.Detalle));
            if (pSmartPhone.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pSmartPhone.Precio);
            if (pSmartPhone.IdCarrito > 0)
                pQuery = pQuery.Where(s => s.IdCarrito == pSmartPhone.IdCarrito);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pSmartPhone.Top_Aux > 0)
                pQuery = pQuery.Take(pSmartPhone.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<SmartPhone>> BuscarAsync(SmartPhone pSmartPhone)
        {
            var SmartPhones = new List<SmartPhone>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.SmartPhone.AsQueryable();
                select = QuerySelect(select, pSmartPhone);
                SmartPhones = await select.ToListAsync();
            }
            return SmartPhones;
        }


    }
}

