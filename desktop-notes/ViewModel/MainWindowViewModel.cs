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
using System.Windows.Automation.Provider;
using System.Windows.Input;

namespace desktop_notes.ViewModel
{
    /// <summary>
    /// View Model for <see cref="MainWindow"/>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Singleton member
        /// <summary>
        /// Access global view model of <see cref="MainWindow"/>
        /// </summary>
        public static MainWindowViewModel GlobalViewModel { get => _instance; }

        private static MainWindowViewModel _instance = new();
        #endregion


        #region Constructor
        private MainWindowViewModel()
        {
            _stickyNotes.CollectionChanged += (s, e) => OnPropertyChanged(nameof(StickyNotes));

            //initialize commands
            AddNoteCommand = new RelayCommand(AddNote, (noteToAdd) => noteToAdd is StickyNote);
            RemoveNoteCommand = new RelayCommand(RemoveNote, (noteToRemove) => noteToRemove is StickyNote);
        }
        #endregion


        #region Field
        string? _title;
        ObservableCollection<NoteListItemViewModel> _stickyNotes = new();
        #endregion


        #region Property
        //---data---
        /// <summary>
        /// Get/Set the Title of MainWindow
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        /// <summary>
        /// Access the StickyNote collection of MainWindow
        /// </summary>
        public ObservableCollection<NoteListItemViewModel> StickyNotes { get => _stickyNotes; }

        //---command---
        /// <summary>
        /// Command to add a new sticky note
        /// <para>* should call with a <see cref="StickyNote"/> pass in as CommandParameter</para>
        /// </summary>
        public ICommand AddNoteCommand { get; }
        /// <summary>
        /// Command to remove a sticky note from MainWindow
        /// <para>* should call with a <see cref="NoteListItemViewModel"/> pass in as CommandParameter</para>
        /// </summary>
        public ICommand RemoveNoteCommand { get; }
        #endregion


        #region Command Method
        public void AddNote(object? param)
        {
            try
            {
                StickyNote? noteToAdd = param as StickyNote;
                if (noteToAdd == null) throw new ArgumentException("AddNoteCommand should be called with a StickyNote passed in as parameter.");

                var noteListItem = new NoteListItemViewModel(noteToAdd);
                this.StickyNotes.Add(noteListItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void RemoveNote(object? param)
        {
            try
            {
                NoteListItemViewModel? noteToRemove = param as NoteListItemViewModel;
                if (noteToRemove == null) throw new ArgumentException("RemoveNoteCommand should be called with a NoteListItemViewModel passed in as parameter.");

                StickyNotes.Remove(noteToRemove);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
