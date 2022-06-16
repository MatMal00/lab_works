using System;
using System.Linq;
using System.Threading.Tasks;

namespace lab_07
{
    public class Program
    {
        static readonly string connectionString = @"Data Source=DESKTOP-SO4MQ1P;Initial Catalog=blogdb;Integrated Security=True";

        public static void Main()
        {
            //CREATE Roles
            CreateRole("Admin").Wait();
            CreateRole("Basic").Wait();
            Console.WriteLine("Roles created\n");

            //CREATE Users
            CreateUser("MaciekAdmin", "Admin").Wait();
            CreateUser("JanekBasic", "Basic").Wait();
            Console.WriteLine("Users created\n");

            //CREATE Tasks
            CreateTask("JanekBasic", "Pranie", "Zrobić zaległe pranie").Wait();
            CreateTask("JanekBasic", "Sprzątanie", "Wysprzątać dom").Wait();
            CreateTask("MaciekAdmin", "Zadanie domowe", "Odrobić zadanie domowe").Wait();
            Console.WriteLine("Tasks created\n");

            //READ USER TASKS
            Console.WriteLine("JanekBasic tasks:");
            ReadTasks("JanekBasic").Wait();
            Console.WriteLine("\n");

            //UPDATE ROLENAME
            UpdateRolename("Admin", "Super Admin").Wait();
            Console.WriteLine("Role updated\n");

            //DELETE TASK   
            ReadTasks().Wait();
            Console.WriteLine("\n");
            DeleteTask("Zadanie domowe").Wait();

            ReadTasks().Wait();
            Console.WriteLine("\n\n");
        }

        public static async Task CreateRole(string roleName)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                db.Add(new Role { Name = roleName });
                await db.SaveChangesAsync();
            }
        }

        public static async Task CreateUser(string userName, string roleName)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var roleId = db.Roles.Where(r => r.Name == roleName).Single().Id;

                db.Add(new User { Nickname = userName, RoleId = roleId });
                await db.SaveChangesAsync();
            }
        }

        public static async Task CreateTask(string authorNickname, string taskTitle, string taskDescription)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var userId = db.Users.Where(u => u.Nickname == authorNickname).Single().Id;

                db.Add(new TaskToDo { Title = taskTitle, Description = taskDescription, UserId = userId });
                await db.SaveChangesAsync();
            }
        }

        public static async Task ReadTasks(string authorNickname = null)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                if (authorNickname != null)
                {
                    var user = db.Users.Where(u => u.Nickname == authorNickname).Single();

                    await Task.Run(() => db.Tasks.Where<TaskToDo>(task => task.UserId == user.Id).ToList<TaskToDo>());

                    foreach (var task in user.Tasks)
                        Console.Write(task.Title + " ");
                }
                else
                {
                    foreach (var task in db.Tasks)
                        Console.Write(task.Title + " ");
                }
            }
        }

        public static async Task UpdateRolename(string prevRoleName, string newRoleName)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var roleId = db.Roles.Where(r => r.Name == prevRoleName).Single().Id;

                db.Roles.Find(roleId).Name = newRoleName;
                await db.SaveChangesAsync();
            }
        }

        public static async Task DeleteTask(string taskTitle)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var taskId = db.Tasks.Where(t => t.Title == taskTitle).Single().Id;

                db.Remove(db.Tasks.Find(taskId));
                await db.SaveChangesAsync();
            }
        }
    }
}