using TesteConfitec.Domain.Entities;
using TesteConfitec.Repositories.Generic;

namespace TesteConfitec.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        Task<ServiceResponse<List<Usuario>>> GetUsuarios();
        Task<ServiceResponse<List<Usuario>>> CreateUsuario(Usuario novoUsuario);
        Task<ServiceResponse<Usuario>> GetUsuarioById(int id);
        Task<ServiceResponse<List<Usuario>>> UpdateUsuario(Usuario editadoUsuario);
        Task<ServiceResponse<List<Usuario>>> DeleteUsuario(int id);
    }
}
