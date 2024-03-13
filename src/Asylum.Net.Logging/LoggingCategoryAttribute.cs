namespace Asylum.Net.Logging;

/// <summary>
/// Associates logging from the decorated class with a specific category.
/// </summary>
/// <param name="value">Specifies the category to associate logging with.</param>
[AttributeUsage(
    validOn: AttributeTargets.Class,
    Inherited = false)]
public sealed class LoggingCategoryAttribute(string value)
    : Attribute
{
    /// <summary>
    /// Gets the category to associate logging with.
    /// </summary>
    public string Value { get; } = value;
}