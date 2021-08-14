using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;

namespace SKU.Helper
{
    public static class MySQLConexion
    {

        public static MySqlConnection obtenerConexion()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            return new MySqlConnection(configuration.GetConnectionString("localhost"));
        }
    }
}
