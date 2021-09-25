using System;
namespace Cofi.Authentication.AccessValidation
{
    public static class IAccessValdationRuleEnumerableExtensions
    {
        public static void AddRole(this IAccessValidationRuleEnumerable rules, string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException(nameof(role), "Role cannot be null or white-space");

            rules.Add(new AVRRole(role));
        }

        public static void AddPermission(this IAccessValidationRuleEnumerable rules, string permission)
        {
            if (string.IsNullOrWhiteSpace(permission))
                throw new ArgumentException(nameof(permission), "Permission cannot be null or white-space");

            rules.Add(new AVRPermission(permission));
        }

        public static IAccessValidationRuleEnumerable FluentAdd(this IAccessValidationRuleEnumerable rules, IAccessValidationRule rule)
        {
            rules.Add(rule);
            return rules;
        }

        public static IAccessValidationRuleEnumerable FluentAddRole(this IAccessValidationRuleEnumerable rules, string role)
        {
            rules.AddRole(role);
            return rules;
        }

        public static IAccessValidationRuleEnumerable FluentAddPermission(this IAccessValidationRuleEnumerable rules, string permission)
        {
            rules.AddPermission(permission);
            return rules;
        }
    }
}