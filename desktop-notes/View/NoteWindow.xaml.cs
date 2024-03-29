﻿using System;
using System.Collections.Generic;
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
using desktop_notes.ViewModel;

namespace desktop_notes.View
{
    /// <summary>
    /// Window to display a <see cref="StickyNote"/>
    /// </summary>
    public partial class NoteWindow : Window
    {
        #region Constructor
        public NoteWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region Handler
        private void HandleDrag(object sender, MouseButtonEventArgs e)
        {
            NoteWindowViewModel viewModel = (NoteWindowViewModel)DataContext;
            if (!viewModel.IsFixed && e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void HandleClose(object sender, RoutedEventArgs e) => Close();
        #endregion
    }
}
