﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.ViewModels;
using Retarded_Game.ViewModels.ClassSelectionViewModels;
using Retarded_Game.Services;

namespace Retarded_Game.Commands
{
    public class ConfirmNameCommand : NavigateCommand
    {
        EnterNameViewModel _nameViewModel;

        public ConfirmNameCommand(EnterNameViewModel nameViewModel, NavigationService navigationService) : base(navigationService)
        { 
            _nameViewModel = nameViewModel;
            _nameViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(_nameViewModel.CharacterName))
                    OnCanExecuteChanged();
            };
        }

        public override bool CanExecute(object? parameter)
        {
            return _nameViewModel.CharacterName.Length >= 5  
                && _nameViewModel.CharacterName.Length <= 20 
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            App.CharacterName = _nameViewModel.CharacterName;
            base.Execute(parameter);
        }
    }
}
