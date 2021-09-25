using System.Diagnostics.Contracts;
using System.Collections.Generic;

namespace Cofi.Authentication.AccessValidation
{
    public abstract class AccessValidationRuleBase
    {
        public virtual IDictionary<string, object> ExportData() => new Dictionary<string, object>();
    }
}