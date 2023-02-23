using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Читаємо список спiвробiтникiв з файлу за шляхом ...\bin\Debug\net6.0
        List<Employee> employees = new List<Employee>();
        using (StreamReader sr = new StreamReader("employees.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Employee employee = new Employee { Name = parts[0], Salary = int.Parse(parts[1]) };
                employees.Add(employee);
            }
        }

        // Сортуємо спiвробiтникiв за зарплатою
        List<Employee> sortedEmployees = employees.OrderBy(e => e.Salary).ToList();

        // Виводимо вiдсортований список
        Console.WriteLine("Список спiвробiтникiв, вiдсортований за зарплатою:");
        foreach (Employee employee in sortedEmployees)
        {
            Console.WriteLine("{0}, {1}", employee.Name, employee.Salary);
        }
    }
}