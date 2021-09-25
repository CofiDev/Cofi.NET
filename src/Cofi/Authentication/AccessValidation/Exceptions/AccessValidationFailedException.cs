using System.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cofi.Exceptions;
using System.Text;

namespace Cofi.Authentication.AccessValidation.Exceptions
{
    public class AccessValidationFailedException : CofiException
    {
        public IEnumerable<IAccessValidationRule> FailedRules { get; init; } = Enumerable.Empty<IAccessValidationRule>();

        public AccessValidationFailedException()
        {
        }

        public AccessValidationFailedException(string? message) : base(message)
        {
        }

        public AccessValidationFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccessValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected override void SetClientMessage(StringBuilder clientMessageBuilder) => clientMessageBuilder.Append("Access has been denied");

        protected override void SetContextData(IDictionary<string, object> contextData) => contextData
            .FluentAdd(nameof(FailedRules), FailedRules.Select(rule => new { ruleName = rule.Name, data = rule.ExportData() }));
    }
}