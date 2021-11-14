using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class ColorBuildException : Exception
    {
        public ColorBuildException(Exception ex) : base(ex.Message)
        {

        }
    }
}
