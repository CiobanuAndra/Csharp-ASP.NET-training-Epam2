# Reflection

Beginner level tasks for practicing reflection.

Estimated time to complete the task - 0.5h.

The task requires .NET 8 SDK installed.


## Task Description

Reflection in .NET is a mechanism that allows to analyze types and work with the objects that describe types and type members. Read the [Reflection](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection) article before starting the task.


### 1. Getting the type name.

Implement the [GetTypeName](Reflection/ReflectionOperations.cs#L9) method, so it should return the type name of the `obj` argument.

1. Get the type of the `obj` argument using the [GetType](https://learn.microsoft.com/en-us/dotnet/api/system.object.gettype) method:

```cs
public static string GetTypeName(object obj)
{
    Type type = obj.GetType();
}
```

2. Return the value of the [Name](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo.name) property:

```cs
public static string GetTypeName(object obj)
{
    Type type = obj.GetType();
    return type.Name;
}
```


### 2. Getting the full type name.

The [GetFullTypeName](Reflection/ReflectionOperations.cs#L15) is a generic method that is declared with the `T` type parameter. Implement the `GetFullTypeName` method, so it should return the type full name of the `T` type parameter.

1. Use the [typeof operator](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#typeof-operator) to obtain the type of the `T` parameter:

```cs
public static string GetFullTypeName<T>()
{
    Type type = typeof(T);
}
```

2. Return the value of the [FullName](https://learn.microsoft.com/en-us/dotnet/api/system.type.fullname) property:

```cs
public static string GetFullTypeName<T>()
{
    Type type = typeof(T);
    return type.FullName;
}
```

3. Add the [null-forgiving operator !](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving) to the return expression to suppress the [CS8603 nullable warning](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings).

```cs
public static string GetFullTypeName<T>()
{
    Type type = typeof(T);
    return type.FullName!;
}
```


### 3. Getting the assembly-qualified name of a type.

Implement the [GetAssemblyQualifiedName](Reflection/ReflectionOperations.cs#L21) method, so it should return the [AssemblyQualifiedName](https://learn.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname) of the `T` type parameter.

### 4. Getting private fields of a type.

Implement the [GetPrivateInstanceFields](Reflection/ReflectionOperations.cs#L27) method, so it should return the array with all private instance fields of the `obj` argument. Use the [GetFields](https://learn.microsoft.com/en-us/dotnet/api/system.type.getfields) method in the object type with the relevant `bindingAttr` argument.


### 5. Getting the public static fields of a type.

Implement the [GetPublicStaticFields](Reflection/ReflectionOperations.cs#L33) method, so it should return the array with all private instance fields of the `obj` argument. Use the [GetFields](https://learn.microsoft.com/en-us/dotnet/api/system.type.getfields) method in the object type with the relevant `bindingAttr` argument.


### 6. Getting the Interface details of a type.

Implement the [GetInterfaceDataDetails](Reflection/ReflectionOperations.cs#L39) method, so it should return the array with interface details of the 'obj' argument. Use the [Type](https://learn.microsoft.com/en-us/dotnet/api/system.type.getinterfaces) method in the object type.


### 7. Getting the Constructor details of a type.Verifying Constructors of the class and validating it's constructors names.

Implement the [GetConstructorsDataDetails](Reflection/ReflectionOperations.cs#L45) method, so it should return the array with constructor details of the 'obj' argument. Use the [GetConstructors](https://learn.microsoft.com/en-us/dotnet/api/system.type.getconstructors) method in the object type.


### 8. Getting the Member details of a type. Verifying TypeMembers of the class and validating it's Member names.

Implement the [GetTypeMembersDataDetails](Reflection/ReflectionOperations.cs#L51) method, so it should return the array with member details of the 'obj' argument. Use the [GetMembers](https://learn.microsoft.com/en-us/dotnet/api/system.type.getmembers) method in the object type.


### 9. Getting the Method details of a type.

Implement the [GetMethodDataDetails](Reflection/ReflectionOperations.cs#L57) method, so it should return the array with method details of the 'obj' argument. Use the [GetMethods](https://learn.microsoft.com/en-us/dotnet/api/system.type.getmethods) method in the object type.

### 10. Getting the Properties details of a type.

Implement the [GetPropertiesDataDetails](Reflection/ReflectionOperations.cs#L63) method, so it should return the array with properties details of the 'obj' argument. Use the [GetProperties](https://learn.microsoft.com/en-us/dotnet/api/system.type.getproperties) method in the object type.


#### See also

* C# Language Reference
  * https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection
  * https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/viewing-type-information
  * https://learn.microsoft.com/en-us/dotnet/standard/attributes/retrieving-information-stored-in-attributes
  * https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/reflection-and-generic-types
  * https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/dynamically-loading-and-using-types
  * https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/get-type-member-information
  * https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/reflection-for-windows-store-apps
