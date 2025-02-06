// See https://aka.ms/new-console-template for more information


using ReflectionDemo;
using System.Reflection;

// Get type information using reflection
Type type = typeof(Person);

Console.WriteLine($"Class Name: {type.Name}");

// Display properties
Console.WriteLine("Properties:");
foreach (PropertyInfo prop in type.GetProperties())
{
    Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
}

//Display methods
Console.WriteLine("\nMethods:");
foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
{
    Console.WriteLine($"- {method.Name} ({method.ReturnType.Name})");
    method.Invoke(null, new object[] { type });
}

//Dynamically create an instance of Person
object obj = Activator.CreateInstance(type, new object[] { "John Doe", 30 });

// Invoke a method dynamically
MethodInfo greetMethod = type.GetMethod("Greet");
if( greetMethod != null )
{
    string result = (string)greetMethod.Invoke(obj, null);
    Console.WriteLine($"\nDynamically Invoked Method Ouput: {result}");
}