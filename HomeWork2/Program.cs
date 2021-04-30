/******************************************
 * 
 * CSHP 320 A
 * Assignment 2
 * Colin Waldner
 * April 30, 2021
 * 
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            Console.WriteLine("--Password Equals \"Hello\"");
            foreach (Models.User user in users.Where(user => user.Password.Equals("hello")).ToList())
            {
                Console.WriteLine($"Name: {user.Name}\tPassword: {user.Password}");
            }
            Console.WriteLine();

            users.RemoveAll(user => user.Name.ToLower().Equals(user.Password));
            users.Remove(users.First(user => user.Password.Equals("hello")));

            Console.WriteLine("--Remaining Users");
            foreach (Models.User user in users)
            {
                Console.WriteLine($"Name: {user.Name}\tPassword: {user.Password}");
            }

            Console.ReadLine();
        }
    }
}
