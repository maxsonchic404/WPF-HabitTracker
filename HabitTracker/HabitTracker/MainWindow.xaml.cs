using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HabitTracker
{
    /// <summary>Данные пользователя.</summary>
    public class UserProfile { public string FirstName { get; set; } public string LastName { get; set; } }

    /// <summary>
    /// Главное окно приложения.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Пункт меню "Сохранить".
        /// </summary>
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция сохранения файла...", "Файл");
        }

        /// <summary>
        /// Пункт меню "Загрузить".
        /// </summary>
        private void MenuLoad_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция загрузки файла...", "Файл");
        }

        /// <summary>
        /// Пункт меню "Выход".
        /// </summary>
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Светлая тема.
        /// </summary>
        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            Background = Brushes.White;
        }

        /// <summary>
        /// Темная тема.
        /// </summary>
        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            Background = Brushes.LightGray;
        }

        /// <summary>Смена вкладок.</summary>
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl && StatusText != null)
                if (MainTabControl.SelectedItem is TabItem tab)
                    StatusText.Text = $"Текущий раздел: {tab.Header}";
        }

        /// <summary>Показ доп панели.</summary>
        private void EditModeToggle_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeToggle.IsChecked == true)
            {
                ExtraPanel.Visibility = Visibility.Visible;
                ExtraPanelColumn.Width = new GridLength(220);
            }
            else
            {
                ExtraPanel.Visibility = Visibility.Collapsed;
                ExtraPanelColumn.Width = new GridLength(0);
            }
        }
        private UserProfile _currentUser = new UserProfile();

        /// <summary>Фото.</summary>
        private void LoadAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog { Filter = "Image Files|*.jpg;*.png" };
            if (dlg.ShowDialog() == true) AvatarImage.Source = new BitmapImage(new Uri(dlg.FileName));
        }

        /// <summary>Сохранение.</summary>
        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text)) { MessageBox.Show("Введите имя!"); return; }
            _currentUser.FirstName = FirstNameTextBox.Text;
            MessageBox.Show("Сохранено!");
        }

        /// <summary>Сброс.</summary>
        private void ResetProfile_Click(object sender, RoutedEventArgs e) { FirstNameTextBox.Clear(); }

    }
}
