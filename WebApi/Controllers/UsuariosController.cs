using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(Agregar))]
        public Resultado Agregar([FromBody]Usuarios U_usuario)
        {
            return UsuarioLN.AgregarUsuario(U_usuario);
        }

        [HttpPost]
        [Route(nameof(Modificar))]
        public Resultado Modificar([FromBody]Usuarios U_usuario)
        {
            return UsuarioLN.ModificarUsuario(U_usuario);
        }

        [HttpPost]
        [Route(nameof(Eliminar))]
        public Resultado Eliminar([FromBody]Usuarios U_usuario)
        {
            return UsuarioLN.EliminarUsuario(U_usuario);
        }

        [HttpGet]
        [Route(nameof(Consulta))]
        public IEnumerable<Usuarios> Consulta()
        {
            return UsuarioLN.ConsultarUsuarios();
        }
    }
}