using desktop_notes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_notes.ViewModel
{
    public class NoteWindowViewModel : ViewModelBase
    {
        #region Constructor
        public NoteWindowViewModel()
        {
            _note = new StickyNote();
        }

        public NoteWindowViewModel(StickyNote note)
        {
            _note = note;
        }
        #endregion


        #region Field
        StickyNote _note;
        #endregion


        #region Property
        public string Title
        {
            get => _note.Title;
            set
            {
                _note.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string TextContent
        {
            get => _note.TextContent;
            set
            {
                _note.TextContent = value;
                OnPropertyChanged(nameof(TextContent));
            }
        }
        public StickyNote Note { get => _note; }
        #endregion
    }
}
