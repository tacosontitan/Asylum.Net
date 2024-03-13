/*
 * Copyright 2024 tacosontitan and contributors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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