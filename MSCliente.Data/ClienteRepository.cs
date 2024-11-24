using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MSCliente.Dominio.Interfaces;
using MSCliente.Dominio.Models;
using System.Data;

namespace MSCliente.Data
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly string _connectionString;

        public ClienteRepository(IConfiguration configuration, ILogger<ClienteRepository> logger)
        {
            ILogger<ClienteRepository> _logger = logger;
            _connectionString = configuration.GetConnectionString("ClienteDBConnection");

            if (string.IsNullOrEmpty(_connectionString))
            {
                _logger.LogError("La cadena de conexión 'ClienteDBConnection' no está configurada.");
                throw new InvalidOperationException("Cadena de conexión no configurada.");
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public async Task<Cliente> GetClienteByCedula(string cedula)
        {            
            using var con = Connection;
            const string query = "select Cedula, Nombre, Apellido from Cliente where Cedula = @Cedula ";            
            return await con.QueryFirstOrDefaultAsync<Cliente>(query, new { Cedula = cedula });
        }
    }
}
