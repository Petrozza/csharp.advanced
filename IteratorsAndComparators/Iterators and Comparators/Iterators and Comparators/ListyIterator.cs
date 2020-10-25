using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Iterators_and_Comparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;
        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            index = 0;
        }

        public bool Move()
        {
            bool hasNext = HasNext();
            if (hasNext)
            {
                index++;
            }
            return hasNext;
        }

        public void Print()
        {
            if (!elements.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[index]);
        }

        public bool HasNext()
        {
            if (index < elements.Count - 1 ) 
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
