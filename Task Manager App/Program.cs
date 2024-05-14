using System;
using System.Collections.Generic;
using System.Linq;

class TaskManager { 
    class Task
    {
        public string Name { get; set; } //get and set name variables ho initiate garnalai
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string name, string description, DateTime dueDate) //parameters
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }
 
    List<Task> tasks = new List<Task>(); //array jastai

    void AddTask()
    {
        Console.WriteLine("Enter task name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter task description:");
        string description = Console.ReadLine();

        DateTime dueDate;
        do
        {
            Console.WriteLine("Enter due date:");
        } while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dueDate) || dueDate < DateTime.Now);

        tasks.Add(new Task(name, description, dueDate));
        Console.WriteLine("Task added. ");
    }
    void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        Console.WriteLine("All Tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Due Date: {task.DueDate.ToString("MM/dd/yyyy")}, Completed: {(task.IsCompleted ? "Yes" : "No")}");
        }
    }
    void MarkTaskAsCompleted()
    {
        Console.WriteLine("Enter the name of the task to mark as completed:");
        string name = Console.ReadLine();

        Task task = tasks.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (task != null)
        {
            task.IsCompleted = true;
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
    void ViewCompletedTasks()
    {
        var completedTasks = tasks.Where(t => t.IsCompleted);
        if (completedTasks.Count() == 0)
        {
            Console.WriteLine("No completed tasks found.");
            return;
        }

        Console.WriteLine("Completed Tasks:");
        foreach (var task in completedTasks)
        {
            Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Due Date: {task.DueDate.ToString("MM/dd/yyyy")}");
        }
    }

    void DeleteTask()
    {
        Console.WriteLine("Enter the name of the task to delete:");
        string name = Console.ReadLine();

        Task task = tasks.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Task deleted successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\nTask Manager Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. View Completed Tasks");
            Console.WriteLine("5. Delete Task");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) //String to int32
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    taskManager.AddTask();
                    break;
                case 2:
                    taskManager.ViewTasks();
                    break;
                case 3:
                    taskManager.MarkTaskAsCompleted();
                    break;
                case 4:
                    taskManager.ViewCompletedTasks();
                    break;
                case 5:
                    taskManager.DeleteTask();
                    break;
                case 6:
                    Console.WriteLine("Exited");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
