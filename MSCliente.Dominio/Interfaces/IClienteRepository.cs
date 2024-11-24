using MSCliente.Dominio.Models;

namespace MSCliente.Dominio.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteByCedula(string cedula);
    }
}
