# 🤪 Asylum.Net

Asylum.Net is a lightweight library designed to rescue developers from the common runtime issues caused by obfuscation. It provides a set of tools to help developers diagnose and fix issues caused by obfuscation, and provides a set of best practices to help developers avoid these issues in the first place.

![License](https://img.shields.io/github/license/tacosontitan/Asylum.Net?logo=github&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://asylum.tacosontitan.com)
- [How can I help?](./CONTRIBUTING.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How do I report security concerns?](./SECURITY.md)
- [What third-party dependencies are used?](./NOTICES.md)

### ✅ Small changes, continuously integrated

Pasper employs workflows for continuous integration to ensure the repository is held to industry standards; here's the current state of those workflows:

![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Asylum.Net/dotnet.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

### 💎 A few more gems

We believe in keeping the community informed, so here's a few more tidbits of information to satisfy some additional curiosities:

![Contributors](https://img.shields.io/github/contributors/tacosontitan/Asylum.Net?logo=github&style=for-the-badge)
![Issues](https://img.shields.io/github/issues/tacosontitan/Asylum.Net?logo=github&style=for-the-badge)
![Stars](https://img.shields.io/github/stars/tacosontitan/Asylum.Net?logo=github&style=for-the-badge)
![Size](https://img.shields.io/github/languages/code-size/tacosontitan/Asylum.Net?logo=github&style=for-the-badge)
![Line Count](https://img.shields.io/tokei/lines/github/tacosontitan/Asylum.Net?logo=github&style=for-the-badge)

## ✨ Features

The initial release contains very basic features for identifying obfuscated members in a .NET ecosystem. Consumers can utilize the `RuntimeIdentifierAttribute` to help identify obfuscated members at runtime:

```csharp
[Obfuscation(Feature = "virtualization", Exclude = false)]
[RuntimeIdentifier(nameof(Sample))]
public sealed class Sample;
```

Members can be identified with this attribute using natural means or through an extension method `GetName`:

```csharp
var typeName = typeof(Sample).GetName();
```

Additionally, if you just need to know if a member is marked with the obfuscation attribute, you can use the extension `IsObfuscated` for `MemberInfo` to determine just that:

```cs
var type = typeof(Sample);
if (type.IsObfuscated())
    Console.WriteLine("What have I done?");
```