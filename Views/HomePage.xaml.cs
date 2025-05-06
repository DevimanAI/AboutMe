using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AboutMe.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void NavigateToPage(UserControl page)
        {
            // Find the MainWindow
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                // Access the MainFrame and navigate
                mainWindow.NavigateWithAnimation(page);
            }
        }

        private void HomeImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Potentially refresh or do nothing if already on home, or navigate to a fresh instance
            // For now, let's assume it navigates to a new instance of HomePage or reloads current.
            // If MainWindow handles current page state, this might just call a method on MainWindow.
            // For simplicity, we'll navigate to a new HomePage instance.
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null) mainWindow.HomeButton_Click(sender, e); // Reuse existing logic if suitable
        }

        private void AboutImageButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null) mainWindow.AboutMeButton_Click(sender, e); // Reuse existing logic
        }

        private void ProjectsImageButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null) mainWindow.ProjectsButton_Click(sender, e); // Reuse existing logic
        }

        private void ContactImageButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null) mainWindow.ContactButton_Click(sender, e); // Reuse existing logic
        }
    }
}