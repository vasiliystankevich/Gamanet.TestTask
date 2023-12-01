using Project.Kernel;
using Project.Kernel.Interfaces;
using Project.Kernel.Interfaces.Unity;
using Project.Kernel.Unity;
using Unity;
using Unity.Interception.Utilities;

namespace Gamanet.TestTask.Wpf;

public class TypeFabric:BaseTypeFabric
{
    public override void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IUnityContainerExecutor, UnityContainerExecutor>();
        container.RegisterType<IUnityContainerFunctors, UnityContainerFunctors>();

        container.RegisterType<IRegistratorTypes, RegistratorTypes>("Gamanet.TestTask.Wpf.RegistratorTypes");

        var registrators = container.ResolveAll<IRegistratorTypes>();
        registrators.ForEach(registrator => registrator.RegisterAll());
    }
}