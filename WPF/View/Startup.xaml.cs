using System.Windows;

namespace WPF.View
{
    public partial class Startup : Window
    {
        public Startup()
        {
            InitializeComponent();
            MaximizeWindow();
        }
        private void MaximizeWindow()
        {
            #region Sentencias de para el agrandado de la pantalla
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height;
            Top = SystemParameters.WorkArea.Bottom - Height;
            Left = SystemParameters.PrimaryScreenWidth - Width;
            #endregion
        }
    }
}
