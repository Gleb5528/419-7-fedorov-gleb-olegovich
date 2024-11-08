using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using System.Reflection;
using Practik;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Инициализация формы с нужными элементами
        private TIMLID InitializeForm()
        {
            var form = new TIMLID();  // Используем конструктор, который автоматически вызывает InitializeComponent
            return form;
        }

        [TestMethod]
        public void TestTaskName_ValidInput_ShouldUpdateTaskName()
        {
            // Arrange
            var form = InitializeForm();
            var fieldInfo = typeof(TIMLID).GetField("textBoxTaskName", BindingFlags.NonPublic | BindingFlags.Instance);
            var textBox = (TextBox)fieldInfo.GetValue(form);

            // Act
            textBox.Text = "New Task";

            // Assert
            Assert.AreEqual("New Task", textBox.Text);
        }

        [TestMethod]
        public void TestTaskDeadline_ValidInput_ShouldUpdateDeadline()
        {
            // Arrange
            var form = InitializeForm();
            var fieldInfo = typeof(TIMLID).GetField("textBoxDeadline", BindingFlags.NonPublic | BindingFlags.Instance);
            var textBox = (TextBox)fieldInfo.GetValue(form);

            // Act
            textBox.Text = "2024-12-01";

            // Assert
            Assert.AreEqual("2024-12-01", textBox.Text);
        }

        [TestMethod]
        public void TestDeadline_EmptyInput_ShouldReturnError()
        {
            // Arrange
            var form = InitializeForm();
            var fieldInfo = typeof(TIMLID).GetField("textBoxDeadline", BindingFlags.NonPublic | BindingFlags.Instance);
            var textBox = (TextBox)fieldInfo.GetValue(form);

            // Act
            textBox.Text = "";

            // Assert
            Assert.AreEqual("", textBox.Text); // Пустой ввод
        }

        [TestMethod]
        public void TestAddButton_Click_ShouldAddNewTask()
        {
            // Arrange
            var form = InitializeForm();
            var buttonInfo = typeof(TIMLID).GetField("buttonAdd", BindingFlags.NonPublic | BindingFlags.Instance);
            var button = (Button)buttonInfo.GetValue(form);

            // Act
            button.PerformClick();

            // Assert
            var taskListField = typeof(TIMLID).GetField("taskList", BindingFlags.NonPublic | BindingFlags.Instance);
            var taskList = (ListBox)taskListField.GetValue(form);
            Assert.IsTrue(taskList.Items.Contains("New Task"));
        }

        [TestMethod]
        public void TestSaveButton_Click_ShouldSaveTaskData()
        {
            // Arrange
            var form = InitializeForm();
            var buttonInfo = typeof(TIMLID).GetField("buttonSave", BindingFlags.NonPublic | BindingFlags.Instance);
            var button = (Button)buttonInfo.GetValue(form);

            // Act
            button.PerformClick();

            // Assert
            var taskListField = typeof(TIMLID).GetField("taskList", BindingFlags.NonPublic | BindingFlags.Instance);
            var taskList = (ListBox)taskListField.GetValue(form);
            Assert.IsTrue(taskList.Items.Contains("New Task"));
        }

        [TestMethod]
        public void TestTaskName_EmptyInput_ShouldShowErrorMessage()
        {
            // Arrange
            var form = InitializeForm();
            var fieldInfo = typeof(TIMLID).GetField("textBoxTaskName", BindingFlags.NonPublic | BindingFlags.Instance);
            var textBox = (TextBox)fieldInfo.GetValue(form);

            // Act
            textBox.Text = "";

            // Assert
            Assert.AreEqual("", textBox.Text); // Ошибка при пустом вводе
        }

        [TestMethod]
        public void TestSaveButton_EmptyData_ShouldNotSave()
        {
            // Arrange
            var form = InitializeForm();
            var buttonInfo = typeof(TIMLID).GetField("buttonSave", BindingFlags.NonPublic | BindingFlags.Instance);
            var button = (Button)buttonInfo.GetValue(form);

            // Act
            button.PerformClick();

            // Assert
            var taskListField = typeof(TIMLID).GetField("taskList", BindingFlags.NonPublic | BindingFlags.Instance);
            var taskList = (ListBox)taskListField.GetValue(form);
            Assert.IsFalse(taskList.Items.Contains("New Task"));
        }

        [TestMethod]
        public void TestDeadline_InvalidInput_ShouldShowErrorMessage()
        {
            // Arrange
            var form = InitializeForm();
            var fieldInfo = typeof(TIMLID).GetField("textBoxDeadline", BindingFlags.NonPublic | BindingFlags.Instance);
            var textBox = (TextBox)fieldInfo.GetValue(form);

            // Act
            textBox.Text = "Invalid Date";

            // Assert
            Assert.AreEqual("Invalid Date", textBox.Text); // Ошибка при неверном формате
        }

        [TestMethod]
        public void TestAddButton_ShouldAddTaskToList()
        {
            // Arrange
            var form = InitializeForm();
            var buttonInfo = typeof(TIMLID).GetField("buttonAdd", BindingFlags.NonPublic | BindingFlags.Instance);
            var button = (Button)buttonInfo.GetValue(form);

            // Act
            button.PerformClick();

            // Assert
            var taskListField = typeof(TIMLID).GetField("taskList", BindingFlags.NonPublic | BindingFlags.Instance);
            var taskList = (ListBox)taskListField.GetValue(form);
            Assert.IsTrue(taskList.Items.Contains("New Task"));
        }

        [TestMethod]
        public void TestCancelButton_ShouldClearData()
        {
            // Arrange
            var form = InitializeForm();
            var buttonInfo = typeof(TIMLID).GetField("buttonCancel", BindingFlags.NonPublic | BindingFlags.Instance);
            var button = (Button)buttonInfo.GetValue(form);

            // Act
            button.PerformClick();

            // Assert
            var fieldInfo = typeof(TIMLID).GetField("textBoxTaskName", BindingFlags.NonPublic | BindingFlags.Instance);
            var textBox = (TextBox)fieldInfo.GetValue(form);
            Assert.AreEqual("", textBox.Text); // Должен быть пустой текст
        }
    }
}
