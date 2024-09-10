using System.Collections.Generic;

public class TaskList
{
    public string Name { get; set; }
    public List<Task> Tasks { get; set; }

    public TaskList(string name)
    {
        Name = name;
        Tasks = new List<Task>();
    }
}