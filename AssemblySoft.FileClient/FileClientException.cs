using System;

namespace AssemblySoft.FileClient
{
    /// <summary>
    /// File client exception
    /// </summary>
    class FileClientException : Exception
    {
        public FileClientException() {}

        public FileClientException(string message):base(message)
        {
        }

        public FileClientException(string message,Exception inner):base(message,inner)
        {
        }
    }
}
