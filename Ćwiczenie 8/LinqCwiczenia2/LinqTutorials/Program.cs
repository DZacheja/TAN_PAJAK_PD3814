using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = LinqTasks.Task1();
            var t2 = LinqTasks.Task2();
            var t3 = LinqTasks.Task3();
            var t4 = LinqTasks.Task4();
            var t5 = LinqTasks.Task5();
            var t6 = LinqTasks.Task6();
            var t7 = LinqTasks.Task7();
            var t8 = LinqTasks.Task8();
            var t9 = LinqTasks.Task9();
            var t10 = LinqTasks.Task10();

            var t11 = LinqTasks.Task11();
            var t12 = LinqTasks.Task12();
            var t13 = LinqTasks.Task13(new []{ 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1});
            var t14 = LinqTasks.Task14();

            Console.WriteLine("@@@@@@@@@@@@@@@@@@  Task1 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task2 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t2);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task3 @@@@@@@@@@@@@@@@@@ \n");
            Console.WriteLine(t3 + "\n");

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task4 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t4);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task5 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t5);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task6 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t6);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task7 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t7);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task8 @@@@@@@@@@@@@@@@@@ \n");
            Console.WriteLine(t8 + "\n");

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task9 @@@@@@@@@@@@@@@@@@ \n");
            Console.WriteLine(t9 + "\n");

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task10 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t10);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task11 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t11);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task12 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t12);

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task13 @@@@@@@@@@@@@@@@@@ \n");
            Console.WriteLine(t13 + "\n");

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@  Task14 @@@@@@@@@@@@@@@@@@ \n");
            printCollecion(t14);
        }

        private static void printCollecion<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                 Console.WriteLine("null results yet.\n");
                return;
            }

            Console.WriteLine("\n[");
            foreach (var item in collection)
            {
                Console.WriteLine("\n{");
                var properties = item.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    Console.WriteLine(prop.Name + " = " + prop.GetValue(item));
                }
                Console.WriteLine("}");
            }
            Console.WriteLine("\n]");
        }
    }

}
