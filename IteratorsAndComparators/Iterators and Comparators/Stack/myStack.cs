using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace myStack
{
    public class myStack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public myStack(List<T> elements)
        {
            elements = new List<T>();
        }

        public myStack()
        {
            elements = new List<T>();
        }

        public int Count => elements.Count;

        

        public void Push(T element)
        {
            elements.Add(element);
        }

        public T Pop()
        {
            var removed = elements[^1];
            elements.RemoveAt(elements.Count - 1);
            return removed;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
