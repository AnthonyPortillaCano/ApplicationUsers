using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infraestructure.Data.Context;

namespace CleanArchitecture.Application.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BDCompanyContext _context;
        protected readonly string _connectionString;

        public UnitOfWork(BDCompanyContext context, string connectionString)
        {
            _context = context;
            userServices = new UserServices(context);
            _connectionString = connectionString;
        }
        public IUserServices userServices { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
