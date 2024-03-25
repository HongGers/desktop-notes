using desktop_notes.Model;
using desktop_notes.View;
using desktop_notes.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace desktop_notes.ViewModel
{
    /// <summary>
    /// View Model for <see cref="EditNoteWindow"/>
    /// </summary>
    public class EditNoteWindowViewModel : ViewModelBase
    {
        #region Constructor
        /// <summary>
        /// Default constructor of AddNoteWindowViewModel
        /// </summary>
        public EditNoteWindowViewModel()
        {
            _note = new StickyNote();
        }

        /// <summary>
        /// Construct with an existing note.
        /// </summary>
        /// <param name="note"></param>
        public EditNoteWindowViewModel(StickyNote note)
        {
            _note = note;
        }
        #endregion


        #region Field
        /// <summary>
        /// <see cref="StickyNote"/> shown by this window
        /// </summary>
        StickyNote _note;
        #endregion


        #region Property
        /// <summary>
        /// Get/Set the <see cref="StickyNote.Title">Title</see> of <see cref="StickyNote"/>
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
        /// Get/Set the <see cref="StickyNote.TExtContet"/> of <see cref="StickyNote"/>
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
        #endregion
    }
}
