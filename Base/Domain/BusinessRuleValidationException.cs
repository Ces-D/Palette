using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Base.Domain
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; init; }
        public string Details { get; init; }
        public BusinessRuleValidationException(IBusinessRule brokenRule) { BrokenRule = brokenRule; this.Details = brokenRule.Message; }
        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}
