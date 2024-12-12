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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Usuario usuario)
        {
            if(usuario == null)
            {
                return BadRequest($"`{usuario} não pode ser nulo");
            }
            if(usuario.DataNascimento > DateTime.Today)
            {
                return BadRequest("Data de nascimento não pode ser maior que a data atual");
            }
            if (!EmailValido(usuario.Email))
            {
                return BadRequest("Email invalido");
            }

            await _usuarioRepository.Insert(usuario);
            return Ok("Usuario registrado com sucesso!");
        }

        [HttpGet("AllUsers")]
        public async Task<IActionResult> TodosUsuarios()
        {
            var result = await _usuarioRepository.GetAll();
            return Ok(result.ToList());
           
        }

        [HttpGet("UserById/{Id}")]
        public async Task<IActionResult> UsuarioPorId(int Id)
        {
            var result = await _usuarioRepository.GetById(Id);
            if (result == null)
            {
                return NotFound($"ID {Id}, não encontrado.");
            }
            return Ok(result);

        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _usuarioRepository.GetById(Id);
            if (result == null)
            {
                return NotFound($"ID {Id}, não encontrado.");
            }
            await _usuarioRepository.Delete(Id);
            return Ok($"ID {Id}, Deletado com sucesso!");
        }

        [HttpPut("Update/{Id}")] 
        public async Task<IActionResult> Update(int Id, Usuario usuario)
        {
            if (Id != usuario.UsuarioId)
            {
                return BadRequest($"ID { Id}, não encontrado.");
            }
            if (usuario.DataNascimento > DateTime.Today)
            {
                return BadRequest("Data de nascimento não pode ser maior que a data atual");
            }
            if (!EmailValido(usuario.Email))
            {
                return BadRequest("Email invalido");
            }

            try
            {
                await _usuarioRepository.Update(Id, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok("Usuario atualizado com sucesso!");
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
