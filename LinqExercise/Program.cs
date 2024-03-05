using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Select(x => x).ToList().Sum();
            Console.WriteLine(sum);

            //TODO: Print the Average of numbers
            var avg = numbers.Select(x => x).ToList().Average();
            Console.WriteLine(avg);

            //TODO: Order numbers in ascending order and print to the console
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
            //TODO: Order numbers in descending order and print to the console
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
            //TODO: Print to the console only the numbers greater than 6
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Ordered numbers");
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them
            //**foreach loop only!**
            
            //video answer: using the .Take() method return back number of elements specified in take method
            // var firstFour = asc.Take(4);     will return the first four numbers starting in ascending order

            var orderedNumbers = numbers.OrderBy(x => x).ToList();
            //create an index outside foreach loop
            int index = 0;
            foreach (var x in orderedNumbers)
            {   
                if (index == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(x);
                }
                //increment the index inside the foreach loop
                index++;
            }

            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 44;
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            //using both accessing first element of the array and using .StartsWith method to access first element
            employees.Where(x => x.FirstName[0] == 'C' || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine($"Filtered FirstName: {x.FirstName}"));


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            employees.Where(x => x.Age > 26).OrderBy(x => x.Age).OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine($"Age: {x.Age} - FirstName: {x.FirstName}"));

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumYearsExp = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);
            Console.WriteLine($"Total years experience: {sumYearsExp}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var avgEmployeesYears = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience);
            Console.WriteLine($"Employees YOE average {avgEmployeesYears}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            //note that with the entire linq statement we need to add a .ToList() at the end to put it back in a list
            //and IMPORTANT that we need to assign it back to the employees list variable so it stores it back
            employees = employees.Append(new Employee("Mary", "Smith", 45, 10)).ToList();
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.FirstName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {   //Firstname, Lastname, Age, YearExp
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
