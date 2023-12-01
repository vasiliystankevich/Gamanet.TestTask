using Gamanet.TestTask.Wpf.Interfaces;
using System.Windows;

namespace Gamanet.TestTask.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IMainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}