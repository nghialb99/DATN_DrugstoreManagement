using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DrugstoreManagement.Utilities
{
    public class GuardAgainst
    {
        public static void Null<T>(
            [NotNull] T? value,
            [CallerArgumentExpression(parameterName: "value")] string? paramName = null)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }
    }
}
