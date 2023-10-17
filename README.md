# FService
Simple service pattern plugin for Flax Engine, inspired by MonoGame ServiceContainer.

## How to use:

First you need to register a service, it can be done from anywhere you want as long you are registering a class, can also register an object by interface:
```c#
using FService;

ServicePlugin.Instance.AddService<MyServiceType>(MyServiceObject);
```
Then to retrieve a service simply call:
```c#
ServicePlugin.Instance.GetService<MyServiceType>();
```
You can also remove services (usefull for script type to be cleared on OnDestroy):
```c#
ServicePlugin.Instance.RemoveService(typeof(MyServiceType));
```

There are also two event Action callbacks you can subscribe to in the plugin for when a service is added and removed:
```c#
ServicePlugin.Instance.Add += MyVoidMethod;
ServicePlugin.Instance.Remove += MyVoidMethod;
```

## Notes:
This is pretty much the ServiceContainer from MonoGame project, just wrapped up for Flax Engine use.


