using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***********************************************
using Microsoft.EntityFrameworkCore;
using ProyectoStore.EN;

namespace ProyectoStore.DAL
{
    public class DBContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Laptops> Laptons { get; set; }
        public DbSet<SmartPhone> SmartPhone { get; set; }
        public DbSet<Tablets> Tablets { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Comprar> Comprar { get; set; }
        public DbSet<Registro> Registro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ALBERTH;Initial Catalog=TIENDA;Integrated Security=True;Trust Server Certificate=true;");
        }

    }
}
