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
        public DbSet<Laptons> Laptons { get; set; }
        public DbSet<SmartPhone> SmartPhone { get; set; }
        public DbSet<Tablets> Tablets { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Comprar> Comprar { get; set; }
        public DbSet<Registro> Registro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ALBERTH;Initial Catalog=TIENDA;Integrated Security=True;Trust Server Certificate=true;");
            optionsBuilder.UseSqlServer(@"workstation id=TiendaP.mssql.somee.com;packet size=4096;user id=Alberth_SQLLogin_1;pwd=23hqvyfe4m;data source=TiendaP.mssql.somee.com;persist security info=False;initial catalog=TiendaP");
        }

    }
}
