using System;
using Microsoft.EntityFrameworkCore;
using Proy_Consola_02.Models;

namespace Proy_Consola_02.Db
{
    public class Datos : DbContext
    {
        // Tabla Clientes 
        public DbSet<Cliente> Clientes { get; set; }

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
