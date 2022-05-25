namespace Retarded_Game.Commands
{
    /// <summary>
    /// Closes down the app
    /// </summary>
    public class CloseCommand : CommandBase
    {
        public override void Execute(object? parameter) => App.Current.Shutdown();
    }
}
