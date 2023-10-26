using APIYouTube.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIYouTube.Controllers
{

    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente() {

            List<Cliente> cls = new List<Cliente>
            {
                new Cliente {
                id = "1",
                correo = "Carmelo@gmail.com",
                edad = "19",
                nombre = "Carmelo Fernandez"
                },
                new Cliente{
                    id = "2",
                correo = "Fransisco@gmail.com",
                edad = "19",
                nombre = "Carmelo Fernandez"
                }
            };

            return cls;
        }

        [HttpGet]
        [Route("clientebyid")]
        public dynamic listarById(string _id)
        {

            // Obtener cliente de la base de datos

            Cliente cls = new Cliente 
            {
                id = _id,
                correo = "Poncho@gmail.com",
                edad = "42",
                nombre = "Pedro Colmenarez"
            };


            return cls;
        }

        [HttpPost]
        [Route("guadar")]
        public dynamic listarCliente(Cliente cliente )
        {
            cliente.id = "3";

            return new
            {
                success = true,
                message = "Cliente Registrado",
                result = cliente
            };
        }


        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente )
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            // Desactivar el cliente en la base de datros

            if (token != "canapes") {
                return new
                {
                    success = true,
                    message = "Cliente Desactivado",
                    result = cliente
                };
            }
            return new
            {
                success = false,
                message = "Token Incorrecto Desactivado",
                result = cliente
            };
        }  




    }
}