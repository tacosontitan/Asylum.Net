# 🤪 Asylum.Net

Asylum.Net is a lightweight library designed to rescue developers from the common runtime issues caused by obfuscation. It provides a set of tools to help developers diagnose and fix issues caused by obfuscation, and provides a set of best practices to help developers avoid these issues in the first place.

![License](https://img.shields.io/github/license/tacosontitan/Asylum.Net?logo=github&style=for-the-badge)
![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Asylum.Net/dotnet.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://asylum.tacosontitan.com)
- [How can I help?](./CONTRIBUTING.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How do I report security concerns?](./SECURITY.md)
- [What third-party dependencies are used?](./NOTICES.md)

## ✨ Features

The initial release contains very basic features for identifying obfuscated members in a .NET ecosystem. Consumers can utilize the `RuntimeIdentifierAttribute` to help identify obfuscated members at runtime:

```csharp
[RuntimeIdentifier(nameof(Sample))]
[Obfuscation(Feature = "virtualization", Exclude = false)]
public sealed class Sample;
```

Members can be identified with this attribute using natural means or through an extension method `GetRuntimeIdentifier`:

```csharp
var typeName = typeof(Sample).GetRuntimeIdentifier();
```

Additionally, if you just need to know if a member is marked with the obfuscation attribute, you can use the extension `IsObfuscated` for `MemberInfo` to determine just that:

```cs
var type = typeof(Sample);
if (type.IsObfuscated())
    Console.WriteLine("What have I done?");
```