## WTelegramClient Type Abstractions and Extensions

[![NuGet](https://img.shields.io/nuget/v/WTC.Abstractions.Types)](https://www.nuget.org/packages/WTC.Abstractions.Types)

this project aims to make it easier to work with Telegram-Api types using [WTC](https://github.com/wiz0u/WTelegramClient).

the goal is to eliminate the need of `pattern-matching` and `type casting` as much as possible and have more `FP` approach instead of `OOP` (the underlying impl is `OOP` however.

this library should NOT contain any Logic on its own, its should offer flexibility and readability for exchange of small performance _decrease_.
### Use

this package is available through nuget: `dotnet add package WTC.Abstractions.Types`

after installation simply import the Library:

```csharp
using WTC.Abstractions.Types;
```

**all the available methods are shown here:** [examples](https://github.com/MrAliSalehi/WTelegramClient.Abstractions.Types/blob/master/Examples/)


### Contribution

contribution are welcome, but please [open a Discussion](https://github.com/MrAliSalehi/WTelegramClient.Abstractions.Types/discussions/new/choose) first to discuss about what you are looking for or what you want to implement first! you can also mention it in our [telegram Group](https://t.me/WTelegramClient).

