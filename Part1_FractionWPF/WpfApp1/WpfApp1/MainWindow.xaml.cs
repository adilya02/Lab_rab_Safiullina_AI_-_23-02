using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StatusTextBlock.Content = "Готов к работе. Введите значения числителя и знаменателя.";
        }

        // Обработчик для вычисления процентов
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    int numerator = int.Parse(NumeratorTextBox.Text);
                    int denominator = int.Parse(DenominatorTextBox.Text);

                    Fraction fraction = new Fraction(numerator, denominator);

                    if (!fraction.IsProperFraction())
                    {
                        ResultTextBlock.Text = "Внимание: дробь неправильная (числитель ≥ знаменателя)!\n\n" +
                                             "Рекомендуется использовать правильную дробь (числитель < знаменателя).\n" +
                                             "Результат может быть некорректным.";
                    }
                    else
                    {
                        ResultTextBlock.Text = "";
                    }

                    double percentage = fraction.ToPercentage();
                    ResultTextBlock.Text += $"\nДробь {fraction} составляет {percentage:F2}% от целого";
                    StatusTextBlock.Content = "Проценты вычислены успешно";
                }
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
                StatusTextBlock.Content = "Произошла ошибка при вычислении";
            }
        }

        // Обработчик для вычисления суммы цифр знаменателя
        private void DigitSumButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInput(true)) // true - для проверки только знаменателя
                {
                    int denominator = int.Parse(DenominatorTextBox.Text);
                    Fraction fraction = new Fraction(0, denominator);

                    int digitSum = fraction.DenominatorDigitSum();
                    ResultTextBlock.Text = $"Сумма цифр знаменателя {denominator} равна {digitSum}";
                    StatusTextBlock.Content = "Сумма цифр вычислена успешно";
                }
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
                StatusTextBlock.Content = "Произошла ошибка при вычислении";
            }
        }

        // Валидация ввода числителя - только цифры
        private void NumeratorTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        // Валидация ввода знаменателя - только цифры
        private void DenominatorTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        // Обработчик для клавиш
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Разрешаем служебные клавиши
            if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Left ||
                e.Key == Key.Right || e.Key == Key.Tab)
            {
                return;
            }

            // Запрещаем пробел
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        // Проверка, что текст содержит только цифры
        private bool IsTextAllowed(string text)
        {
            return Regex.IsMatch(text, "^[0-9]+$");
        }

        // Проверка корректности введенных данных
        private bool ValidateInput(bool denominatorOnly = false)
        {
            if (denominatorOnly)
            {
                if (string.IsNullOrWhiteSpace(DenominatorTextBox.Text))
                {
                    ResultTextBlock.Text = "Ошибка: введите значение знаменателя";
                    return false;
                }

                if (!int.TryParse(DenominatorTextBox.Text, out int denominator))
                {
                    ResultTextBlock.Text = "Ошибка: знаменатель должен быть целым числом";
                    return false;
                }

                if (denominator == 0)
                {
                    ResultTextBlock.Text = "Ошибка: знаменатель не может быть равен 0";
                    return false;
                }

                return true;
            }

            // Полная проверка для обоих полей
            if (string.IsNullOrWhiteSpace(NumeratorTextBox.Text) ||
                string.IsNullOrWhiteSpace(DenominatorTextBox.Text))
            {
                ResultTextBlock.Text = "Ошибка: заполните все поля";
                return false;
            }

            if (!int.TryParse(NumeratorTextBox.Text, out int numerator) ||
                !int.TryParse(DenominatorTextBox.Text, out int denom))
            {
                ResultTextBlock.Text = "Ошибка: введите целые числа";
                return false;
            }

            if (denom == 0)
            {
                ResultTextBlock.Text = "Ошибка: знаменатель не может быть равен 0";
                return false;
            }

            if (numerator < 0)
            {
                ResultTextBlock.Text = "Ошибка: числитель должен быть неотрицательным";
                return false;
            }

            return true;
        }
    }
}