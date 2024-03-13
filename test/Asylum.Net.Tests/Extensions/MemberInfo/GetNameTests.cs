using System.Reflection;

namespace Asylum.Net.Tests;

/// <summary>
/// Tests the <see cref="MemberInfoExtensions.GetName(MemberInfo?)"/> method.
/// </summary>
[UsedImplicitly]
[ExcludeFromCodeCoverage]
public sealed class GetNameTests
{
    [Fact]
    public void GetName_WhenSourceIsNull_ThrowsArgumentNullException()
    {
        MemberInfo? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.GetName());
    }
    
    [Fact]
    public void GetName_WhenSourceIsNotObfuscated_ReturnsName()
    {
        var source = typeof(GetNameExcludedSample);
        
        var expectedName = source.Name;
        var actualName = source.GetName();
        Assert.Equal(expectedName, actualName);
    }
    
    [Fact]
    public void GetName_WhenSourceIsObfuscatedWithoutIdentifier_ReturnsName()
    {
        var source = typeof(GetNameObfuscatedSample);
        
        var expectedName = source.Name;
        var actualName = source.GetName();
        Assert.Equal(expectedName, actualName);
    }
    
    [Fact]
    public void GetName_WhenSourceIsObfuscatedWithIdentifier_ReturnsIdentifier()
    {
        var source = typeof(GetNameObfuscatedAndIdentifiedSample);
        
        var runtimeIdentifierAttribute = source.GetCustomAttribute<RuntimeIdentifierAttribute>();
        Assert.NotNull(runtimeIdentifierAttribute);
        
        var expectedName = runtimeIdentifierAttribute.Value;
        var actualName = source.GetName();
        Assert.Equal(expectedName, actualName);
    }
    
    [UsedImplicitly]
    [Obfuscation(Exclude = true)]
    private static class GetNameExcludedSample;
    
    [UsedImplicitly]
    [Obfuscation(Exclude = false)]
    private static class GetNameObfuscatedSample;

    [UsedImplicitly]
    [Obfuscation(Exclude = false)]
    [RuntimeIdentifier(nameof(GetNameObfuscatedAndIdentifiedSample))]
    private static class GetNameObfuscatedAndIdentifiedSample;
}