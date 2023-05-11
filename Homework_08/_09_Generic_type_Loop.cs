/// https://www.codewars.com/kata/5794cf0b73938ec43700002b

using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_08._09_Generic_type_Loop
{
    public class Loop<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>(); // Internal List to store items
        private int _currentIndex = 0; // Current index in the loop

        public void Add(T item)
        {
            // add to the end
            _items.Add(item);
        }

        public void Left()
        {
            // rotate to left
            _currentIndex = (_currentIndex + 1) % _items.Count;
        }

        public void Rigth()
        {
            // rotate to right
            _currentIndex = (_currentIndex - 1 + _items.Count) % _items.Count;
        }

        public T PopOut()
        {
            // popout the first itme
            T item = _items[_currentIndex];
            _items.RemoveAt(_currentIndex);
            _currentIndex = (_currentIndex) % _items.Count;
            return item;
        }

        public T ShowFirst()
        {
            // show the first item
            return _items[_currentIndex];
        }

        // Implementation of IEnumerable<T> interface
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        // Implementation of IEnumerable interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
