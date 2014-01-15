Plist-Builder
==============

A fast, lightweight library to serialize non-circular-referencing .NET objects to Apple's plist format.  
Originally by Noah Santorello

This is a fast, lightweight library I built for serializing non-circular-referencing .NET objects to Apple's plist format.  
The serializer outputs all non-null public properties of an object. Sample usage:

    MyClass myObject = new MyClass();
    // ... set some fields of myObject
    string serialized = PlistGenerator.Serialize(myObject, false);


So if you're working with a .NET backend but need to communicate with Apple devices in a convenient format (although JSON is pretty convenient with some third-party libraries), feel free to give this a shot.
