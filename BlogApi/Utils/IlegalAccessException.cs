using System;

namespace BlogApi.Utils
{
    public class IlegalAccessException : Exception
    {
        public IlegalAccessException()
        {
        }

        public IlegalAccessException(string message) : base(message) { }
    }
}