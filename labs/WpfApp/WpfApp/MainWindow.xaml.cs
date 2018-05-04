using System.Windows;
using WpfApp.Serialization;
using WpfApp.Dialogs;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // https://metanit.com/sharp/wpf/22.2.php
            InitializeComponent();
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new Json());
        }
    }
}