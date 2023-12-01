using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gamanet.TestTask.Wpf.Interfaces;
using System.Windows;

namespace Gamanet.TestTask.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IMainWindow
{
    public MainWindow(IDataLoader dataLoader)
    {
        using var streamReader = File.OpenText("Data\\PersonsDemo.csv");
        Persons = dataLoader.Load(streamReader)
            .Where(p => p.IsValidData)
            .ToList();
        InitializeComponent();
    }

    public List<Logic.Person> Persons;
}