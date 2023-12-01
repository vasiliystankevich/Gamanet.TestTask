using Gamanet.TestTask.Wpf.Interfaces;
using Gamanet.TestTask.Wpf.Logic;
using Project.Kernel;
using Project.Kernel.Interfaces;
using Project.Kernel.Interfaces.Unity;
using Project.Kernel.Unity;
using Unity;
using Unity.Interception.Utilities;

namespace Gamanet.TestTask.Wpf
{
    public class TypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnityContainerExecutor, UnityContainerExecutor>();
            container.RegisterType<IUnityContainerFunctors, UnityContainerFunctors>();
            container.RegisterInstance(typeof(IConfigureLogger), "Topshelf:Sirilog:Logger", new ConfigureLogger());

            //container.RegisterType<IRegistratorTypes, RegistratorTypes>("HiveOs.WatchDog.RegistratorTypes");

            var registrators = container.ResolveAll<IRegistratorTypes>();
            registrators.ForEach(registrator => registrator.RegisterAll());
        }
    }
}