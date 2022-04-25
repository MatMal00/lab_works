using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("Mati Malec", 21, "B", new Task("Ugotuj zupę", TaskStatus.Progress));

            Console.WriteLine(student);
            student.AddTask("Ugotuj zupę", TaskStatus.Progress);
            student.RenderTasks();
        }
    }
}
