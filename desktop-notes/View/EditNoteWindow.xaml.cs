﻿using System;
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
using System.Windows.Shapes;
using desktop_notes.Model;

namespace desktop_notes.View
{
    /// <summary>
    /// Window to add a new <see cref="StickyNote"/>
    /// </summary>
    public partial class EditNoteWindow : Window
    {
        public EditNoteWindow()
        {
            InitializeComponent();
        }

        private void HandleCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void HandleConfirm(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
