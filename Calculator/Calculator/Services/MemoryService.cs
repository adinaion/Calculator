﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class MemoryService
    {
        private Stack<double> memoryStack = new Stack<double>();
        private double memoryValue = 0;

        public double MemoryValue => memoryValue;
        
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

        //public void AddToMemory(double value)
        //{
        //    memoryValue += value;
        //}

        //public void SubtractFromMemory(double value)
        //{
        //    memoryValue -= value;
        //}

        //public void StoreInMemory(double value)
        //{
        //    memoryValue = value;
        //}


        //public void ClearMemory()
        //{
        //    memoryValue = 0;
        //}


        //public void ClearMemoryStack()
        //{
        //    memoryStack.Clear();
        //}
    }
}

