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
/// Tests the <see cref="MemberInfoExtensions.GetRuntimeIdentifier(MemberInfo?)"/> method.
/// </summary>
[UsedImplicitly]
[ExcludeFromCodeCoverage]
public sealed class GetRuntimeIdentifierTests
{
    [Fact]
    public void GetRuntimeIdentifier_WhenSourceIsNull_ThrowsArgumentNullException()
    {
        MemberInfo? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.GetRuntimeIdentifier());
    }
    
    [Fact]
    public void GetRuntimeIdentifier_WhenSourceIsNotObfuscated_ReturnsName()
    {
        var source = typeof(GetRuntimeIdentifierExcludedSample);
        
        var expectedIdentifier = source.Name;
        var actualIdentifier = source.GetRuntimeIdentifier();
        Assert.Equal(expectedIdentifier, actualIdentifier);
    }
    
    [Fact]
    public void GetRuntimeIdentifier_WhenSourceIsObfuscatedWithoutIdentifier_ReturnsName()
    {
        var source = typeof(GetRuntimeIdentifierObfuscatedSample);
        
        var expectedIdentifier = source.Name;
        var actualIdentifier = source.GetRuntimeIdentifier();
        Assert.Equal(expectedIdentifier, actualIdentifier);
    }
    
    [Fact]
    public void GetRuntimeIdentifier_WhenSourceIsObfuscatedWithIdentifier_ReturnsIdentifier()
    {
        var source = typeof(GetRuntimeIdentifierObfuscatedAndIdentifiedSample);
        
        var runtimeIdentifierAttribute = source.GetCustomAttribute<RuntimeIdentifierAttribute>();
        Assert.NotNull(runtimeIdentifierAttribute);
        
        var expectedIdentifier = runtimeIdentifierAttribute.Value;
        var actualIdentifier = source.GetRuntimeIdentifier();
        Assert.Equal(expectedIdentifier, actualIdentifier);
    }
    
    [UsedImplicitly]
    [Obfuscation(Exclude = true)]
    private static class GetRuntimeIdentifierExcludedSample;
    
    [UsedImplicitly]
    [Obfuscation(Exclude = false)]
    private static class GetRuntimeIdentifierObfuscatedSample;

    [UsedImplicitly]
    [Obfuscation(Exclude = false)]
    [RuntimeIdentifier(nameof(GetRuntimeIdentifierObfuscatedAndIdentifiedSample))]
    private static class GetRuntimeIdentifierObfuscatedAndIdentifiedSample;
}