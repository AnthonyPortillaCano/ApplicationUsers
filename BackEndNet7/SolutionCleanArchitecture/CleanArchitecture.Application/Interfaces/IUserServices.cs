using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserServices
    {
        Task<Usuario> ValidateUser(Usuario usuario);
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        void Insert(Usuario user);
        void Update(Usuario user);
        void Delete(int id);
    }
}
