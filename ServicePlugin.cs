using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FService
{
    public sealed class ServicePlugin : GamePlugin, IServicePlugin
    {

        //Singleton
        private static ServicePlugin _instance;
        public static IServicePlugin Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = PluginManager.GetPlugin<ServicePlugin>();
                }

                return _instance;
            }
        }

        //Collection of services
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public event Action Add;        //Callback when a service is added
        public event Action Remove;     //Callback when a service is removed

        //Contrustor
        private ServicePlugin()
        {
            _description = new PluginDescription()
            {
                Name = "Service Plugin",
                Version = new Version(1,0),
                Author = "neuro-machina",
                AuthorUrl = "https://www.neuro-machina.net",
                HomepageUrl = "https://www.neuro-machina.net",
                Description = "Service registry",
                Category = "System",
                IsBeta = true,
                IsAlpha = false
            };
        }

        #region GamepPlugin

        //Initialize
        public override void Initialize()
        {
            base.Initialize();

            if(_services == null)
            {
                _services = new Dictionary<Type, object>();
            }
        }

        //Deinitialize
        public override void Deinitialize()
        {
            _services?.Clear();

            #if FLAX_EDITOR

            _services = null;

            #endif

            base.Deinitialize();
        }

        #endregion

        //Register a service
        public void AddService<T>(T provider) where T: class => AddService(typeof(T), provider);
        public void AddService(Type type, object provider)
        {
            //Null check
            if(type == null || provider == null)
            {
                return;
            }

            //Check if the type is assignable to the object
            if(!type.IsAssignableFrom(provider.GetType()))
            {
                return;
            }

            //If the key isn't there already then add the service
            if(_services.ContainsKey(type) == false)
            {
                _services.Add(type, provider);
                Add?.Invoke();
            }
        }

        //Get a registered service by type
        public T GetService<T>() where T : class
        {
            var type = typeof(T);

            //Null check
            if(type == null)
            {
                return null;
            }

            //Retrieve casted service object
            object service;
            if(_services.TryGetValue(type, out service))
            {
                return service as T;
            }

            return null;
        }

        //Remove a specific service by type
        public void RemoveService(Type type)
        {
            if(type == null)
            {
                return;
            }

            _services.Remove(type);
            Remove?.Invoke();
        }
    }
}