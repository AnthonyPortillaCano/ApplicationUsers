using System.Linq.Expressions;

namespace CleanArchitecture.Infraestructure.Data
{
    public interface IRepositoryEF<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetEntityByIdAsync(int id);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Obtener<T>(Expression<Func<T, bool>> condicion) where T : class;
        void Insert(T entity);

        T GetEntityById(int id);


        void UpdateFieldsSave(T entity, params Expression<Func<T, object>>[] includeProperties);


        void DeleteList(List<T> entity);

        Task<List<T>> ObtenerList<T>(Expression<Func<T, bool>> condicion) where T : class;
    }
}
