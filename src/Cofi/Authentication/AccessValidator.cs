using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Cofi.Authentication
{
    internal sealed class AccessValidator : AccessValidatorBase, IAccessValidator
    {
        private static readonly ConcurrentDictionary<Type, ValidateAccessWrapperBase> _validateAccessImpls = new();
        
        private readonly ServiceFactory _factory;

        public AccessValidator(ServiceFactory factory)
        {
            _factory = factory;
        }

        protected override async Task<bool> ValidateAsync(IAccessValidationRule rule, CancellationToken cancellationToken = default)
        {
            var ruleType = rule.GetType();
            var validateAccessImpl = _validateAccessImpls.GetOrAdd(ruleType,
                type => (ValidateAccessWrapperBase?)(Activator.CreateInstance(typeof(ValidateAccessWrapperImpl<>).MakeGenericType(ruleType)))
                ?? throw new InvalidOperationException($"Could not create wrapper for type {type}")
            );

            return await validateAccessImpl.ValidateAsync(rule, _factory, cancellationToken);
        }
    }
}