using NUnit.Framework;
using System;
using System.Linq;
using Moq;

namespace ToDoListApp.Tests
{
    [TestFixture]
    public class TaskServiceTests
    {
        private TaskService _taskService;

        [SetUp]
        public void Setup()
        {
            _taskService = new TaskService();
        }

        [Test]
        public void AddTask_ShouldCreateTask()
        {
            // Arrange
            string taskName = "Buy groceries";
            string description = "Buy milk and bread";
            DateTime deadline = DateTime.Now.AddDays(2);

            // Act
            var task = _taskService.AddTask(taskName, description, deadline);

            // Assert
            Assert.IsNotNull(task);
            Assert.AreEqual(taskName, task.Title);
            Assert.AreEqual(description, task.Description);
            Assert.AreEqual(deadline, task.Deadline);
            Assert.IsFalse(task.IsCompleted);
        }

        [Test]
        public void UpdateTask_ShouldUpdateTaskDetails()
        {
            // Arrange
            var task = _taskService.AddTask("Task 1", "Description", DateTime.Now.AddDays(2));

            // Act
            var updatedTask = _taskService.UpdateTask("Task 1", "Updated Description", DateTime.Now.AddDays(3));

            // Assert
            Assert.IsNotNull(updatedTask);
            Assert.AreEqual("Updated Description", updatedTask.Description);
            Assert.AreEqual(DateTime.Now.AddDays(3).Date, updatedTask.Deadline.Date); // Compare only the date part
        }

        [Test]
        public void DeleteTask_ShouldRemoveTask()
        {
            // Arrange
            _taskService.AddTask("Task 1", "Description", DateTime.Now.AddDays(2));

            // Act
            bool result = _taskService.DeleteTask("Task 1");

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(_taskService.GetAllTasks().FirstOrDefault(t => t.Title == "Task 1"));
        }

        [Test]
        public void MarkTaskAsCompleted_ShouldCompleteTask()
        {
            // Arrange
            var task = _taskService.AddTask("Task 1", "Description", DateTime.Now.AddDays(2));

            // Act
            var completedTask = _taskService.MarkTaskAsCompleted("Task 1");

            // Assert
            Assert.IsNotNull(completedTask);
            Assert.IsTrue(completedTask.IsCompleted);
        }

        [Test]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            _taskService.AddTask("Task 1", "Description 1", DateTime.Now.AddDays(1));
            _taskService.AddTask("Task 2", "Description 2", DateTime.Now.AddDays(2));

            // Act
            var tasks = _taskService.GetAllTasks();

            // Assert
            Assert.AreEqual(2, tasks.Count);
        }


       
    }
}