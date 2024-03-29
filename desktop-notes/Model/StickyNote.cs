﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktop_notes.Model
{
    /// <summary>
    /// Represent a StickyNote that can stick on screen
    /// </summary>
    public class StickyNote : ModelBase
    {
        #region Constructor
        /// <summary>
        /// Construct an empty <see cref="StickyNote"/>
        /// </summary>
        public StickyNote()
        {
            Title = "";
            TextContent = "";
        }
        /// <summary>
        /// Construct a <see cref="StickyNote"/> with Title
        /// </summary>
        /// <param name="title"></param>
        public StickyNote(string title)
        {
            Title = title;
            TextContent = "";
        }
        /// <summary>
        /// Construct a <see cref="StickyNote"/> with Title and Content
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public StickyNote(string title, string content)
        {
            Title = title;
            TextContent = content;
        }
        #endregion


        #region Field
        string _title;
        string _textContent;
        #endregion


        #region Property
        /// <summary>
        /// Access Title of StickyNote
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
        /// Access Content of StickyNote
        /// </summary>
        public string TextContent
        {
            get => _textContent;
            set
            {
                _textContent = value;
                OnPropertyChanged(nameof(TextContent));
            }
        }
        #endregion
    }
}
