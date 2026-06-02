using System.Windows;
using System.Windows.Controls;
using ReservoirCalculator.ViewModels;

namespace ReservoirCalculator.Views
{
    public partial class ComponentsView : UserControl
    {
        public ComponentsView()
        {
            InitializeComponent();
            DataContext = new ComponentsViewModel();
        }
    }
}
