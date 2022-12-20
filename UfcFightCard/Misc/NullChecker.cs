using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UfcFightCard.Models;

namespace UfcFightCard.Misc
{
    public static class NullChecker
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
