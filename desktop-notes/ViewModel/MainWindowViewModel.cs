using desktop_notes.Model;
using desktop_notes.Util;
using desktop_notes.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktop_notes.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Singleton member
        public static MainWindowViewModel GlobalViewModel { get => _viewModel; }

        private static MainWindowViewModel _viewModel = new();
        #endregion


        #region Constructor
        private MainWindowViewModel()
        {
            _stickyNotes.CollectionChanged += (s, e) => OnPropertyChanged(nameof(StickyNotes));

            //initialize commands
            AddNoteCommand = new RelayCommand(AddNote);
        }
        #endregion


        #region Field
        string? _title;
        ObservableCollection<StickyNote> _stickyNotes = new();
        #endregion


        #region Property
        //---data---
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public ObservableCollection<StickyNote> StickyNotes
        {
            get => _stickyNotes;
            set
            {
                _stickyNotes = value;
                OnPropertyChanged(nameof(StickyNotes));
            }
        }

        //---command---
        public ICommand AddNoteCommand { get; }
        #endregion


        #region Private Method
        void AddNote(object? param)
        {
            var addNoteDialog = new AddStickyNoteDialog();
            addNoteDialog.DataContext = new StickyNote();

            bool? dialogResult = addNoteDialog.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                StickyNote newNote = (StickyNote)addNoteDialog.DataContext;
                this.StickyNotes.Add(newNote);
            }
        }
        #endregion
    }
}
