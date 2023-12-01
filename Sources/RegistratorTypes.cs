using System;
using System.IO;
using Gamanet.TestTask.Wpf.Interfaces;
using Gamanet.TestTask.Wpf.Logic;
using Project.Kernel;
using Project.Kernel.Interfaces.Unity;

namespace Gamanet.TestTask.Wpf;

public class RegistratorTypes:BaseRegistratorTypes
{
    public RegistratorTypes(IUnityContainerExecutor executor) : base(executor)
    {
    }

    public override void RegisterAll()
    {
        Executor.RegisterSingletonFactory<IConfigureLogger>(_ => new ConfigureLogger())
            .RegisterFactory(executor =>
            {
                var configureLogger = executor.Resolve<IConfigureLogger>();
                var logFilePath = Path.Combine(new[] { AppContext.BaseDirectory, "Logs\\Gammanet.TestTask.Wpf.txt" });
                return configureLogger.GetLogger(logFilePath);
            })
            .RegisterSingletonFactory<IDataLoader>(_ => new DataLoader())
            .RegisterFactory<IMainWindow>(executor=>
            {
                var dataLoader = executor.Resolve<IDataLoader>();
                return new MainWindow(dataLoader);
            })
            .RegisterSingletonFactory<IApp>(_ => new App());
    }
}