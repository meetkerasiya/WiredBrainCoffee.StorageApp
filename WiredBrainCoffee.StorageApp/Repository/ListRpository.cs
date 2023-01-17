using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repository
{
    public class ListRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _items = new();

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
        public void Add(T item)
        {
            item.Id=_items.Count+1;
            _items.Add(item);
        }
        public void Save()
        {
            //Every thing is already saved in the List<t>
            /*foreach (var item in _items)
            {
                Console.WriteLine(item);
            }*/
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
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
