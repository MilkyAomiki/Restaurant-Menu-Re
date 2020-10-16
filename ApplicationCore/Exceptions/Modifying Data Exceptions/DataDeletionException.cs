using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Exceptions.ModifyingDataExceptions
{
    public class DataDeletionException : MenuDataException
    {
        public DataDeletionException()
        {
        }

        public DataDeletionException(string message) : base(message)
        {
        }
    }
}
