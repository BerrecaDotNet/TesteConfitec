
using Microsoft.EntityFrameworkCore;
using TesteConfitec.Data.Context;
using TesteConfitec.Domain.Entities;
using TesteConfitec.Repositories.Generic;
using TesteConfitec.Repositories.Interface;

namespace TesteConfitec.Repositories.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TesteConfitecContext _context;
        public UsuarioRepository(TesteConfitecContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Usuario>>> CreateUsuario(Usuario novoUsuario)
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {
                if (novoUsuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Usuario>>> DeleteUsuario(int id)
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {
                Usuario Usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);

                if (Usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Usuarios.Remove(Usuario);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Usuarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Usuario>> GetUsuarioById(int id)
        {
            ServiceResponse<Usuario> serviceResponse = new ServiceResponse<Usuario>();

            try
            {
                Usuario Usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);

                if (Usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = Usuario;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Usuario>>> GetUsuarios()
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {

                serviceResponse.Dados = _context.Usuarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        

        public async Task<ServiceResponse<List<Usuario>>> UpdateUsuario(Usuario editadoUsuario)
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {
                Usuario Usuario = _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.UsuarioId == editadoUsuario.UsuarioId);

                if (Usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }


             

                _context.Usuarios.Update(editadoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
