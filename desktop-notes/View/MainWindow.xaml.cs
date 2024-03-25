using desktop_notes.Model;
using desktop_notes.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace desktop_notes.View
{
    /// <summary>
    /// Main window of appliaction
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region Handler
        private void HandleDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void HandleAddClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var addNoteDialog = new EditNoteWindow();
                bool? dialogResult = addNoteDialog.ShowDialog();
                if (dialogResult.HasValue && dialogResult.Value)
                {
                    EditNoteWindowViewModel vm = (EditNoteWindowViewModel)addNoteDialog.DataContext;
                    StickyNote addedNote = vm.Note;

                    MainWindowViewModel? mainWindowVM = this.DataContext as MainWindowViewModel;
                    if (mainWindowVM != null)
                    {
                        mainWindowVM.AddNote(addedNote);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HandleOpenNoteClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Button activeBtn = (Button)sender;
                var selectedNoteItem = (NoteListItemViewModel)activeBtn.Tag;

                //prepare note window to open
                var noteWindow = new NoteWindow();
                var noteWindowVM = new NoteWindowViewModel(selectedNoteItem.Note);
                noteWindow.DataContext = noteWindowVM;

                //store noteWindow in note list item
                selectedNoteItem.Window = noteWindow;

                noteWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HandleEditNoteClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Button activeBtn = (Button)sender;
                NoteListItemViewModel selectedNoteItem = (NoteListItemViewModel)activeBtn.Tag;

                var editDialog = new EditNoteWindow();
                var editNoteWindowVM = new EditNoteWindowViewModel(selectedNoteItem.Note);
                editDialog.DataContext = editNoteWindowVM;

                editDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HandleRemoveNoteClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Button activeBtn = (Button)sender;
                var selectedNoteItem = (NoteListItemViewModel)activeBtn.Tag;

                var viewModel = (MainWindowViewModel)DataContext;
                viewModel.RemoveNote(selectedNoteItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HandleShowWindow(object sender, RoutedEventArgs e)
        {
            Show();
            Activate();
        }

        private void HandleHideWindow(object sender, RoutedEventArgs e) => Hide();

        private void HandleWindowClosed(object sender, EventArgs e)
        {
            try
            {
                TrayIcon.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
