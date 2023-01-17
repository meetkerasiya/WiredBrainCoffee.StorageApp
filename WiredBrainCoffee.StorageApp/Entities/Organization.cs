namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Organization : EntityBase
    {
        //public int id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
