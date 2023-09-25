using ProyectoStore.DAL;
using ProyectoStore.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.BL
{
    public class RegistroBL
    {
        public async Task<int> CrearAsync(Registro pRegistro)
        {
            return await RegistroDAL.CrearAsync(pRegistro);
        }

        public async Task<int> ModificarAsync(Registro pRegistro)
        {
            return await RegistroDAL.ModificarAsync(pRegistro);
        }

        public async Task<int> EliminarAsync(Registro pRegistro)
        {
            return await RegistroDAL.EliminarAsync(pRegistro);
        }

        public async Task<List<Registro>> ObtenerTodosAsync()
        {
            return await RegistroDAL.ObtenerTodosAsync();
        }

        public async Task<Registro> ObtenerPorIdAsync(Registro pRegistro)
        {
            return await RegistroDAL.ObtenerPorIdAsync(pRegistro);
        }

        public async Task<List<Registro>> BuscarAsync(Registro pRegistro)
        {

            return await RegistroDAL.BuscarAsync(pRegistro);
        }
    }
}
