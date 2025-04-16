# Generic Repository Pattern in C# (Console App)

## 📝 Description
This is a simple console application demonstrating the use of **Generics**, **Interfaces**, and the **Repository Pattern** in C#.  
It performs basic **CRUD operations** (Create, Read, Update, Delete) using an in-memory data store.

## 📦 Features
- Generic `IRepository<T>` interface
- Generic `InMemoryRepository<T>` implementation
- Sample `Student` entity with `Id` and `Name`
- Console-based menu for dynamic CRUD operations

## 🚀 How to Run
1. Open the project in Visual Studio or any C# IDE.
2. Build and run the program.
3. Use the console menu to:
   - Add a new student
   - View all students
   - Update a student's name by ID
   - Delete a student by ID
   - Exit the application

## 🧱 Structure
- **Student.cs**: Entity class.
- **IRepository.cs**: Generic interface.
- **InMemoryRepository.cs**: Generic repository implementation.
- **Program.cs**: Console UI with menu and logic.


## ✅ Sample Run
[Output-File](./output.txt)
