using desktop_notes.Model;
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
    public class AddNoteWindowViewModel : ViewModelBase
    {
        #region Constructor
        public AddNoteWindowViewModel()
        {
            _note = new StickyNote();
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
