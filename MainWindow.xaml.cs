using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation; // Add this for animations
using System.Windows.Input; // Add this for MouseButtonEventArgs
using System; // Add this for Uri
using AboutMe.Views; // Add this using statement

namespace AboutMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Navigate to HomePage on startup
            MainFrame.Navigate(new HomePage());
        }

        // Allow window dragging
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // Custom Window Control Buttons
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void NavigateWithAnimation(UserControl page)
        {
            // Prevent navigating to the same page or during an animation  
            if (MainFrame.Content?.GetType() == page.GetType()) return;

            var slideOutAnimation = (Storyboard)FindResource("SlideOutGlitch");
            slideOutAnimation.Completed += new EventHandler((s, e) =>
            {
                MainFrame.Navigate(page);
                var slideInAnimation = (Storyboard)FindResource("SlideInGlitch");
                // Ensure the Completed handler is removed to avoid multiple subscriptions  
                slideOutAnimation.Completed -= new EventHandler((s, e) => { });
                slideInAnimation.Begin(MainFrame);
            });
            slideOutAnimation.Begin(MainFrame);
        }

        public void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateWithAnimation(new HomePage());
        }

        public void AboutMeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateWithAnimation(new AboutMePage());
        }

        public void ProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming ProjectsPage exists or create it
            NavigateWithAnimation(new ProjectsPage()); // Use the actual ProjectsPage
            // For now, let's navigate back home if ProjectsPage doesn't exist
             // NavigateWithAnimation(new HomePage()); // Placeholder removed
        }

        public void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming ContactPage exists or create it
            NavigateWithAnimation(new ContactPage()); // Use the actual ContactPage
            // For now, let's navigate back home if ContactPage doesn't exist
             // NavigateWithAnimation(new HomePage()); // Placeholder removed
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}