using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoStore.BL;
using ProyectoStore.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.BL.Tests
{
    [TestClass()]
    public class ComprarBLTests
    {
        private static Comprar comprarIinicial = new Comprar { Id=3 };
        private ComprarBL comprarBL = new ComprarBL();
        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            var comprar = new Comprar();
            comprar.Nombre ="Carlos";
            comprar.Apellido="Hernandez";
            comprar.Telefono=76654532;
            comprar.Direccion="Sonsonate";
            int result = await comprarBL.CrearAsync(comprar);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            var comprar = new Comprar();
            comprar.Id = comprarIinicial.Id;
            comprar.Nombre="Alexis";
            comprar.Apellido="Perez";
            comprar.Telefono=60456728;
            comprar.Direccion="San salvador";
            int result = await comprarBL.ModificarAsync(comprar);
            Assert.AreNotEqual(0, result);
        }
     

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            var result = await comprarBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            var comprar = new Comprar();
            comprar.Id = comprarIinicial.Id;
            var resultComprar = await comprarBL.ObtenerPorIdAsync(comprar);
            Assert.AreEqual(comprar.Id, resultComprar.Id);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            var comprar = new Comprar();
            comprar.Nombre="a";
            var resultComprar = await comprarBL.BuscarAsync(comprar);
            Assert.AreNotEqual(0, resultComprar.Count);
        }
        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            var comprar = new Comprar();
            comprar.Id =comprarIinicial.Id;
            int result = await comprarBL.EliminarAsync(comprar);
            Assert.AreNotEqual(0, result);
        }
    }
}