using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace YourNamespace
{
    [TestClass]
    public class BlackboardTests
    {
        [TestMethod]
        public void GetData_ExistingKey_ReturnsData()
        {
            // Arrange
            var blackboard = new Blackboard();
            blackboard.SetData("DataA", 10);

            // Act
            int data = blackboard.GetData("DataA");

            // Assert
            Assert.AreEqual(10, data);
        }

        [TestMethod]
        public void GetData_NonExistingKey_ReturnsDefault()
        {
            // Arrange
            var blackboard = new Blackboard();

            // Act
            int data = blackboard.GetData("NonExistingKey");

            // Assert
            Assert.AreEqual(default(int), data);
        }

        [TestMethod]
        public void SetData_SetsData()
        {
            // Arrange
            var blackboard = new Blackboard();

            // Act
            blackboard.SetData("DataA", 10);

            // Assert
            int data = blackboard.GetData("DataA");
            Assert.AreEqual(10, data);
        }

        [TestMethod]
        public void KnowledgeComponentA_Update_CalculatesResult()
        {
            // Arrange
            var blackboard = new Blackboard();
            blackboard.SetData("DataA", 10);

            var componentA = new KnowledgeComponentA();

            // Act
            componentA.Update(blackboard);

            // Assert
            int result = blackboard.GetData("Result");
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void KnowledgeComponentB_Update_CalculatesResult()
        {
            // Arrange
            var blackboard = new Blackboard();
            blackboard.SetData("DataB", 7);

            var componentB = new KnowledgeComponentB();

            // Act
            componentB.Update(blackboard);

            // Assert
            int result = blackboard.GetData("Result");
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void KnowledgeComponentC_Update_DisplaysResult()
        {
            // Arrange
            var blackboard = new Blackboard();
            blackboard.SetData("Result", 42);

            var consoleMock = new Mock<IConsole>();
            consoleMock.Setup(c => c.WriteLine("Final Result: 42"));

            var componentC = new KnowledgeComponentC(consoleMock.Object);

            // Act
            componentC.Update(blackboard);

            // Assert
            consoleMock.Verify(c => c.WriteLine("Final Result: 42"), Times.Once);
        }
    }
}