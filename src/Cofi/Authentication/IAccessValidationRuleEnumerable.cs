using System.Collections.Generic;

namespace Cofi.Authentication
{
    public interface IAccessValidationRuleEnumerable : IEnumerable<IAccessValidationRule>
    {
        public int Count { get; }
        void Add(IAccessValidationRule rule);
    }
}