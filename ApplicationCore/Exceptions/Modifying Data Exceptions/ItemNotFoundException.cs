using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Exceptions.Modifying_Data_Exceptions
{
    public class ItemNotFoundException<T> : MenuDataException
    {
        public int Id { get;}
        public T Item { get; }

        public ItemNotFoundException(T item)
        {
            Item = item;
        }
        public ItemNotFoundException(int id)
        {
            Id = id;
        }
        public ItemNotFoundException(T item, int id)
        {
            Item = item;
            Id = id;
        }

        public ItemNotFoundException(string message, int id) : base(message)
        {
            Id = id;
        }
        public ItemNotFoundException(string message, int id, T item) : base(message)
        {
            Id = id;
            Item = item;
        }
    }
}
