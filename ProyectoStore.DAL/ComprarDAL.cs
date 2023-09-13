using ProyectoStore.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using ProyectoStore.EN;

namespace ProyectoStore.DAL
{
    public class ComprarDAL
    {

        public static async Task<int> CrearAsync(Comprar pComprar)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pComprar);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Comprar pComprar)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var comprar = await dbContexto.Comprar.FirstOrDefaultAsync(s => s.Id == pComprar.Id);
                comprar.NOMBRE = pComprar.Nombre;
                comprar.APELLIDO = pComprar.Apellido;
                comprar.NUMTELEFONO = pComprar.Telefono;
                comprar.DIRECCION = pComprar.Direccion;
                dbContexto.Update(comprar);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Comprar pComprar)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var comprar = await dbContexto.Comprar.FirstOrDefaultAsync(s => s.Id == pComprar.Id);
                dbContexto.Comprar.Remove(comprar);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }


        public static async Task<List<Comprar>> ObtenerTodosAsync()
        {
            var comprars = new List<Comprar>();
            using (var dbContexto = new DBContexto())
            {
                comprars = await dbContexto.Comprar.ToListAsync();
            }
            return comprars;
        }

        public static async Task<Comprar> ObtenerPorIdAsync(Comprar pComprar)
        {
            var comprar = new Comprar();
            using (var dbContexto = new DBContexto())
            {
                comprar = await dbContexto.Comprar.FirstOrDefaultAsync(s => s.Id == pComprar.Id);
            }
            return comprar;
        }

        internal static IQueryable<Comprar> QuerySelect(IQueryable<Comprar> pQuery, Comprar pComprar)
        {
            if (pComprar.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pComprar.Id);
            if (!string.IsNullOrWhiteSpace(pComprar.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pComprar.Nombre));


            if (!string.IsNullOrWhiteSpace(pComprar.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pComprar.Apellido));


            if (pComprar.Telefono > 0)
                pQuery = pQuery.Where(s => s.Telefono == pComprar.Telefono);

            if (!string.IsNullOrWhiteSpace(pComprar.Direccion))
                pQuery = pQuery.Where(s => s.Direccion.Contains(pComprar.Direccion));

            if (pComprar.Top_Aux > 0)
                pQuery = pQuery.Take(pComprar.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Comprar>> BuscarAsync(Comprar pComprar)
        {
            var comprar = new List<Comprar>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Comprar.AsQueryable();
                select = QuerySelect(select, pComprar);
                comprar = await select.ToListAsync();
            }
            return comprar;
        }
    }
}
