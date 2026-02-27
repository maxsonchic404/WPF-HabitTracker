using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HabitTracker
{
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

        /// <summary>
        /// ToggleButton "Режим редактирования" (пока заглушка).
        /// </summary>
        private void EditModeToggle_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Режим редактирования (панель появится позже).");
        }
    }
}
