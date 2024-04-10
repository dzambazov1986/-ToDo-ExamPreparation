using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        var todoList = new ToDoList();
        string taskTitle = "Test Task";
        DateTime dueDate = DateTime.Now.AddDays(1);

        // Act
        todoList.AddTask(taskTitle, dueDate);

        // Assert
        string result = todoList.DisplayTasks();
        StringAssert.Contains(taskTitle, result);
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    { // Arrange
        var todoList = new ToDoList();
        string taskTitle = "Test Task";
        DateTime dueDate = DateTime.Now.AddDays(1);
        todoList.AddTask(taskTitle, dueDate);

        // Act
        todoList.CompleteTask(taskTitle);

        // Assert
        string result = todoList.DisplayTasks();
        StringAssert.Contains("[✓] " + taskTitle, result);
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        var todoList = new ToDoList();
        string taskTitle = "Nonexistent Task";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => todoList.CompleteTask(taskTitle));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    { // Arrange
        var todoList = new ToDoList();

        // Act
        string result = todoList.DisplayTasks();

        // Assert
        Assert.AreEqual("To-Do List:", result);
    }

        [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        var todoList = new ToDoList();
        string taskTitle1 = "Test Task 1";
        DateTime dueDate1 = DateTime.Now.AddDays(1);
        todoList.AddTask(taskTitle1, dueDate1);

        string taskTitle2 = "Test Task 2";
        DateTime dueDate2 = DateTime.Now.AddDays(2);
        todoList.AddTask(taskTitle2, dueDate2);

        // Act
        string result = todoList.DisplayTasks();

        // Assert
        StringAssert.Contains("[ ] " + taskTitle1 + " - Due: " + dueDate1.ToString("MM/dd/yyyy"), result);
        StringAssert.Contains("[ ] " + taskTitle2 + " - Due: " + dueDate2.ToString("MM/dd/yyyy"), result);
    }
}

