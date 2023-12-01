using System.IO;
using System.Linq;
using Gamanet.TestTask.Wpf.Interfaces;
using System.Windows;
using System.Collections.ObjectModel;
using Gamanet.TestTask.Wpf.Logic;

namespace Gamanet.TestTask.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IMainWindow
{
    public MainWindow(IDataLoader dataLoader)
    {
        InitializeComponent();
        Persons = new ObservableCollection<Person>();
        using var streamReader = File.OpenText("Data\\PersonsDemo.csv");
        dataLoader.Load(streamReader)
            .Where(p => p.IsValidData)
            .ToList().ForEach(Persons.Add);
        PersonList.ItemsSource = Persons;
    }

    public ObservableCollection<Logic.Person> Persons;
}