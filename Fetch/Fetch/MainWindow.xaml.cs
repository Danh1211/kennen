using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fetch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FetchDataButton_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a valid URL.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                FetchDataButton.IsEnabled = false;
                ClearButton.IsEnabled = false;
                CloseButton.IsEnabled = false;

                string content = await _httpClient.GetStringAsync(url);
                ResultTextBox.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                FetchDataButton.IsEnabled = true;
                ClearButton.IsEnabled = true;
                CloseButton.IsEnabled = true;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UrlTextBox.Clear();
            ResultTextBox.Clear();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}