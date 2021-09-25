using System.Collections.Generic;

namespace Cofi.Authentication.AccessValidation
{
    public sealed class AVRPermission : AccessValidationRuleBase, IAccessValidationRule
    {
        public string Name { get; } = AccessValidationRuleNames.Permission;
        public string Permission { get; }

        public AVRPermission(string permission)
        {
            Permission = permission;
        }

        public override IDictionary<string, object> ExportData() => base.ExportData().FluentAdd(nameof(Permission), Permission);
    }
}