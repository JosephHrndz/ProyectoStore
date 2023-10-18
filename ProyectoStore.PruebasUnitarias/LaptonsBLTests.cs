using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoStore.BL;
using ProyectoStore.DAL;
using ProyectoStore.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.BL.Tests
{
    [TestClass()]
    public class LaptonsBLTests
    {
        private static Laptons laptonsInicial = new Laptons { Id=4 };
        private LaptonsBL laptonsBL = new LaptonsBL();
        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            var laptons = new Laptons();
            laptons.Nombre = "HP";
            laptons.Detalle = "Modelo 2020";
            laptons.Precio = 400;
            laptons.IdCarrito =1;
            int result = await laptonsBL.CrearAsync(laptons);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            var laptons = new Laptons();
            laptons.Id = laptonsInicial.Id;
            laptons.Nombre = "Dell";
            laptons.Detalle ="Modelo 2021";
            laptons.Precio =275;
            laptons.IdCarrito =1;
            int result = await laptonsBL.ModificarAsync(laptons);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {

            var result = await laptonsBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            var laptons = new Laptons();
            laptons.Id = laptonsInicial.Id;
            var resultlaptons = await laptonsBL.ObtenerPorIdAsync(laptons);
            Assert.AreEqual(laptons.Id, resultlaptons.Id);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            var laptons = new Laptons();
            laptons.Nombre="h";
            laptons.Top_Aux=10;
            var resultLaptons = await laptonsBL.BuscarAsync(laptons);
            Assert.AreNotEqual(0, resultLaptons.Count);
        }

        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            var laptons = new Laptons();
            laptons.Id = laptonsInicial.Id;
            int result = await laptonsBL.EliminarAsync(laptons);
            Assert.AreNotEqual(0, result);
        }

    }
}