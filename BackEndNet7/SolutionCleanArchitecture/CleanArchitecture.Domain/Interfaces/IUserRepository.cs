using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
        Task<List<Usuario>> GetAll();

        Task<Usuario> GetById(int id);

        void Insert(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(int id);
    }
}
