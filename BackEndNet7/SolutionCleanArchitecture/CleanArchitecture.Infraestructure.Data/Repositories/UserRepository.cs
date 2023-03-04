using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class UserRepository : RepositoryEF<Usuario>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
            repositoryEF = new RepositoryEF<Usuario>(context);
        }
        public IRepositoryEF<Usuario> repositoryEF { get; set; }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            Usuario resultado = await repositoryEF.Obtener<Usuario>(a => a.UserName == usuario.UserName && a.Password == usuario.Password);
            return resultado;
        }
        public async Task<List<Usuario>> GetAll()
        {
            return await repositoryEF.GetAll();
        }
        public async Task<Usuario> GetById(int id)
        {
            return await repositoryEF.GetEntityByIdAsync(id);
        }
        public void Insert(Usuario usuario)
        {
            repositoryEF.Insert(usuario);
        }
        public void Update(Usuario usuario)
        {
            repositoryEF.Update(usuario);
        }
        public void Delete(int id)
        {
            Usuario usuario = repositoryEF.GetEntityById(id);
            repositoryEF.Delete(usuario);
        }
    }
}
