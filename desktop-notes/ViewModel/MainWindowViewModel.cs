﻿using desktop_notes.Model;
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
using System.Windows.Automation.Provider;
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
            AddNoteCommand = new RelayCommand(AddNote,(noteToAdd) => noteToAdd is StickyNote);
            OpenNoteCommand = new RelayCommand(OpenNote);
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
        public ICommand OpenNoteCommand { get; }
        #endregion


        #region Command Method
        public void AddNote(object? param)
        {
            try
            {
                StickyNote? noteToAdd = param as StickyNote;
                if (noteToAdd == null) throw new ArgumentException("AddNoteCommand should be called with a StickyNote passed in as parameter.");

                this.StickyNotes.Add(noteToAdd);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void OpenNote(object? param)
        {
            try
            {
                StickyNote? noteToOpen = param as StickyNote;
                if (noteToOpen == null) throw new ArgumentException("OpenNoteCommand should be called with a StickyNote passed in as parameter");

                var noteWindow = new NoteWindow();
                var viewModel = new NoteWindowViewModel(noteToOpen);
                noteWindow.DataContext = viewModel;

                noteWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
