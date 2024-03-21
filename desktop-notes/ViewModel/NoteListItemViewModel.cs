using desktop_notes.Model;
using desktop_notes.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_notes.ViewModel
{
    /// <summary>
    /// Represents an note item in <see cref="MainWindow"/>. 
    /// <para>this view model is design to storing and managing a <see cref="StickyNote"/> and its <see cref="NoteWindow"/></para>
    /// </summary>
    public class NoteListItemViewModel : ViewModelBase
    {
        #region Constructor
        public NoteListItemViewModel()
        {

        }

        public NoteListItemViewModel(StickyNote note)
        {
            _note = note;
        }
        #endregion


        #region Field
        StickyNote _note = new();
        NoteWindow? _window = null;
        bool _hasOpenWindow = false;
        #endregion


        #region Property
        /// <summary>
        /// Access the <see cref="StickyNote"/> display by this list item
        /// </summary>
        public StickyNote Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
        /// <summary>
        /// Access the <see cref="NoteWindow"/> of this note on the screen
        /// <para>if this note doesn't open a window, return null</para>
        /// </summary>
        public NoteWindow? Window
        {
            get => _window;
            set
            {
                _window = value;
                OnPropertyChanged(nameof(Window));

                //register event for window opening and widnow closing
                if (_window != null)
                {
                    _window.Loaded += (s, e) =>
                    {
                        HasOpenWindow = true;
                    };

                    _window.Closed += (s, e) =>
                    {
                        this.Window = null;
                        HasOpenWindow = false;
                    };
                }
            }
        }
        /// <summary>
        /// Get a value that indicates whether the note window is closed.
        /// </summary>
        public bool HasOpenWindow
        {
            get => _hasOpenWindow;
            set
            {
                _hasOpenWindow = value;
                OnPropertyChanged(nameof(HasOpenWindow));
            }
        }
        #endregion
    }
}
