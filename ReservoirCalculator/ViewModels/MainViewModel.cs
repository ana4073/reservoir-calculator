using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using ReservoirCalculator.Models;
using ReservoirCalculator.Services;

namespace ReservoirCalculator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private double _diameter = 5.0;
        private double _height = 8.0;
        private double _wallThickness = 10.0;
        private double _roofHeight = 0.5;
        private string _selectedReservoirType = "РВС";
        private string _selectedRoofType = "Коническая";
        private string _selectedBottomType = "Эллиптическое";
        private double _calculatedVolume = 0;
        private double _calculatedMass = 0;
        private double _calculatedArea = 0;
        private Model3D _model3D = new Model3DGroup();

        public double Diameter
        {
            get => _diameter;
            set
            {
                if (_diameter != value)
                {
                    _diameter = value;
                    OnPropertyChanged(nameof(Diameter));
                    RecalculateAndVisualize();
                }
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                    RecalculateAndVisualize();
                }
            }
        }

        public double WallThickness
        {
            get => _wallThickness;
            set
            {
                if (_wallThickness != value)
                {
                    _wallThickness = value;
                    OnPropertyChanged(nameof(WallThickness));
                    RecalculateAndVisualize();
                }
            }
        }

        public double RoofHeight
        {
            get => _roofHeight;
            set
            {
                if (_roofHeight != value)
                {
                    _roofHeight = value;
                    OnPropertyChanged(nameof(RoofHeight));
                    RecalculateAndVisualize();
                }
            }
        }

        public string SelectedReservoirType
        {
            get => _selectedReservoirType;
            set
            {
                if (_selectedReservoirType != value)
                {
                    _selectedReservoirType = value;
                    OnPropertyChanged(nameof(SelectedReservoirType));
                    RecalculateAndVisualize();
                }
            }
        }

        public string SelectedRoofType
        {
            get => _selectedRoofType;
            set
            {
                if (_selectedRoofType != value)
                {
                    _selectedRoofType = value;
                    OnPropertyChanged(nameof(SelectedRoofType));
                    RecalculateAndVisualize();
                }
            }
        }

        public string SelectedBottomType
        {
            get => _selectedBottomType;
            set
            {
                if (_selectedBottomType != value)
                {
                    _selectedBottomType = value;
                    OnPropertyChanged(nameof(SelectedBottomType));
                    RecalculateAndVisualize();
                }
            }
        }

        public double CalculatedVolume
        {
            get => _calculatedVolume;
            set
            {
                if (_calculatedVolume != value)
                {
                    _calculatedVolume = value;
                    OnPropertyChanged(nameof(CalculatedVolume));
                }
            }
        }

        public double CalculatedMass
        {
            get => _calculatedMass;
            set
            {
                if (_calculatedMass != value)
                {
                    _calculatedMass = value;
                    OnPropertyChanged(nameof(CalculatedMass));
                }
            }
        }

        public double CalculatedArea
        {
            get => _calculatedArea;
            set
            {
                if (_calculatedArea != value)
                {
                    _calculatedArea = value;
                    OnPropertyChanged(nameof(CalculatedArea));
                }
            }
        }

        public Model3D Model3D
        {
            get => _model3D;
            set
            {
                if (_model3D != value)
                {
                    _model3D = value;
                    OnPropertyChanged(nameof(Model3D));
                }
            }
        }

        public ObservableCollection<string> ReservoirTypes { get; } = new ObservableCollection<string> { "РВС", "РГС" };
        public ObservableCollection<string> RoofTypes { get; } = new ObservableCollection<string> { "Коническая", "Плоская", "Полусферичная" };
        public ObservableCollection<string> BottomTypes { get; } = new ObservableCollection<string> { "Плоское", "Эллиптическое", "Полусферичное" };

        public ICommand ResetCommand { get; }
        public ICommand ExportCommand { get; }

        public MainViewModel()
        {
            ResetCommand = new RelayCommand(Reset);
            ExportCommand = new RelayCommand(Export);
            RecalculateAndVisualize();
        }

        private void RecalculateAndVisualize()
        {
            ReservoirBase reservoir;

            if (SelectedReservoirType == "РВС")
            {
                reservoir = new RVS
                {
                    Diameter = Diameter,
                    Height = Height,
                    WallThickness = WallThickness,
                    RoofHeight = RoofHeight,
                    RoofType = SelectedRoofType
                };
            }
            else
            {
                reservoir = new RGS
                {
                    Diameter = Diameter,
                    Height = Height,
                    WallThickness = WallThickness,
                    BottomType = SelectedBottomType
                };
            }

            CalculatedVolume = reservoir.CalculateVolume();
            CalculatedMass = reservoir.CalculateMass();
            CalculatedArea = reservoir.GetSurfaceArea();

            if (SelectedReservoirType == "РВС")
            {
                var rvsReservoir = reservoir as RVS;
                Model3D = VisualizationService.CreateRVSModel(Diameter, Height, RoofHeight, SelectedRoofType);
            }
            else
            {
                var rgsReservoir = reservoir as RGS;
                Model3D = VisualizationService.CreateRGSModel(Diameter, Height, SelectedBottomType);
            }
        }

        private void Reset()
        {
            Diameter = 5.0;
            Height = 8.0;
            WallThickness = 10.0;
            RoofHeight = 0.5;
            SelectedReservoirType = "РВС";
            SelectedRoofType = "Коническая";
            SelectedBottomType = "Эллиптическое";
        }

        private void Export()
        {
            var result = new CalculationResult
            {
                ReservoirType = SelectedReservoirType,
                Volume = CalculatedVolume,
                Mass = CalculatedMass,
                Diameter = Diameter,
                Height = Height,
                WallThickness = WallThickness,
                SurfaceArea = CalculatedArea,
                RoofMaterial = SelectedRoofType,
                BottomMaterial = SelectedBottomType
            };

            var fileName = $"Reservoir_{SelectedReservoirType}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            System.IO.File.WriteAllText(fileName, result.ToString());
            System.Windows.MessageBox.Show($"Результат сохранен в {fileName}");
        }
    }
}
