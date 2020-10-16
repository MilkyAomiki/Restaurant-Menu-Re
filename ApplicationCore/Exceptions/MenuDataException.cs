using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Exceptions
{
    /// <summary>
    /// Generic exception that is thrown when excepttion while working with data occurs
    /// </summary>
    public class MenuDataException : Exception
    {
        public MenuDataException()
        {
        }

        public MenuDataException(string message) : base(message)
        {
        }

    }
}
