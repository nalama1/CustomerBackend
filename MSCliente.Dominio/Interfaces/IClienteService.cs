using MSCliente.Dominio.Models;

namespace MSCliente.Dominio.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> GetClienteByCedula(string cedula);

    }
}
