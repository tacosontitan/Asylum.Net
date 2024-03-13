using System.Diagnostics.Contracts;
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

namespace Asylum.Net;

/// <summary>
/// Defines extension methods for <see cref="MemberInfo"/>.
/// </summary>
public static partial class MemberInfoExtensions
{
    /// <summary>
    ///     Determines whether the specified <see cref="MemberInfo"/> is marked with a non-excluded
    ///     instance of the <see cref="ObfuscationAttribute"/>.
    /// </summary>
    /// <param name="source">Specifies the type to check.</param>
    /// <returns>
    ///     <see langword="true"/> if the <see cref="MemberInfo"/> is obfuscated;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     The source is null.
    /// </exception>
    [Pure]
    public static bool IsObfuscated(this MemberInfo? source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source), "The source type cannot be null.");
        
        var obfuscationAttribute = source.GetCustomAttribute<ObfuscationAttribute>();
        return obfuscationAttribute is { Exclude: false };
    }
}