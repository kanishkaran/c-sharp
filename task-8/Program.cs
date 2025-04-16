
namespace InMemoryRepo
{

    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly Dictionary<int, T> _store = new();
        private int _currentId = 1;

        public void Add(T item)
        {
            var prop = item.GetType().GetProperty("Id");
            prop?.SetValue(item, _currentId);
            _store[_currentId++] = item;
        }

        public T Get(int id) => _store.TryGetValue(id, out var item) ? item : null;

        public IEnumerable<T> GetAll() => _store.Values;

        public void Update(T item)
        {
            var id = (int)item.GetType().GetProperty("Id")?.GetValue(item);
            if (_store.ContainsKey(id))
                _store[id] = item;
        }

        public void Delete(int id) => _store.Remove(id);
    }


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IRepository<T> where T : class
    {
        void Add(T item);              // Insert
        T Get(int id);                 // Get by Id
        void Update(T item);           // Update existing
        void Delete(int id);           // Delete by Id
        IEnumerable<T> GetAll();       // List all items
    }
    class Program
    {

        static void Main()
        {
            IRepository<Student> studentRepo = new InMemoryRepository<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        studentRepo.Add(new Student { Name = name });
                        Console.WriteLine("Student added.");
                        break;

                    case "2":
                        var students = studentRepo.GetAll();
                        Console.WriteLine("\nAll Students:");
                        foreach (var student in students)
                            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
                        break;

                    case "3":
                        Console.Write("Enter ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            var student = studentRepo.Get(updateId);
                            if (student != null)
                            {
                                Console.Write("Enter new name: ");
                                student.Name = Console.ReadLine();
                                studentRepo.Update(student);
                                Console.WriteLine("Student updated.");
                            }
                            else Console.WriteLine("Student not found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            studentRepo.Delete(deleteId);
                            Console.WriteLine("Student deleted if existed.");
                        }
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

    }

}