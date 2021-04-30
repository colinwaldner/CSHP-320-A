using System;
using System.Collections.Generic;
using System.Linq;

namespace Session3Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var autos = new List<Auto>();

            autos.Add(new Auto { Name = "SUV", MaxSpeed = 101, Price = 2000 });
            autos.Add(new Auto { Name = "Sedan", MaxSpeed = 120, Price = 1000 });
            autos.Add(new Auto { Name = "Coupe", MaxSpeed = 110, Price = 3000 });

            // TBD: Find the lowest price auto
            var auto = autos.OrderBy(a => a.Price).First();

            Console.WriteLine("Lowest Price: Name={0} Price={1}", auto.Name, auto.Price);

            // TBD: Find the fastest auto
            auto = autos.OrderBy(a => a.MaxSpeed).Last();

            Console.WriteLine("Fastest Speed: Name={0} Speed={1}", auto.Name, auto.MaxSpeed);

            Console.ReadLine();


            //MyStack<int> stack = new MyStack<int>();

            //stack.Push(1);
            //stack.Push(2);

            //while (!stack.IsEmpty)
            //{
            //    int number = stack.Pop();
            //    Console.WriteLine("Last value popped = {0}", number);
            //}

            //Console.ReadLine();
        }
    }
    public class MyStack<T>
    {
        T[] stack;
        int sp;

        public void Push(T item)
        {
            stack[sp++] = item;
        }
        public T Pop()
        {
            return stack[--sp];
        }
        public bool IsEmpty 
        { 
            get
            {
                return sp == 0;
            }
        }
    }
    class Auto
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Price { get; set; }

    }
}
