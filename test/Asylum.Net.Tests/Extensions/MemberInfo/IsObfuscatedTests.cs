using System.Reflection;

namespace Asylum.Net.Tests;

/// <summary>
/// Tests the <see cref="MemberInfoExtensions.IsObfuscated(MemberInfo?)"/> method.
/// </summary>
[UsedImplicitly]
[ExcludeFromCodeCoverage]
public sealed class IsObfuscatedTests
{
    [Fact]
    public void IsObfuscated_WhenSourceIsNull_ThrowsArgumentNullException()
    {
        MemberInfo? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.IsObfuscated());
    }
    
    [Fact]
    public void IsObfuscated_WhenSourceIsNotObfuscated_ReturnsFalse()
    {
        var source = typeof(IsObfuscatedUnmarkedSample);
        
        var actual = source.IsObfuscated();
        Assert.False(actual);
    }
    
    [Fact]
    public void IsObfuscated_WhenSourceIsExcludedWithObfuscationAttribute_ReturnsFalse()
    {
        var source = typeof(IsObfuscatedExcludedSample);
        
        var actual = source.IsObfuscated();
        Assert.False(actual);
    }
    
    [Fact]
    public void IsObfuscated_WhenSourceIsMarkedWithObfuscationAttributeButNotExcluded_ReturnsTrue()
    {
        var source = typeof(IsObfuscatedObfuscatedSample);
        
        var actual = source.IsObfuscated();
        Assert.True(actual);
    }
    
    [UsedImplicitly]
    private static class IsObfuscatedUnmarkedSample;
    
    [UsedImplicitly]
    [Obfuscation(Exclude = true)]
    private static class IsObfuscatedExcludedSample;
    
    [UsedImplicitly]
    [Obfuscation(Exclude = false)]
    private static class IsObfuscatedObfuscatedSample;
}