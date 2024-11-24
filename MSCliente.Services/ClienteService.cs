using MSCliente.Dominio.Interfaces;
using MSCliente.Dominio.Models;

namespace MSCliente.Services
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<Cliente> GetClienteByCedula(string cedula)
        {
            return await _clienteRepository.GetClienteByCedula(cedula);
        }

    }   
}
