using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktop_notes.Model
{
    public class StickyNote
    {
        #region Constructor
        public StickyNote()
        {
            Title = "";
            TextContent = "";
        }

        public StickyNote(string title)
        {
            Title = title;
            TextContent = "";
        }

        public StickyNote(string title, string content)
        {
            Title = title;
            TextContent = content;
        }
        #endregion


        #region Property
        public string Title { get; set; }

        public string TextContent { get; set; }
        #endregion
    }
}
