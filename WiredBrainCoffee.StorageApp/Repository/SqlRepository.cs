using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repository
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbcontext;
        private readonly DbSet<T> _dbSet;
        public SqlRepository(DbContext dbContext)
        {
            _dbcontext = dbContext;
            _dbSet = _dbcontext.Set<T>();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item=>item.Id).ToList();
        }
    }
    /*
    //example for subclass using generic
    public class GenericRepositoryWithRemove<T,TKey> : GenericRepository<T,TKey>
    {
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
    */
}
