using System.Windows;
using ReservoirCalculator.ViewModels;

namespace ReservoirCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
