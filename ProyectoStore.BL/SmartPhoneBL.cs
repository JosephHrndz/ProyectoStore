using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//***********************************
using ProyectoStore.DAL;
using ProyectoStore.EN;

namespace ProyectoStore.BL
{
    public class SmartPhoneBL
    {
        public async Task<int> CrearAsync(SmartPhone pSmartPhone)
        {
            return await SmartPhoneDAL.CrearAsync(pSmartPhone);
        }

        public async Task<int> ModificarAsync(SmartPhone pSmartPhone)
        {
            return await SmartPhoneDAL.ModificarAsync(pSmartPhone);
        }

        public async Task<int> EliminarAsync(SmartPhone pSmartPhone)
        {
            return await SmartPhoneDAL.EliminarAsync(pSmartPhone);
        }

        public async Task<List<SmartPhone>> ObtenerTodosAsync()
        {
            return await SmartPhoneDAL.ObtenerTodosAsync();
        }

        public async Task<SmartPhone> ObtenerPorIdAsync(SmartPhone pSmartPhone)
        {
            return await SmartPhoneDAL.ObtenerPorIdAsync(pSmartPhone);
        }

        public async Task<List<SmartPhone>> BuscarAsync(SmartPhone pSmartPhone)
        {

            return await SmartPhoneDAL.BuscarAsync(pSmartPhone);
        }
    }
}
