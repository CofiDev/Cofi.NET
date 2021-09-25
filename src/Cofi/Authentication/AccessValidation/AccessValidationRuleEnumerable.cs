using System;
using System.Collections;
using System.Collections.Generic;

namespace Cofi.Authentication.AccessValidation
{
    public class AccessValidationRuleEnumerable : IAccessValidationRuleEnumerable
    {
        private readonly List<IAccessValidationRule> _rules = new();

        public int Count => _rules.Count;

        public void Add(IAccessValidationRule rule)
        {
            if (rule is null)
                throw new ArgumentNullException(nameof(rule), "Access validation rule cannot be null");

            _rules.Add(rule);
        }

        public IEnumerator<IAccessValidationRule> GetEnumerator() => _rules.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}