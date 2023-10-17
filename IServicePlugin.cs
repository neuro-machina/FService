using System;

namespace FService
{
    public interface IServicePlugin
    {
        event Action Add;
        event Action Remove;

        void AddService<T>(T provider) where T: class;
        void AddService(Type type, object provider);
        T GetService<T>() where T : class;
        void RemoveService(Type type);
    }
}

