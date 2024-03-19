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

using System.Diagnostics.Contracts;
using System.Reflection;

namespace Asylum.Net;

/// <summary>
/// Defines extension methods for <see cref="MemberInfo"/>.
/// </summary>
public static partial class MemberInfoExtensions
{
    /// <summary>
    /// Gets the runtime identifier of the specified member.
    /// </summary>
    /// <param name="source">Specifies the member to get the runtime identifier for.</param>
    /// <returns>
    ///     If the member is obfuscated and marked with the <see cref="RuntimeIdentifierAttribute"/>,
    ///     the value of the attribute is returned; otherwise, the name of the member is used.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     The source is null.
    /// </exception>
    [Pure]
    public static string GetRuntimeIdentifier(this MemberInfo? source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source), "The source member cannot be null.");

        if (!source.IsObfuscated())
            return source.Name;
        
        var runtimeIdentifierAttribute = source.GetCustomAttribute<RuntimeIdentifierAttribute>();
        return runtimeIdentifierAttribute?.Value ?? source.Name;
    }
}