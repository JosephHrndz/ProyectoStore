using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ProyectoStore.EN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.DAL
{
    public class RegistroDAL
    {
        public static async Task<int> CrearAsync(Registro pRegistro)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pRegistro);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Registro pRegistro)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var registro = await dbContexto.Registro.FirstOrDefaultAsync(s => s.Id == pRegistro.Id);
                registro.Correo = pRegistro.Correo;
                registro.Usuario = pRegistro.Usuario;
                registro.Contraseña = pRegistro.Contraseña;
               
                dbContexto.Update(registro);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Registro pRegistro)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var registro = await dbContexto.Registro.FirstOrDefaultAsync(s => s.Id == pRegistro.Id);
                dbContexto.Registro.Remove(registro);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }


        public static async Task<List<Registro>> ObtenerTodosAsync()
        {
            var registro = new List<Registro>();
            using (var dbContexto = new DBContexto())
            {
                registro = await dbContexto.Registro.ToListAsync();
            }
            return registro;
        }

        public static async Task<Registro> ObtenerPorIdAsync(Registro pRegistro)
        {
            var registro = new Registro();
            using (var dbContexto = new DBContexto())
            {
                registro = await dbContexto.Registro.FirstOrDefaultAsync(s => s.Id == pRegistro.Id);
            }
            return registro;
        }

        internal static IQueryable<Registro> QuerySelect(IQueryable<Registro> pQuery, Registro pRegistro)
        {
            if (pRegistro.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRegistro.Id);

            if (!string.IsNullOrWhiteSpace(pRegistro.Correo))
                pQuery = pQuery.Where(s => s.Correo.Contains(pRegistro.Correo));


            if (!string.IsNullOrWhiteSpace(pRegistro.Usuario))
                pQuery = pQuery.Where(s => s.Usuario.Contains(pRegistro.Usuario));


            if (!string.IsNullOrWhiteSpace(pRegistro.Contraseña))
                pQuery = pQuery.Where(s => s.Contraseña.Contains(pRegistro.Contraseña));


            return pQuery;
        }
        public static async Task<List<Registro>> BuscarAsync(Registro pRegistro)
        {
            var registro = new List<Registro>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Registro.AsQueryable();
                select = QuerySelect(select, pRegistro);
                registro = await select.ToListAsync();
            }
            return registro;
        }
    }
}
