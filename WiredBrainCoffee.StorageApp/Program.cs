using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repository;

class Program
{
    static void Main(string[] args)
    {
        var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
        AddEmployees(employeeRepository);
        AddManager(employeeRepository);
        GetEmployeeById(employeeRepository);
        WriteAllToConsole(employeeRepository);

        var organizationRepository = new ListRepository<Organization>();
        AddOrganization(organizationRepository);
        WriteAllToConsole(organizationRepository);

    }

    private static void AddManager(IWriteRepository<Manager> ManagerRepository)
    {
        ManagerRepository.Add(new Manager { FirstName = "Kamal" });
        ManagerRepository.Add(new Manager { FirstName = "Shruti" });
        ManagerRepository.Save();
    }

    private static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
       var items=repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private static void GetEmployeeById(IReadRepository<Employee> employeeRepository)
    {
        var employee = employeeRepository.GetById(1);
        Console.WriteLine("Employee with id 1 is: " + employee);
    }
  
    private static void AddEmployees(IRepository<Employee> employeeRepository)
    {
        var employees = new[]
        {
            new Employee { FirstName = "Meet" },
            new Employee { FirstName = "Mitesh" },
            new Employee { FirstName = "bhayo" }

        };
        AddBatch(employeeRepository, employees);
       /* Employee meet = new Employee { FirstName = "Meet" };
        employeeRepository.Add(meet);
        employeeRepository.Add(new Employee { FirstName = "Mitesh" });
        employeeRepository.Add(new Employee { FirstName = "bhayo" });
        //employeeRepository.Remove(meet);
        employeeRepository.Save();*/
        
    }
    private static void AddOrganization(IRepository<Organization> organizationRepository)
    {
        var organizations = new[]
        {
            new Organization{Name="Tata"},
            new Organization{Name="Birla"}
        };
        AddBatch(organizationRepository, organizations);
        /*Organization organization = new Organization { Name = "Kanet" };
       organizationRepository.Add(organization);
        organizationRepository.Add(new Organization { Name = "Jay" });
        organizationRepository.Add(new Organization { Name = "Krupal" });*/

        //organizationRepository.Remove(organization);
       // organizationRepository.Save();
    }

    private static void AddBatch<T>(IWriteRepository<T> repository, T[] items)
    {
        foreach (var item in items)
        {
            repository.Add(item);
            repository.Save();
        }
    }
}