EventDSL
========

Writing event and command classes is extremely tedious. Why not let the computer
do the repetitive work so you can focus on the most important aspects of modeling?

Spec format
-----------

* Any line that starts with a word, such as `SomeType` is turned into a class.
* Properties may be declared by following the type name by a block:
  `SomeType { s:FirstProperty s:SecondProperty }`
* Property types are indicated with the prefixed letter, strings, ints, longs and DateTime are supported.
* Since strings are so common, a property without a type prefix is inferred to be a string.
* A type can 'extend' another type by following its name with a colon and the name
  of the parent type: `SomeType : BaseType`.
* Properties can be added to the extending type as well: `SomeType : BaseType { i:YetAnotherProperty }`
* All properties from the parent type are _copied_ to the extending type, avoiding the
  use of class hierarchies or abstract classes.
* Any type that was extended is _not_ represented in the output. These types should be regarded
  as templates for other types, not as types in their own right.
* Any line that starts with "NS:" is treated as the namespace to use for all following types.
* The namespace is applied until another NS: declaration is seen.

Output
------

The spec is turned into a C# file with basic indentation. All generated types are public,
and all properties have both public getters and setters for easy serialization.
