using System;

namespace Random11.Exceptions
{
    public class MaxPlayerExceededException: Exception
    {
        public MaxPlayerExceededException(string message): base(message)
        {

        }
    }
}
