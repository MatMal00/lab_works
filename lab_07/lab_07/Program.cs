using System;
using System.Linq;

namespace lab_07
{
    public class Program
    {
        public static void Main()
        {

            string connectionString = @"Data Source=DESKTOP-SO4MQ1P;Initial Catalog=blogdb;Integrated Security=True";

            using (BloggingContext db = new BloggingContext(connectionString))
            {
                Console.WriteLine($"Database ConnectionString: {db.ConnectionString}.");

                //////////////////////////////////////////////////////////////////////////////////////////
                //Console.WriteLine("Inserting data"); // CREATE

                //CREATE Roles
                //db.Add(new Role { Name = "Admin" });
                //db.Add(new Role { Name = "Basic" });

                //CREATE Users
                //db.Add(new User { Nickname = "MaciekAdmin", RoleId = 1 });
                //db.Add(new User { Nickname = "JanekBasic", RoleId = 2 });

                //CREATE Tasks
                //db.Add(new Task { Title = "Pranie", Description = "Zrobić zaległe pranie", UserId = 1 });
                //db.Add(new Task { Title = "Sprzątanie", Description = "Wysprzątać dom", UserId = 2 });
                //db.Add(new Task { Title = "Zadanie domowe", Description = "Odrobić zadanie domowe", UserId = 2 });
                //db.SaveChanges();

                //////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Querying for a User tasks"); // READ

                User JanekBasic = db.Users.Find((long)2);

                db.Tasks.Where<Task>(task => task.UserId == JanekBasic.Id).ToList<Task>();

                foreach (var task in JanekBasic.Tasks)
                    Console.WriteLine(task.Title);

                Console.WriteLine("\n\n");

                //////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Updating role name"); // UPDATE

                foreach (var role in db.Roles)
                     Console.Write(role.Name + "  ");

                db.Roles.Find((long)1).Name = "Super Admin";
                db.SaveChanges();

                Console.WriteLine("\n");
                foreach (var role in db.Roles)
                    Console.Write(role.Name + "  ");

                Console.WriteLine("\n\n");

                //////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Deleting Task \n"); // DELETE
                foreach (var task in db.Tasks)
                    Console.Write(task.Title + " ");

                db.Remove(db.Tasks.Find((long)2));
                db.SaveChanges();

                Console.WriteLine();

                foreach (var task in db.Tasks)
                    Console.Write(task.Title + " ");





            }
        }
    }
}
