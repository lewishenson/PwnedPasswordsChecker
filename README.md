# PwnedPasswordsChecker [![NuGet package](https://buildstats.info/nuget/PwnedPasswordsChecker)](https://www.nuget.org/packages/PwnedPasswordsChecker)

.NET helper to call Troy Hunt's Pwned Passwords v2 checker.

## Usage

Checking to see if a password has been previously exposed in a data breach:

```csharp
var passwordToCheck = "P@ssword";

var pwnedPasswords = new PwnedPasswords();
var isPwned = await pwnedPasswords.IsPwnedAsync(passwordToCheck);
```

Checking to see if how many times a password has been previously seen:

```csharp
var passwordToCheck = "P@ssword";

var pwnedPasswords = new PwnedPasswords();
var count = await pwnedPasswords.PwnedCountAsync(passwordToCheck);
```

## NuGet

If you don't care about the source code you can just install PwnedPasswordsChecker using NuGet.

### Package Manager
```powershell
PM> Install-Package PwnedPasswordsChecker
```

### .NET CLI
```powershell
> dotnet add package PwnedPasswordsChecker
```

## Further Reading

* [Pwned Passwords](https://haveibeenpwned.com/Passwords)
* [Troy Hunt's blog: I've Just Launched "Pwned Passwords" V2 With Half a Billion Passwords for Download](https://www.troyhunt.com/ive-just-launched-pwned-passwords-version-2/)
