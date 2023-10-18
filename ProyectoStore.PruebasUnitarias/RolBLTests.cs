using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoStore.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoStore.EN;

namespace ProyectoStore.BL.Tests
{
    [TestClass()]
    public class RolBLTests
    {
        private static Rol rolInicial = new Rol { Id=1};//Rol existente
        private RolBL rolbL =new RolBL();
        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "Admin2";
            int result = await rolbL.CrearAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            rol.Nombre ="Admin3";
            int result = await rolbL.ModificarAsync(rol);
            Assert.AreNotEqual(0, result);

        }

       
        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            var result = await rolbL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            var resultRol = await rolbL.ObtenerPorIdAsync(rol);
            Assert.AreEqual(rol.Id, resultRol.Id);

        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "a";
            rol.Top_Aux =10;
            var resultRoles = await rolbL.BuscarAsync(rol);
            Assert.AreNotEqual(0, resultRoles.Count);
    
        }
        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            int result = await rolbL.EliminarAsync(rol);
            Assert.AreEqual (0, result);
        }

    }

}