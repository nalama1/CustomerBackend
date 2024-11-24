using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MSCliente.Dominio.Interfaces;
using MSCliente.Dominio.Models;

namespace MSCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteService clienteService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        [HttpGet("{cedula}")]
        [EnableCors("AccesoClienteLocal")]
        public async Task<ActionResult<Cliente>> GetClienteById(string cedula)  
        {            
            try
            {
                var cliente = await _clienteService.GetClienteByCedula(cedula);

                if (cliente == null)
                {
                    return NotFound($"Cliente con Cédula {cedula} no encontrado.");
                }

                return Ok(cliente);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Error en la solicitud del cliente con Cédula {Cedula}", cedula);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el cliente con Cédula {Cedula}", cedula);
                return StatusCode(500, "Ocurrió un error al procesar su solicitud.");
            }
        }



    }
}
