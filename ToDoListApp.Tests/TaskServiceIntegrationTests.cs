using NUnit.Framework;
using System;

namespace ToDoListApp.Tests
{
    [TestFixture]
    public class TaskListServiceTests
    {
        private TaskListService _taskListService;
        private TaskService _taskService;

        [SetUp]
        public void Setup()
        {
            _taskService = new TaskService();
            _taskListService = new TaskListService();
            _taskListService.CreateTaskList("Daily Tasks"); // Create a task list for testing
        }

        [Test]
        public void AddTaskToTaskList_ShouldAddTaskSuccessfully()
        {
            // Arrange
            var task = _taskService.AddTask("Task 1", "Description", DateTime.Now.AddDays(1));
            _taskListService.AddTaskToList("Daily Tasks", task);

            // Act
            var tasks = _taskListService.GetTasksFromList("Daily Tasks");

            // Assert
            Assert.IsTrue(tasks.Any(t => t.Title == "Task 1"));
        }

        [Test]
        public void RemoveTaskFromTaskList_ShouldRemoveTaskSuccessfully()
        {
            // Arrange
            var task = _taskService.AddTask("Task 1", "Description", DateTime.Now.AddDays(1));
            _taskListService.AddTaskToList("Daily Tasks", task);

            // Act
            _taskListService.RemoveTaskFromList("Daily Tasks", "Task 1");
            var tasks = _taskListService.GetTasksFromList("Daily Tasks");

            // Assert
            Assert.IsFalse(tasks.Any(t => t.Title == "Task 1"));
        }



        // specification test
        [Test]
        public void SpecificationTest_AddTaskToTaskList_ShouldMaintainListIntegrity()
        {
            // Arrange
            var taskListTitle = "Work Tasks";
            var task1 = _taskService.AddTask("Task 1", "Description 1", DateTime.Now.AddDays(1));
            var task2 = _taskService.AddTask("Task 2", "Description 2", DateTime.Now.AddDays(2));

            _taskListService.CreateTaskList(taskListTitle);

            // Act
            _taskListService.AddTaskToList(taskListTitle, task1);
            _taskListService.AddTaskToList(taskListTitle, task2);
            var tasksInList = _taskListService.GetTasksFromList(taskListTitle);

            // Assert
            Assert.AreEqual(2, tasksInList.Count);
            Assert.IsTrue(tasksInList.Any(t => t.Title == "Task 1"));
            Assert.IsTrue(tasksInList.Any(t => t.Title == "Task 2"));
        }
    }



}