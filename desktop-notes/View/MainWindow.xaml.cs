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
    /// Interaction logic for MainWindow.xaml
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
                var addNoteDialog = new AddNoteWindow();
                bool? dialogResult = addNoteDialog.ShowDialog();
                if (dialogResult.HasValue && dialogResult.Value)
                {
                    AddNoteWindowViewModel vm = (AddNoteWindowViewModel)addNoteDialog.DataContext;
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

        private void HandleOpenClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NotesList.SelectedItem == null) return;
                StickyNote selectedNote = (StickyNote)NotesList.SelectedItem;

                var noteWindow = new NoteWindow()
                {
                    DataContext = new NoteWindowViewModel(selectedNote)
                };
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
