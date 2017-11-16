using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SecureServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding enc8 = Encoding.Unicode;
            var server = new Server();
            server.StartHost();
            Console.WriteLine("Приложение готово к приему сообщений.");
            var db = new securityEntities();

            var alex = new users()
            {
                    id=1,
                    login="alex1",              
                    password_hash=enc8.GetString(server.ComputeHash("alex1")),
                    salt="salt",
            };
           
            //db.users.Add(alex);
            db.SaveChanges();
            var context = new securityEntities();

            foreach (var person in context.users)
            {
                Console.WriteLine("{0}:login {1} hash {2}", person.id, person.login, person.password_hash);
            }
            Console.ReadKey();
            server.StopHost();
        }
    }
}
