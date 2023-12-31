﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Fundamentals
{
    public class Math
    {
        public int Add(int a, int b) => a + b;
        public int Max(int a, int b) => a > b ? a : b;

        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (int i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i;
        }


    }
}
