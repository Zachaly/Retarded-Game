using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Retarded_Game.Commands
{
    internal class CloseCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            App.Current.Shutdown();
        }
    }
}
