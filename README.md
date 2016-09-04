# synergy.contracts - a programming by contract C# library

Design by contract (DbC), also known as contract programming, programming by contract and design-by-contract programming, is an approach for designing software. In software words - if a class provides some functionality, through a method, it expects that certain criteria should be met - the method has a contract. When 'client' does not meet the contract of 'supplier' it will receive an exception.

## development phase

DbC help us develop more reliable software. It is one of the basic principles of clean code programming. During the development phase when we integrate components (simply: when we call method of another class) we may violate the contract and receive the exception, but this is what it is for. If you encounter such case, you simply need to conform the contract of the 'supplier' class.

Now, let's quit yapping and show some code:

```C#
[NotNull, Pure]
public static Contractor CreatePerson([NotNull] string firstName, [NotNull] string lastName)
{
    Fail.IfArgumentEmpty(firstName, nameof(firstName));
    Fail.IfArgumentWhiteSpace(lastName, nameof(lastName));

    return new Contractor()
    {
        FirstName = firstName,
        LastName = lastName
    };
}
```
What you can find above is some attributes from ReSharper's [static nullability analysis](https://www.jetbrains.com/resharper/help/Code_Analysis__Code_Annotations.html). The `[NotNull]` or `[CanBeNull]` attributes inform ReSharper about nullability contract of your method. The problem is that those attributes only inform, thay actually do not check that arguments or returned value against null. Moreover the above method not only requires that the first and last name cannot be null but it cannot even be en empty string or wihitespace. 
