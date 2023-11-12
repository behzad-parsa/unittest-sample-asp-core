using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowNullException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }
        [Test]
        public void Push_ValidArg_AddObjectToTheStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("Hellooo");
            Assert.That(stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0));
        }
        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnsObjectOnTheTop()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Pop();
            Assert.That(result, Is.EqualTo("c"));
        }
        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(2));
        }
        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithTheObjects_ReturnObjectOnTheTopOfStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Peek();
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithTheObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Peek();
            Assert.That(stack.Count, Is.EqualTo(3));
        }


    }
}
