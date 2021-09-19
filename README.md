# Ashpro String Extensions

I created this string extensions class while the development of 'Ashpro ERP' application. I have included many features as helpful to speedup the c#.net coding

## Converting an object to intiger

Normally we are using convert.ToIntiger(Value) method to convert an object to intiger
while useing AshproStringExtensions you can simply use ToInt32() extension method.

```C#
string sOne = "1";
int iOne = sOne.ToInt32();
```

## Converting a string to decimal

```C#
string sValue = "2.1";
decimal dValue = sValue.ToDecimal();
```
