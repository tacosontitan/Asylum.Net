using System.Diagnostics.Contracts;
using System.Reflection;

namespace Asylum.Net;

/// <summary>
/// Defines extension methods for <see cref="MemberInfo"/>.
/// </summary>
public static partial class MemberInfoExtensions
{
    /// <summary>
    /// Gets the name of the specified member.
    /// </summary>
    /// <param name="source">Specifies the member to get the name for.</param>
    /// <returns>
    ///     If the member is obfuscated and marked with the <see cref="RuntimeIdentifierAttribute"/>,
    ///     the value of the attribute is returned; otherwise, the name of the member is used.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     The source is null.
    /// </exception>
    [Pure]
    public static string GetName(this MemberInfo? source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source), "The source member cannot be null.");

        if (!source.IsObfuscated())
            return source.Name;
        
        var runtimeIdentifierAttribute = source.GetCustomAttribute<RuntimeIdentifierAttribute>();
        return runtimeIdentifierAttribute?.Value ?? source.Name;
    }
}