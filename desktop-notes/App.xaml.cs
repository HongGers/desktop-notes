using desktop_notes.Model;
using desktop_notes.ViewModel;
using desktop_notes.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace desktop_notes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            try
            {
                //prepare MainWindow and MainWindowViewModel
                MainWindow startupWindow = new MainWindow();
                MainWindowViewModel mainWindowViewModel = MainWindowViewModel.GlobalViewModel;
                mainWindowViewModel.Title = "Desktop Sticky Notes";
                startupWindow.DataContext = mainWindowViewModel;

                startupWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
