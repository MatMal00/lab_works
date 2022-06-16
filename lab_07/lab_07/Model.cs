using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab_07
{

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskToDo> Tasks { get; set; }
        public DbSet<Role> Roles { get; set; }



        public string ConnectionString { get; }

        public BloggingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }

    public class Blog
    {
        public long Id { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new();
    }

    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public long BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class User
    {
        public long Id { get; set; }    
        public string Nickname { get; set; }
        public long RoleId { get; set; }
        public List<TaskToDo> Tasks { get; } = new();
    }

    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class TaskToDo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
    }
}
