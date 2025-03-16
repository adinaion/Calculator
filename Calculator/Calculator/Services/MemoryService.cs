using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Services
{
    public class MemoryService
    {
        private Stack<double> memoryStack = new Stack<double>();

        #region Exterior Memory
        public void SaveToMemoryStack(double value)
        {
            memoryStack.Push(value);
        }

        public IEnumerable<double> ShowMemoryStack()
        {
            return memoryStack;
        }

        public double RecallMemory()
        {
            return memoryStack.Count > 0 ? memoryStack.Peek() : 0;
        }

        public void ClearMemory()
        {
            memoryStack.Clear();
        }

        public void AddToTopOfMemoryStack(double value)
        {
            if (memoryStack.Count > 0)
            {
                double topValue = memoryStack.Peek();
                memoryStack.Pop();
                memoryStack.Push(topValue + value);
            }
            else
            {
                memoryStack.Push(value);
            }
        }

        public void SubtractFromTopOfMemoryStack(double value)
        {
            if (memoryStack.Count > 0)
            {
                double topValue = memoryStack.Peek();
                memoryStack.Pop();
                memoryStack.Push(topValue - value);
            }
            else
            {
                memoryStack.Push(-value);
            }
        }

        #endregion

        #region Interior Memory
        public void RemoveFromMemoryStack(double value)
        {
            var stackList = memoryStack.ToList();
            stackList.Remove(value);

            memoryStack.Clear();
            foreach (var item in stackList)
            {
                memoryStack.Push(item);
            }
        }

        public void AddToMemoryStack(double valueFromStack, double currentValue)
        {
            var queueList = new Queue<double>();

            foreach (var item in memoryStack.Reverse())
            {
                if (item == valueFromStack)
                    queueList.Enqueue(item + currentValue);
                else
                    queueList.Enqueue(item);
            }

            memoryStack.Clear();
            foreach (var item in queueList)
            {
                memoryStack.Push(item);
            }
        }

        public void SubtractFromMemoryStack(double valueFromStack, double currentValue)
        {
            var queueList = new Queue<double>();

            foreach (var item in memoryStack.Reverse())
            {
                if (item == valueFromStack)
                    queueList.Enqueue(item - currentValue);
                else
                    queueList.Enqueue(item);
            }

            memoryStack.Clear();
            foreach (var item in queueList)
            {
                memoryStack.Push(item);
            }
        }

        #endregion

    }
}

