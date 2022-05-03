using MVVMGenericStructure.Commands;
using System.Windows;

namespace WPF.Command.Navigation
{
    public class StateBarCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "exit")
                Application.Current.Shutdown();
            else if (parameter.ToString() == "minimize")
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
