using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Services;
using Retarded_Game.Commands;

namespace Retarded_Game.ViewModels.ClassSelectionViewModels
{
    /// <summary>
    /// ViewModel describing class selection screen
    /// </summary>
    public partial class ClassSelectionViewModel : BaseViewModel
    {
        private readonly List<ClassViewModel> _startingClasses;
        private readonly NavigationService _navigationService;
        private ClassViewModel _selectedClass;

        public IEnumerable<ClassViewModel> StartingClasses => _startingClasses;
        public ClassViewModel SelectedClass 
        { 
            get => _selectedClass;
            set
            {
                _selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            } 
        }
        public int StartingLevel { get; set; }
        public CreateCharacterCommand CreateCharacterCommand => new CreateCharacterCommand(_navigationService, this);

        public ClassSelectionViewModel(NavigationService navigationService)
        {
            _startingClasses = new List<ClassViewModel> { new ClassViewModel(Trash()), new ClassViewModel(Warrior()),
                new ClassViewModel(Mage())};

            SelectedClass = _startingClasses.FirstOrDefault();
            _navigationService = navigationService;
        }
    }
}
