using System;
using System.Collections.Generic;

namespace Yeild
{
    class Program
    {
        static void Main(string[] args)
        {
            ManUsers();
            Console.WriteLine("Hello World!");
        }
        public static void ManUsers()
        {
            var users = GetUsers(10000);
            foreach (var user in users)
            {
                if (user.Id > 10000)
                {
                    break;
                }
                Console.WriteLine($"ID: {user.Id},Name: {user.Name}");
            }
        }
        public static IEnumerable<User> GetUsers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new User()
                {
                    Id=i,
                    Name=$"Name {i}"
                };
            }
        }
    }
}
