using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Services
{
    public class UserServices: IUserServices
    {
        protected IUserRepository _userRepository;
        public UserServices(DbContext context)
        {
            _userRepository = new UserRepository(context);
        }
        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _userRepository.ValidateUser(usuario);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        public async Task<Usuario> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public void Insert(Usuario user)
        {
            _userRepository.Insert(user);
        }
        public void Update(Usuario user)
        {
            _userRepository.Update(user);
        }
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
