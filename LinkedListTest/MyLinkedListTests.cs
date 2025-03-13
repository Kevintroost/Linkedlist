using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LinkedListTest
{
    [TestFixture]
    public class MyLinkedListTests
    {
        private MyLinkedList<int> _list;

        // This method will run before each test to set up a new instance of the linked list
        [SetUp]
        public void Setup()
        {
            _list = new MyLinkedList<int>();
        }

        // Happy Path: Add elements and check count increases
        [Test]
        public void Add_ShouldIncreaseCount_WhenElementIsAdded()
        {
            _list.Add(10);
            _list.Add(20);

            _list.Count.Should().Be(2); // After adding two elements, count should be 2
        }

        // Happy Path: Access elements by index
        [Test]
        public void Indexer_ShouldReturnCorrectElement_WhenIndexIsValid()
        {
            _list.Add(10);
            _list.Add(20);

            _list[0].Should().Be(10); // First element should be 10
            _list[1].Should().Be(20); // Second element should be 20
        }

        // Unhappy Path: Index out of range when accessing by index
        [Test]
        public void IndexerShouldThrowArgumentOutOfRangeExceptionWhenIndexIsInvalid()
        {
            // Arrange: _list is assumed to be an empty list
            Action act = () => { var item = _list[0]; }; // The list is empty, so index 0 is invalid

            // Assert: Expect ArgumentOutOfRangeException to be thrown
            act.Should().Throw<ArgumentOutOfRangeException>();
        }



        // Happy Path: Contains method
        [Test]
        public void Contains_ShouldReturnTrue_WhenElementExists()
        {
            _list.Add(10);
            _list.Add(20);

            _list.Contains(10).Should().BeTrue(); // List should contain 10
            _list.Contains(20).Should().BeTrue(); // List should contain 20
        }

        // Unhappy Path: Contains method when element doesn't exist
        [Test]
        public void Contains_ShouldReturnFalse_WhenElementDoesNotExist()
        {
            _list.Add(10);

            _list.Contains(20).Should().BeFalse(); // 20 is not in the list
        }

        // Happy Path: Remove element
        [Test]
        public void Remove_ShouldDecreaseCount_WhenElementIsRemoved()
        {
            _list.Add(10);
            _list.Add(20);
            _list.Remove(10);

            _list.Count.Should().Be(1); // Count should be 1 after removing 10
            _list.Contains(10).Should().BeFalse(); // 10 should no longer exist in the list
        }

        // Unhappy Path: Remove element that doesn't exist
        [Test]
        public void Remove_ShouldNotAlterList_WhenElementDoesNotExist()
        {
            _list.Add(10);
            _list.Add(20);
            _list.Remove(30); // 30 doesn't exist in the list

            _list.Count.Should().Be(2); // The count should stay the same
        }

        // Happy Path: Insert element at specific index
        [Test]
        public void Insert_ShouldAddElementAtCorrectIndex()
        {
            _list.Add(10);
            _list.Add(30);
            _list.Insert(1, 20); // Insert 20 at index 1

            _list[0].Should().Be(10); // First element should be 10
            _list[1].Should().Be(20); // Second element should be 20
            _list[2].Should().Be(30); // Third element should be 30
        }

        // Unhappy Path: Insert element at invalid index
        [Test]
        public void Insert_ShouldThrowArgumentOutOfRangeException_WhenIndexIsOutOfRange()
        {
            Action act = () => _list.Insert(1, 20); // Index 1 is invalid for an empty list

            act.Should().Throw<ArgumentOutOfRangeException>(); // Expect ArgumentOutOfRangeException
        }

        // Happy Path: Remove element by index
        [Test]
        public void RemoveAt_ShouldRemoveElementAtSpecifiedIndex()
        {
            _list.Add(10);
            _list.Add(20);
            _list.RemoveAt(0); // Remove element at index 0

            _list.Count.Should().Be(1); // After removal, count should be 1
            _list[0].Should().Be(20); // The only element left should be 20
        }

        // Unhappy Path: Remove element at invalid index
        [Test]
        public void RemoveAt_ShouldThrowArgumentOutOfRangeException_WhenIndexIsOutOfRange()
        {
            Action act = () => _list.RemoveAt(0); // Trying to remove from an empty list

            act.Should().Throw<ArgumentOutOfRangeException>(); // Expect ArgumentOutOfRangeException
        }

        // Happy Path: Clear all elements from the list
        [Test]
        public void Clear_ShouldRemoveAllElements_WhenCalled()
        {
            _list.Add(10);
            _list.Add(20);
            _list.Clear();

            _list.Count.Should().Be(0); // After clearing, count should be 0
        }
    }
}