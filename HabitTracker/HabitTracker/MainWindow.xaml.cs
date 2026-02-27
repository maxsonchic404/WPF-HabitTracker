using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace HabitTracker
{
    /// <summary>Статистика.</summary>
    public class DailyStat { public string Day { get; set; } public int Completed { get; set; } }
    
    /// <summary>Привычка.</summary>
    public class Habit { public string Name { get; set; } public bool IsCompleted { get; set; } }

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

            HabitsDataGrid.ItemsSource = HabitsList;
            HabitCalendar.SelectedDate = DateTime.Now;

            StatsList.Add(new DailyStat { Day = "Понедельник", Completed = 3 });
            StatsList.Add(new DailyStat { Day = "Вторник", Completed = 5 });

            StatsListView.ItemsSource = StatsList;
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

        public ObservableCollection<Habit> HabitsList { get; set; } = new ObservableCollection<Habit>();

        // В конструкторе MainWindow(), сразу после InitializeComponent() добавьте:
        // HabitsDataGrid.ItemsSource = HabitsList; HabitCalendar.SelectedDate = DateTime.Now;

        /// <summary>Добавить привычку.</summary>
        private void AddHabit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewHabitTextBox.Text))
                HabitsList.Add(new Habit { Name = NewHabitTextBox.Text });
        }

        /// <summary>Слайдер.</summary>
        private void Sliders_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DayProgressBar != null) DayProgressBar.Value = ProductivitySlider.Value;
        }

        /// <summary>Кнопка повтора.</summary>
        private void RepeatButton_Click(object sender, RoutedEventArgs e) { ProductivitySlider.Value += 5; }

        public ObservableCollection<DailyStat> StatsList { get; set; } = new ObservableCollection<DailyStat>();
    }
}
