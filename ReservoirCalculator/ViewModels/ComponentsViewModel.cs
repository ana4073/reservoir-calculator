using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using ReservoirCalculator.Models;
using ReservoirCalculator.Services;

namespace ReservoirCalculator.ViewModels
{
    public class ComponentsViewModel : ViewModelBase
    {
        private readonly ComponentService _componentService = new();
        private readonly MaterialService _materialService = new();

        private ObservableCollection<Component> _allComponents;
        private ObservableCollection<Component> _selectedComponents;
        private ObservableCollection<Material> _materials;
        private Component _selectedComponent;
        private Material _selectedMaterial;
        private double _totalComponentCost;
        private double _totalComponentWeight;

        public ObservableCollection<Component> AllComponents
        {
            get => _allComponents;
            set
            {
                if (_allComponents != value)
                {
                    _allComponents = value;
                    OnPropertyChanged(nameof(AllComponents));
                }
            }
        }

        public ObservableCollection<Component> SelectedComponents
        {
            get => _selectedComponents;
            set
            {
                if (_selectedComponents != value)
                {
                    _selectedComponents = value;
                    OnPropertyChanged(nameof(SelectedComponents));
                    CalculateTotals();
                }
            }
        }

        public ObservableCollection<Material> Materials
        {
            get => _materials;
            set
            {
                if (_materials != value)
                {
                    _materials = value;
                    OnPropertyChanged(nameof(Materials));
                }
            }
        }

        public Component SelectedComponent
        {
            get => _selectedComponent;
            set
            {
                if (_selectedComponent != value)
                {
                    _selectedComponent = value;
                    OnPropertyChanged(nameof(SelectedComponent));
                }
            }
        }

        public Material SelectedMaterial
        {
            get => _selectedMaterial;
            set
            {
                if (_selectedMaterial != value)
                {
                    _selectedMaterial = value;
                    OnPropertyChanged(nameof(SelectedMaterial));
                }
            }
        }

        public double TotalComponentCost
        {
            get => _totalComponentCost;
            set
            {
                if (_totalComponentCost != value)
                {
                    _totalComponentCost = value;
                    OnPropertyChanged(nameof(TotalComponentCost));
                }
            }
        }

        public double TotalComponentWeight
        {
            get => _totalComponentWeight;
            set
            {
                if (_totalComponentWeight != value)
                {
                    _totalComponentWeight = value;
                    OnPropertyChanged(nameof(TotalComponentWeight));
                }
            }
        }

        public ICommand AddComponentCommand { get; }
        public ICommand RemoveComponentCommand { get; }
        public ICommand LoadStandardCommand { get; }

        public ComponentsViewModel()
        {
            AllComponents = _componentService.GetAllComponents();
            Materials = _materialService.GetAllMaterials();
            SelectedComponents = new ObservableCollection<Component>();

            AddComponentCommand = new RelayCommand(AddComponent, CanAddComponent);
            RemoveComponentCommand = new RelayCommand(RemoveComponent, CanRemoveComponent);
            LoadStandardCommand = new RelayCommand(LoadStandardComponents);
        }

        private bool CanAddComponent() => SelectedComponent != null;

        private void AddComponent()
        {
            if (SelectedComponent != null)
            {
                SelectedComponents.Add(SelectedComponent);
                CalculateTotals();
            }
        }

        private bool CanRemoveComponent() => SelectedComponents.Count > 0;

        private void RemoveComponent()
        {
            if (SelectedComponents.Count > 0)
            {
                SelectedComponents.RemoveAt(SelectedComponents.Count - 1);
                CalculateTotals();
            }
        }

        private void LoadStandardComponents()
        {
            SelectedComponents.Clear();
            var standard = _componentService.GetStandardComponents("РВС");
            foreach (var component in standard)
            {
                SelectedComponents.Add(component);
            }
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            TotalComponentWeight = SelectedComponents.Sum(c => c.GetTotalWeight());
            TotalComponentCost = SelectedComponents.Sum(c => c.GetTotalCost());
        }
    }
}
