using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;

        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (var element in elements)
            {
                this.Push(element);
            }

            return this;
        }
    }
}
