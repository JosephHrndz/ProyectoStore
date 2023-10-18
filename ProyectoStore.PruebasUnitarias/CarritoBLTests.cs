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
    public class CarritoBLTests
    {
        private static Carrito carritoInicial = new Carrito { Id =2 };
        private CarritoBL carritoBL = new CarritoBL();

        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            var carrito = new Carrito();
            carrito.NombreDeProducto="Motorolo g8";
            carrito.Precio =150;
            carrito.Envio=10;
            carrito.TotalApagar=160;
            int result = await carritoBL.CrearAsync(carrito);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            var carrito = new Carrito();
            carrito.Id = carritoInicial.Id;
            carrito.NombreDeProducto="Smartphone Samsung";
            carrito.Precio=150;
            carrito.Envio=10;
            carrito.TotalApagar=160;
            int result =await carritoBL.ModificarAsync(carrito);
            Assert.AreNotEqual(0, result);
        }


        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            var result = await carritoBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            var carrito = new Carrito();
            carrito.Id = carritoInicial.Id;
            var resultCarrito = await carritoBL.ObtenerPorIdAsync(carrito);
            Assert.AreEqual(carrito.Id, resultCarrito.Id);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            var carrito = new Carrito();
            carrito.NombreDeProducto="a";
       
            var resultCarritos = await carritoBL.BuscarAsync(carrito);
            Assert.AreNotEqual(0, resultCarritos.Count);
        }
        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            var carrito = new Carrito();
            carrito.Id=carritoInicial.Id;
            int result = await carritoBL.EliminarAsync(carrito);
            Assert.AreNotEqual(0, result);
        }
    }
}