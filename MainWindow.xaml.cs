using System;
using System.Windows;

namespace ExceptionExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка на пустые поля
                if (string.IsNullOrEmpty(UsernameTextBox.Text) || string.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    throw new ArgumentException("Логин и пароль не могут быть пустыми.");
                }

                // Проверка на корректность данных (пример: логин должен быть длиннее 3 символов)
                if (UsernameTextBox.Text.Length < 3)
                {
                    throw new ArgumentException("Логин должен содержать не менее 3 символов.");
                }

                // Если все проверки пройдены, выполняем вход
                MessageBox.Show("Вход выполнен успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                // Обработка исключения и вывод сообщения пользователю
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Обработка других исключений
                MessageBox.Show("Произошла непредвиденная ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}