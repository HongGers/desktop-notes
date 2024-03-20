using desktop_notes.Model;
using desktop_notes.Util;
using desktop_notes.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace desktop_notes.ViewModel
{
    /// <summary>
    /// View Model for <see cref="NoteWindow"/>
    /// </summary>
    public class NoteWindowViewModel : ViewModelBase
    {
        #region Constructor
        /// <summary>
        /// Construct <see cref="NoteWindowViewModel"/> with an empty <see cref="StickyNote"/>
        /// </summary>
        public NoteWindowViewModel()
        {
            _note = new StickyNote();

            InitCommands();
        }

        /// <summary>
        /// Construct <see cref="NoteWindowViewModel"/> with specific <see cref="StickyNote"/>
        /// </summary>
        /// <param name="note"></param>
        public NoteWindowViewModel(StickyNote note)
        {
            _note = note;

            InitCommands();
        }

        private void InitCommands()
        {
            ToggleFixedCommand = new RelayCommand(ToggleFixed);
        }
        #endregion


        #region Field
        /// <summary>
        /// private member of <see cref="StickyNote"/> shown by this window
        /// </summary>
        StickyNote _note;
        bool _isFixed = false;
        double _opacity = 1;
        #endregion


        #region Property
        /// <summary>
        /// Get/Set the <see cref="StickyNote.Title">Title</see> of StickyNote
        /// </summary>
        public string Title
        {
            get => _note.Title;
            set
            {
                _note.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        /// <summary>
        /// Get/Set the <see cref="StickyNote.TextContent">TextContent</see> of StickyNote
        /// </summary>
        public string TextContent
        {
            get => _note.TextContent;
            set
            {
                _note.TextContent = value;
                OnPropertyChanged(nameof(TextContent));
            }
        }
        /// <summary>
        /// Access the <see cref="StickyNote"/> shown by this window
        /// </summary>
        public StickyNote Note { get => _note; }
        /// <summary>
        /// Get/Set whether the note window is fixed
        /// </summary>
        public bool IsFixed
        {
            get => _isFixed;
            set
            {
                _isFixed = value;
                OnPropertyChanged(nameof(IsFixed));
            }
        }
        /// <summary>
        /// Get/Set the Opacity of note window
        /// <para>* Opacity should be in range 0~1</para>
        /// </summary>
        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
        }

        /// <summary>
        /// Command to toggle <see cref="IsFixed">IsFixed</see> property of NoteWindowViewModel
        /// </summary>
        public ICommand ToggleFixedCommand { get; private set; }
        #endregion


        #region Command Method
        void ToggleFixed(object? param)
        {
            IsFixed = !IsFixed;
        }
        #endregion
    }
}
