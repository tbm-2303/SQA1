public interface ITaskListService
{
    void AddTaskToList(string listTitle, Task task);
    List<Task> GetTasksFromList(string listTitle);
}