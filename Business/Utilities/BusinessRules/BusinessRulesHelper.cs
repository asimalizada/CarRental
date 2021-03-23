

using Core.Utilities.Results.Abstract;

namespace Business.Utilities.BusinessRules
{
    public static class BusinessRulesHelper
    {
        public static IResult Check(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.Success)
                {
                    return rule;
                }
            }

            return null;
        }
    }
}
