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