[![Build status](https://ci.appveyor.com/api/projects/status/3bem2a7rwf2nai26?svg=true)](https://ci.appveyor.com/project/MarcinCelej/synergy-contracts)

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
What you can find above is some attributes from ReSharper's [static nullability analysis](https://www.jetbrains.com/resharper/help/Code_Analysis__Code_Annotations.html). The `[NotNull]` or `[CanBeNull]` attributes inform ReSharper about nullability contract of your method. The problem is that those attributes only inform, they actually do not check that arguments or returned value against null. Moreover the above method not only requires that the first and last name cannot be null but it cannot even be en empty string or wihitespace. The last requirement cannot be checked by the ReSharper.

To make sure your contract is checked during code execution you should add constraint checks. You can find the `Fail` calls above checking preconditions of the method. Is that all? Yes it is and it ins't. There are many helper methods on the  `Fail` class starting from nullability checks, argument requirements, casting checks and also fluent methods that make it easier to develop.

## idea

Let us not explain the basics of DbC programming. What we believe is that the constraint checks should be checked not only in development phase but also on site. That's why the Fails you add to your code are compiled with it. Why? We believe that all constraint violations should be found during development but... Sometimes live shows that they are not. Therefore when there is such a situation you know more when you see `'firstName' was an empty string` instead of NullReferenceException.

Rules we love to share:
- consider each method separately - what contract this method has 
- check method arguments for contract violation in the beginning of your method 
- keep an empty line after the arguments contract checks (preconditions)
- keep the contract check one line long - do not disturb your code coverage
- do not unit test the contracts 
- use it with [NotNull] and [CanBeNull] attributes 

## nullability checks

The most commonly occuring exception in .NET world is `NullReferenceException`. Therefor it is good to have a strategy for dealing with null in your code. Here is a list we prefer to use:
- 80% (maybe 90%) of our code assumes that argument, property or variable is `[NotNull]` (should never be null)
- Nullable arguments should always be marked with `[CanBeNull]` attribute
