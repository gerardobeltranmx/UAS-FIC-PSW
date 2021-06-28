using System;
using Microsoft.EntityFrameworkCore;
using Proy_05.Models;

namespace Proy_05.Helpers
{
    public class Datos : DbContext
    {
        // Tabla Clientes 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Conexion = @"Server = dbservidor.database.windows.net;
                                Database = acmedb;
                                User = userdb;
                                Password = 12AB34cd*;";
            optionsBuilder.UseSqlServer(Conexion);

        }
    }
}
