# FService
Simple service pattern plugin for Flax Engine, inspired by MonoGame ServiceContainer.

## How to use:

First you need to register a service, it can be done from anywhere you want as long you are registering a class, can also register an object by interface:

using FService;

ServicePlugin.Instance.AddService<MyServiceType>(MyServiceObject);

Then to retrieve a service simply call:

ServicePlugin.Instance.GetService<MyServiceType>();

You can also remove services (usefull for script type to be cleared on OnDestroy):

ServicePlugin.Instance.RemoveService(typeof(MyServiceType));

## Notes:
This is pretty much the ServiceContainer from MonoGame project, just wrapped up for Flax Engine use.


