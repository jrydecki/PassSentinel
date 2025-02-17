using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSentinel
{

    public class SecureList<T> : IDisposable, IEnumerable<T> where T : class
    {
        private List<T> _list;
        private bool _disposed;

        public SecureList()
        {
            _list = new List<T>();
        }

        public void Add(T item)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(SecureList<T>));
            _list.Add(item);
        }

        public T this[int index]
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(nameof(SecureList<T>));
                return _list[index];
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(nameof(SecureList<T>));
                _list[index] = value;
            }
        }

        public int Count => _list.Count;

        public void Dispose()
        {
            if (!_disposed)
            {
                ClearMemory();
                _disposed = true;
            }
        }

        private void ClearMemory()
        {
            foreach (var item in _list)
            {
                ClearObject(item);
            }
            _list.Clear();
        }

        private void ClearObject(T item)
        {
            if (item == null) return;

            var fields = item.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(string))
                {
                    field.SetValue(item, null);
                }
                else if (!field.FieldType.IsValueType)
                {
                    field.SetValue(item, null);
                }
                else
                {
                    field.SetValue(item, Activator.CreateInstance(field.FieldType));
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(SecureList<T>));
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
