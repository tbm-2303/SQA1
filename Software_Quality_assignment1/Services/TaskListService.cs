using System.Collections.Generic;
using System.Linq;

public class TaskListService : ITaskListService
{
    private Dictionary<string, TaskList> _taskLists;

    public TaskListService()
    {
        _taskLists = new Dictionary<string, TaskList>();
    }

    public TaskList CreateTaskList(string name)
    {
        var taskList = new TaskList(name);
        _taskLists[name] = taskList;
        return taskList;
    }

    public TaskList GetTaskList(string name)
    {
        _taskLists.TryGetValue(name, out var taskList);
        return taskList;
    }

    public void AddTaskToList(string listName, Task task)
    {
        if (_taskLists.ContainsKey(listName))
        {
            _taskLists[listName].Tasks.Add(task);
        }
    }

    public void RemoveTaskFromList(string listName, string taskTitle)
    {
        if (_taskLists.ContainsKey(listName))
        {
            var task = _taskLists[listName].Tasks.FirstOrDefault(t => t.Title == taskTitle);
            if (task != null)
            {
                _taskLists[listName].Tasks.Remove(task);
            }
        }
    }


    public List<Task> GetTasksFromList(string listTitle)
    {
        if (_taskLists.ContainsKey(listTitle))
        {
            return _taskLists[listTitle].Tasks;
        }
        return new List<Task>(); // Return an empty list if the list does not exist
    }
}