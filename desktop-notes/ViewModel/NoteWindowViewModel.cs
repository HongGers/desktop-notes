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
        }

        /// <summary>
        /// Construct <see cref="NoteWindowViewModel"/> with specific <see cref="StickyNote"/>
        /// </summary>
        /// <param name="note"></param>
        public NoteWindowViewModel(StickyNote note)
        {
            _note = note;
        }
        #endregion


        #region Field
        /// <summary>
        /// private member of <see cref="StickyNote"/> shown by this window
        /// </summary>
        StickyNote _note;
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
        #endregion
    }
}
