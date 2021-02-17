using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stackOfElements;

        public Box()
        {
            stackOfElements = new Stack<T>();
        }

        public int Count {
            get
            {
                return stackOfElements.Count;
            }
        }
        public void Add(T element)
        {
            stackOfElements.Push(element);
        }

        public T Remove()
        {
            T element = stackOfElements.Pop();
            return element;
        }
        
    }
}