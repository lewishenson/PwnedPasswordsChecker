# PwnedPasswordsChecker

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

## More Reading

* [Pwned Passwords](https://haveibeenpwned.com/Passwords)
* [Troy Hunt's blog: I've Just Launched "Pwned Passwords" V2 With Half a Billion Passwords for Download](https://www.troyhunt.com/ive-just-launched-pwned-passwords-version-2/)
