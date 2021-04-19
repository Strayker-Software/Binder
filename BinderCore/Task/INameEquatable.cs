using System.Diagnostics.CodeAnalysis;

namespace Binder.Task
{
    public interface INameEquatable
    {
        bool EqualsNames([AllowNull] string name);
    }
}
