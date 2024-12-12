
using TesteConfitec.Data.Context;
using TesteConfitec.Domain.Entities;
using TesteConfitec.Repositories.Generic;
using TesteConfitec.Repositories.Interface;

namespace TesteConfitec.Repositories.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TesteConfitecContext context) : base(context)
        {
        }
    }
}
