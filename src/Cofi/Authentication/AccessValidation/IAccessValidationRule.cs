using System.Collections;
using System.Collections.Generic;

namespace Cofi.Authentication.AccessValidation
{
    public interface IAccessValidationRule
    {
        string Name { get; }

        IDictionary<string, object> ExportData();
    }
}