![WrapperMeister](https://github.com/Moreault/WrapperMeister/blob/master/wrappermeister.png)
Base wrapper class and interface to seamlessly wrap any .NET type.

# What is it?
The `Wrapper<T>` class comes with a few overloads such as Equals, GetHashCode, ToString and others that are automatically mapped to the wrapped object. This allows you to use the wrapper as if it was the wrapped object.

You can access the wrapped object using the `Unwrapped` property or the `explicit` casting operator.

```cs
var actualObject = wrapper.Unwrapped;

var actualObject = (ActualType)wrapper;
```

# Why use it?
The `Wrapper<T>` class is useful when you want to add functionality to an existing class without modifying it. It is also useful when you want to wrap a class that you don't own.

The most common use case is when you need to mock a class that is not `virtual`, `abstract` or lacks an `interface`. You can create a wrapper that inherits from the class you want to mock and override the properties and methods you want to mock.

If you need a working real-world example, `Wrapper<T>` is used extensively in the [ToolBX.NetAbstractions](https://github.com/Moreault/NetAbstractions/) library.

```cs

# Getting started

First, create a class that inherits from `Wrapper<T>` and implements `IWrapper<T>`.

```cs
public class MyWrapper : Wrapper<MyType>, IWrapper<MyType>
{
	//TODO : Map properties and methods to the wrapped object

	public MyWrapper(MyType wrappedObject) : base(wrappedObject)
	{
	}
}
```

Then, you can use the wrapper as if it was the wrapped object.

```cs
var wrapper = new MyWrapper(new MyType());

wrapper.MyProperty = 42;
```

# IDisposable
If the wrapped object implements `IDisposable`, the wrapper _should_ also implement `IDisposable` and dispose the wrapped object when it is called but this mecahnism isn't built-in with `Wrapper<T>` so you have to do it yourself.

```cs
public class MyWrapper : Wrapper<MyType>,  IDisposable
{
	public MyWrapper(MyType wrappedObject) : base(wrappedObject)
	{
	}

	public void Dispose()
	{
		Unwrapped.Dispose();
	}
}
```