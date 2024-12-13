using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TesteConfitec.Domain.Entities;
using TesteConfitec.Repositories.Interface;

namespace TesteConfitec.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> Getusuarios()
        {
            return Ok(await _usuarioRepository.GetUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Usuario>>> GetusuarioById(int id)
        {
            ServiceResponse<Usuario> serviceResponse = await _usuarioRepository.GetUsuarioById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> Createusuario(Usuario novousuario)
        {

            if (novousuario.DataNascimento > DateTime.Today)
            {
                return BadRequest("Data de nascimento não pode ser maior que a data atual");
            }
            if (!EmailValido(novousuario.Email))
            {
                return BadRequest("Email invalido");
            }
            return Ok(await _usuarioRepository.CreateUsuario(novousuario));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> Updateusuario(Usuario editadousuario)
        {
            if (editadousuario.DataNascimento > DateTime.Today)
            {
                return BadRequest("Data de nascimento não pode ser maior que a data atual");
            }
            if (!EmailValido(editadousuario.Email))
            {
                return BadRequest("Email invalido");
            }

            ServiceResponse<List<Usuario>> serviceResponse = await _usuarioRepository.UpdateUsuario(editadousuario);

            return Ok(serviceResponse);
        }


        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> DeleteUsuario(int id)
        {
            ServiceResponse<List<Usuario>> serviceResponse = await _usuarioRepository.DeleteUsuario(id);

            return Ok(serviceResponse);

        }

        public static bool EmailValido(string email)
        {
            if ((email == null) || (email.Length < 4))
                return false;

            var partes = email.Split('@');
            if (partes.Length < 2) return false;

            var pre = partes[0];

            if (pre.Length == 0) return false;

            var validadorPre = new Regex("^[a-zA-Z0-9_.-/+]+$");

            if (!validadorPre.IsMatch(pre))
                return false;

            var partesDoDominio = partes[1].Split('.');
            if (partesDoDominio.Length < 2) return false;

            var validadorDominio = new Regex("^[a-zA-Z0-9-]+$");
            for (int indice = 0; indice < partesDoDominio.Length; indice++)
            {
                var parteDoDominio = partesDoDominio[indice];

                if (parteDoDominio.Length == 0) return false;

                if (!validadorDominio.IsMatch(parteDoDominio))
                    return false;
            }

            return true;
        }
    }
}
