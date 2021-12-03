namespace Domain.Common;

public class BusinessRuleValidationException : Exception
{
    public IBusinessRule BrokenRule { get; init; }
    public string Details { get; init; }
    public BusinessRuleValidationException(IBusinessRule brokenRule)
    {
        BrokenRule = brokenRule; this.Details = brokenRule.Message;
    }

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}
