using System.Windows;
using Retarded_Game.ViewModels;
using Retarded_Game.Stores;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Player Player { get; private set; }
        public static string CharacterName { get; set; }
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new StartingViewModel(_navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            
            base.OnStartup(e);
        }

        public static void CreatePlayer(PlayerStartingClass playerClass)
            => Player = new Player(CharacterName, playerClass);
        
    }
}
