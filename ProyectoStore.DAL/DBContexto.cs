﻿using System;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=JOSEPH;Initial Catalog=TIENDA;Integrated Security=True");
        }

    }
}