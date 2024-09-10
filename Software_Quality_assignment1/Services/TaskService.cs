using System;
using System.Collections.Generic;
using System.Linq;

public class TaskService
{
    private List<Task> _tasks;
    

    public TaskService()
    {
        _tasks = new List<Task>();
    }

    public Task AddTask(string title, string description, DateTime deadline)
    {
        var newTask = new Task(title, description, deadline);
        _tasks.Add(newTask);
        return newTask;
    }

    public Task UpdateTask(string title, string description, DateTime deadline)
    {
        var task = _tasks.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            task.Description = description;
            task.Deadline = deadline;
        }
        return task;
    }

    public bool DeleteTask(string title)
    {
        var task = _tasks.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            _tasks.Remove(task);
            return true;
        }
        return false;
    }

    public Task MarkTaskAsCompleted(string title)
    {
        var task = _tasks.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            task.IsCompleted = true;
        }
        return task;
    }

    public List<Task> GetAllTasks()
    {
        return _tasks;
    }
}