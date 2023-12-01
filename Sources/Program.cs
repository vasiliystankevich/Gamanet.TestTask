using Project.Kernel;
using System;
using Gamanet.TestTask.Wpf.Interfaces;
using Project.Kernel.Interfaces.Unity;
using Unity;

namespace Gamanet.TestTask.Wpf;

public class Program
{
    [STAThread]
    static void Main()
    {
        var container = Project.Kernel.Unity.UnityConfig.GetConfiguredContainer();
        BaseTypeFabric.RegisterTypes<TypeFabric>(container);

        var executor = container.Resolve<IUnityContainerExecutor>();

        var app = executor.Resolve<IApp>();
        var mainWindow = executor.Resolve<IMainWindow>();
        app.Run((MainWindow)mainWindow);
    }
}