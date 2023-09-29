namespace BookStore.API.Repository.IRepository
{
    public interface ICrudRepository<T>
    {
        Task<IEnumerable<T>> getList();

        Task<T> Get(int id);

        Task Updates(T item);

        Task Deletes(int id);

        Task Inesrt(T item);

    }
}
