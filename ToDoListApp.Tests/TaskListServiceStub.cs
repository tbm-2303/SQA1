using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaskListServiceStub : ITaskListService
{
    private List<Task> _stubTasks = new List<Task>
    {
        new Task("Stub Task 1" , "Stub Desription 1",DateTime.Now.AddDays(2)),
        new Task ("Stub Task 2", "Stub Description 2", DateTime.Now.AddDays(2))
    };

    public void AddTaskToList(string listTitle, Task task) { }

    public List<Task> GetTasksFromList(string listTitle)
    {
        return _stubTasks;
    }
}