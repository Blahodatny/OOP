using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp.Class;
using WpfApp.Commands;
using WpfApp.Dialogs;
using WpfApp.Serialization;

namespace WpfApp
{
    // Это класс модели представления, через который будут связаны модель Mathematician и представление MainWindow.xaml
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Mathematician _selectedMath;

        public ObservableCollection<Mathematician> Mathematicians { get; set; }

        private readonly IFileService<Mathematician> _fileService;
        private readonly IDialogService _dialogService;

        // команда сохранения файла
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand => _saveCommand ??
                  (_saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (_dialogService.SaveFileDialog())
                          {
                              _fileService.Serialization(Mathematicians.ToList(), _dialogService.FilePath);
                              _dialogService.ShowMessage("File has been saved!");
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));

        // команда открытия файла
        private RelayCommand _openCommand;
        public RelayCommand OpenCommand => _openCommand ??
                  (_openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (_dialogService.OpenFileDialog())
                          {
                              var mathes = _fileService.Deserialization<Mathematician>(_dialogService.FilePath);
                              Mathematicians.Clear();
                              foreach (var math in mathes)
                                  Mathematicians.Add(math);
                              _dialogService.ShowMessage("File has been opened!");
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));

        public Mathematician SelectedMath
        {
            get => _selectedMath;
            set
            {
                _selectedMath = value;
                OnPropertyChanged("SelectedMath");
            }
        }

        public ApplicationViewModel(IDialogService dialogService, IFileService<Mathematician> fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
            Mathematicians = new ObservableCollection<Mathematician>();
            var mathes = new Json().Deserialization<Mathematician>(@"C:\WpfApp\WpfApp\data\file.json");
            foreach (var math in mathes)
                Mathematicians.Add(math);
        }

        // команда добавления нового объекта
        private RelayCommand _addCommand;
        public RelayCommand AddCommand => _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      var math = new Mathematician();
                      Mathematicians.Insert(0, math);
                      SelectedMath = math;
                  }));

        // команда удаления
        private RelayCommand _removeCommand;
        public RelayCommand RemoveCommand => _removeCommand ??
                  (_removeCommand = new RelayCommand(obj =>
                  {
                      if (obj is Mathematician math)
                      {
                          Mathematicians.Remove(math);
                      }
                  },
                 obj => Mathematicians.Count > 0));

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}