using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class MemoryService
    {
        private Stack<double> memoryStack = new Stack<double>();

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

    }
}

