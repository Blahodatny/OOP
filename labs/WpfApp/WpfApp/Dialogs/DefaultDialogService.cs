using Microsoft.Win32;
using System.Windows;

namespace WpfApp.Dialogs
{
    public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true) return false;
            FilePath = openFileDialog.FileName;
            return true;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != true) return false;
            FilePath = saveFileDialog.FileName;
            return true;
        }

        public void ShowMessage(string message) => MessageBox.Show(message);
    }
}