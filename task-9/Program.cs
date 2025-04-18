using System.Reflection;

// 1. Define Custom Attribute
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute { }

// 2. Classes with Methods Decorated with [Runnable]
public class TaskOne
{
    [Runnable]
    public void Run() => Console.WriteLine("TaskOne.Run executed");
}

public class TaskTwo
{
    [Runnable]
    public void Execute() => Console.WriteLine("TaskTwo.Execute executed");

    public void IgnoreMe() => Console.WriteLine("Not marked with [Runnable]");
}

// 3. Discover and Execute [Runnable] Methods
public class Program
{
    public static void Main()
    {
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var instance = Activator.CreateInstance(type);
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                if (method.GetCustomAttribute(typeof(RunnableAttribute)) != null)
                {
                    Console.WriteLine("Name of the Method Invoked: "+ method.Name);

                    method.Invoke(instance, null);
                }
            }
        }
    }
}
