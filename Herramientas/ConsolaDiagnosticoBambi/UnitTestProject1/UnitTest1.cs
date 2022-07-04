using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registrador_FFT;

namespace ChartTest
{
    [TestClass]
    public class FrmMain_Test
    {
        [TestMethod]
        public void Form1_SplitArray_Ok1()
        {
            //Arrange
            byte[] rawArray = { 255, 1, 2, 3, 255, 55, 56, 57, 255, 20, 17, 255, 18, 21 };

            Queue<byte[]> expectedQueue = new Queue<byte[]>();
            expectedQueue.Enqueue(new byte[] { 1, 2, 3 });
            expectedQueue.Enqueue(new byte[] { 55, 56, 57 });
            expectedQueue.Enqueue(new byte[] { 20, 17 });

            byte[] expectedReminder = new byte[] { 255, 18, 21};

            //Act
            Queue<byte[]> actualQueue = new Queue<byte[]>();
            byte[] actualReminder = FrmMain.SplitArrayAndEnqueue(rawArray, (byte)255, ref actualQueue);

            //Assert
            bool reminderAreEquals = Utils.AreEquals(expectedReminder, actualReminder);
            bool queueAreEquals = Utils.AreEquals(expectedQueue, actualQueue);
            Assert.IsTrue(reminderAreEquals && queueAreEquals);
        }

        [TestMethod]
        public void Form1_SplitArray_WithSeparatorAtTheEnd_Ok()
        {
            //Arrange
            byte[] rawArray = { 255, 1, 2, 3, 255, 55, 56, 57, 255, 20, 17, 255, 18, 21, 255 };

            Queue<byte[]> expectedQueue = new Queue<byte[]>();
            expectedQueue.Enqueue(new byte[] { 1, 2, 3 });
            expectedQueue.Enqueue(new byte[] { 55, 56, 57 });
            expectedQueue.Enqueue(new byte[] { 20, 17 });
            expectedQueue.Enqueue(new byte[] { 18, 21 });

            byte[] expectedReminder = new byte[] { 255 };

            //Act
            Queue<byte[]> actualQueue = new Queue<byte[]>();
            byte[] actualReminder = FrmMain.SplitArrayAndEnqueue(rawArray, (byte)255, ref actualQueue);

            //Assert
            bool reminderAreEquals = Utils.AreEquals(expectedReminder, actualReminder);
            bool queueAreEquals = Utils.AreEquals(expectedQueue, actualQueue);
            Assert.IsTrue(reminderAreEquals && queueAreEquals);
        }


        [TestMethod]
        public void Form1_SplitArray_With2SeparatorsAtTheEnd_Ok()
        {
            //Arrange
            byte[] rawArray = { 255, 1, 2, 3, 255, 55, 56, 57, 255, 20, 17, 255, 18, 21, 255, 255 };

            Queue<byte[]> expectedQueue = new Queue<byte[]>();
            expectedQueue.Enqueue(new byte[] { 1, 2, 3 });
            expectedQueue.Enqueue(new byte[] { 55, 56, 57 });
            expectedQueue.Enqueue(new byte[] { 20, 17 });
            expectedQueue.Enqueue(new byte[] { 18, 21 });

            byte[] expectedReminder = new byte[] { 255 };

            //Act
            Queue<byte[]> actualQueue = new Queue<byte[]>();
            byte[] actualReminder = FrmMain.SplitArrayAndEnqueue(rawArray, (byte)255, ref actualQueue);

            //Assert
            bool reminderAreEquals = Utils.AreEquals(expectedReminder, actualReminder);
            bool queueAreEquals = Utils.AreEquals(expectedQueue, actualQueue);
            Assert.IsTrue(reminderAreEquals && queueAreEquals);
        }


        [TestMethod]
        public void Form1_SplitArray_WithOnlyOneSeparator()
        {
            //Arrange
            byte[] rawArray = {255};

            Queue<byte[]> expectedQueue = new Queue<byte[]>();
            byte[] expectedReminder = new byte[] { 255 };

            //Act
            Queue<byte[]> actualQueue = new Queue<byte[]>();
            byte[] actualReminder = FrmMain.SplitArrayAndEnqueue(rawArray, (byte)255, ref actualQueue);

            //Assert
            bool reminderAreEquals = Utils.AreEquals(expectedReminder, actualReminder);
            bool queueAreEquals = Utils.AreEquals(expectedQueue, actualQueue);
            Assert.IsTrue(reminderAreEquals && queueAreEquals);
        }

        [TestMethod]
        public void Form1_SplitArray_WithTwoSeparators()
        {
            //Arrange
            byte[] rawArray = { 255, 255 };

            Queue<byte[]> expectedQueue = new Queue<byte[]>();
            byte[] expectedReminder = new byte[] { 255 };

            //Act
            Queue<byte[]> actualQueue = new Queue<byte[]>();
            byte[] actualReminder = FrmMain.SplitArrayAndEnqueue(rawArray, (byte)255, ref actualQueue);

            //Assert
            bool reminderAreEquals = Utils.AreEquals(expectedReminder, actualReminder);
            bool queueAreEquals = Utils.AreEquals(expectedQueue, actualQueue);
            Assert.IsTrue(reminderAreEquals && queueAreEquals);
        }


        [TestMethod]
        public void Form1_SplitArray_WithoutSeparator()
        {
            //Arrange
            byte[] rawArray = { 1, 2, 3 };

            Queue<byte[]> expectedQueue = new Queue<byte[]>();
            byte[] expectedReminder = new byte[] { 1, 2 , 3 };

            //Act
            Queue<byte[]> actualQueue = new Queue<byte[]>();
            byte[] actualReminder = FrmMain.SplitArrayAndEnqueue(rawArray, (byte)255, ref actualQueue);

            //Assert
            bool reminderAreEquals = Utils.AreEquals(expectedReminder, actualReminder);
            bool queueAreEquals = Utils.AreEquals(expectedQueue, actualQueue);
            Assert.IsTrue(reminderAreEquals && queueAreEquals);
        }


        [TestMethod]
        public void Form1_SplitArray_WithEmptyArray()
        {
            //Arrange
            byte[] rawArray = { };

            Queue<byte[]> expectedQueue = new Queue<byte[]>();
            byte[] expectedReminder = new byte[] { };

            //Act
            Queue<byte[]> actualQueue = new Queue<byte[]>();
            byte[] actualReminder = FrmMain.SplitArrayAndEnqueue(rawArray, (byte)255, ref actualQueue);

            //Assert
            bool reminderAreEquals = Utils.AreEquals(expectedReminder, actualReminder);
            bool queueAreEquals = Utils.AreEquals(expectedQueue, actualQueue);
            Assert.IsTrue(reminderAreEquals && queueAreEquals);
        }
    }
}
