using System;
using System.Reflection;

namespace GCHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.С помощью рефлексии получить список методов класса Console и вывести на экран.
            Type tp = typeof(Console); 
                        
            MethodInfo[] methods = tp.GetMethods();

            int i = 0;
            foreach (MethodInfo mi in methods)
            {     
                i++;           
                Console.WriteLine($"Method[{i}] = {mi.Name}" );
                
            }
            Console.WriteLine();
            Console.WriteLine();
            // 2.Описать класс с несколькими свойствами. 
            // Создать экземпляр класса и инициализировать его свойства.
            // С помощью рефлексии получить свойства и их значения из созданного экземпляра класса. 
            // Вывести полученные значения на экран

            var testRefl = new TestRefl { Id = 1, Name = "Money", UniqeuProp = "Big" };

            PropertyInfo[] propsOfTest = testRefl.GetType().GetProperties();

            int j = 0;
            foreach (PropertyInfo mi in propsOfTest)
            { 
                j++;
                Console.WriteLine($"Property[{j}] = {mi.Name}");
               
            }
            foreach (var prop in propsOfTest)
                if (prop.GetIndexParameters().Length == 0)
                    Console.WriteLine($"{prop.Name} ({prop.PropertyType.Name}): {prop.GetValue(testRefl, null)}");
        }
    }
}
