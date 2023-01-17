namespace WiredBrainCoffee.StorageApp.Repository
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
                repository.Save();
            }
        }
    }
}
