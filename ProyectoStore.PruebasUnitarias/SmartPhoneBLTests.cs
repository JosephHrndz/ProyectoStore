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
    public class SmartPhoneBLTests
    {
        private static SmartPhone phoneInicial = new SmartPhone { Id=1004 };
        private SmartPhoneBL smartphoneBL = new SmartPhoneBL();
        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            var smartphone = new SmartPhone();
            smartphone.Nombre = "Huawei";
            smartphone.Detalle = "Modelo Y7 2020";
            smartphone.Precio = 200;
            smartphone.IdCarrito =1;
            int result = await smartphoneBL.CrearAsync(smartphone);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            var smartphone = new SmartPhone();
            smartphone.Id = phoneInicial.Id;
            smartphone.Nombre = "Motorola";
            smartphone.Detalle ="Modelo g10 2021";
            smartphone.Precio =175;
            smartphone.IdCarrito =1;
            int result = await smartphoneBL.ModificarAsync(smartphone);
            Assert.AreNotEqual(0, result);
        }

      

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            var result = await smartphoneBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            var smartphone = new SmartPhone();
            smartphone.Id = phoneInicial.Id;
            var resultPhone = await smartphoneBL.ObtenerPorIdAsync(smartphone);
            Assert.AreEqual(smartphone.Id, resultPhone.Id);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            var smartphone = new SmartPhone();
            smartphone.Nombre="a";
            smartphone.Top_Aux=10;
            var resultPhones = await smartphoneBL.BuscarAsync(smartphone);
            Assert.AreNotEqual(0, resultPhones.Count);
        }
        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            var smartphone = new SmartPhone();
            smartphone.Id = phoneInicial.Id;
            int result = await smartphoneBL.EliminarAsync(smartphone);
            Assert.AreNotEqual(0, result);
        }
    }
}