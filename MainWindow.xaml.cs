using System;
using System.Windows;
using System.Windows.Input;

namespace Lab4
{
    public partial class MainWindow : Window
    {
        private Time time1, time2;

        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов XAML
        }

        // Обработчик нажатия кнопки для выполнения операций
        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсинг первого времени из текстовых полей
                byte hours1 = byte.Parse(txtHours1.Text);
                byte minutes1 = byte.Parse(txtMinutes1.Text);
                time1 = new Time(hours1, minutes1);

                // Если выбрана операция сравнения или вычитания, парсим второе время
                if (cmbOperation.SelectedIndex == 2 ||
                    cmbOperation.SelectedIndex == 3 ||
                    cmbOperation.SelectedIndex == 4)
                {
                    byte hours2 = byte.Parse(txtHours2.Text);
                    byte minutes2 = byte.Parse(txtMinutes2.Text);
                    time2 = new Time(hours2, minutes2);
                }

                // Выполняем выбранную операцию и выводим результат
                txtResult.Text = PerformOperation(time1, time2, cmbOperation.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Метод для выполнения выбранной операции с временем
        private string PerformOperation(Time time1, Time time2, int operation)
        {
            switch (operation)
            {
                case 0: // Инкремент (добавить минуту)
                    var inc = new Time(time1.Hours, time1.Minutes);
                    inc++;
                    return $"{time1}++ = {inc}";

                case 1: // Декремент (вычесть минуту)
                    var dec = new Time(time1.Hours, time1.Minutes);
                    dec--;
                    return $"{time1}-- = {dec}";
                case 2:
                    // Сравнение "меньше"
                    return $"{time1} < {time2} = {time1 < time2}";
                case 3:
                    // Сравнение "больше"
                    return $"{time1} > {time2} = {time1 > time2}";
                case 4:
                    // Вычитание времени
                    return $"{time1} - {time2} = {time1 - time2}";
                case 5:
                    // Приведение времени к целому числу (в минутах)
                    return $"{(int)time1} минут";
                case 6:
                    // Приведение времени к логическому значению (true, если время не 00:00)
                    return $"{(bool)time1} (Не 00:00)";
                default:
                    return "Ошибка операции"; // сообщение об ошибке при некорректной операции
            }
        }

        // разрешаем только цифры
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}