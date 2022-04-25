using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    class Student: Person 
    {
        protected string group;
        protected List<Task> tasks = new List<Task>();

        public string Group { get => group; }

        public Student(string name, int age, string group, Task task) : base(name, age)
        {
            this.group = group;
        }

        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.group = group;
            this.tasks = tasks;
        }

        public void AddTask(string taskName, TaskStatus taskStatus)
        {
            tasks.Add(new Task(taskName, taskStatus));
        }

        public void RenderTasks(string prefix = "\t")
        {
            Console.WriteLine("Tasks:");

            for (var i = 0; i < tasks.Count; i++)
                Console.WriteLine($"{prefix}{i + 1}. Task {tasks[i].Name} [{tasks[i].Status}]");
        }

        public void RemoveTask(int index) => tasks.RemoveAt(index);

        public void UpdateTask(int index, TaskStatus taskStatus) => tasks[index].Status = taskStatus;

        public bool Equals(Student other = null)
        {
            if (other == null) return false;

            if (name == other.name && age == other.age)
                return true;
            else
                return false;
        }
    }
}
