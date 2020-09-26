using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ApplicationCore.Exceptions
{
    public class TitleException : Exception
    {
        public string TitleName { get; }

        public TitleException(string titleName)
        {
            TitleName = titleName;
        }

        public TitleException(string titleName, string message) : base(message)
        {
            TitleName = titleName;
        }

    }
}
