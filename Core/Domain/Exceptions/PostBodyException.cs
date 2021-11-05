using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class PostBodyException : Exception
    {
        public PostBodyException(object body) : base($"Post body incorrect:\n {body} ")
        {

        }
        public PostBodyException(object body, string message) : base(message)
        {

        }
    }
}
