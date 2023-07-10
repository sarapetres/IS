using Shop.Domain.DomainModels;

namespace Shop.Repository.Interface;

public interface IMovieRepository<T> where T:BaseEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
}