using System.Collections.Generic;

namespace Cofi.Authentication
{
    public sealed class AVRRole : AccessValidationRuleBase, IAccessValidationRule
    {
        public string Name { get; } = AccessValidationRuleNames.Role;
        public string Role { get; }

        public AVRRole(string role)
        {
            Role = role;
        }

        public override IDictionary<string, object> ExportData() => base.ExportData().FluentAdd(nameof(Role), Role);
    }
}