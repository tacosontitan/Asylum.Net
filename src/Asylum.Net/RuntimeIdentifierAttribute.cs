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
/// Specifies the preferred identifier for a member at runtime.
/// </summary>
/// <param name="value">The value used to identify the member at runtime.</param>
/// <remarks>
///     When <see cref="ObfuscationAttribute"/> is detected and the type or member is not excluded using
///     <see cref="ObfuscationAttribute.Exclude"/>, this attribute is preferred.
/// </remarks>
[AttributeUsage(validOn: AttributeTargets.All, Inherited = false)]
public sealed class RuntimeIdentifierAttribute(string value)
    : Attribute
{
    /// <summary>
    /// Gets the value used to identify the member at runtime.
    /// </summary>
    public string Value { get; } = value;
}