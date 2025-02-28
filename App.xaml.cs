using System;
using System.IO;
using System.Windows;

namespace ExceptionExample
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Подписываемся на событие DispatcherUnhandledException
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // Логирование ошибки
            LogError(e.Exception);

            // Обработка исключения
            if (e.Exception is ArgumentException)
            {
                MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка: " + e.Exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Помечаем исключение как обработанное, чтобы предотвратить завершение приложения
            e.Handled = true;
        }

        public void LogError(Exception ex)
        {
            // Путь к файлу логов
            string logFilePath = "error_log.txt";

            // Формируем сообщение об ошибке
            string errorMessage = $"[{DateTime.Now}] Произошла ошибка:\n" +
                                 $"Тип ошибки: {ex.GetType().Name}\n" +
                                 $"Сообщение: {ex.Message}\n" +
                                 $"Стек вызовов:\n{ex.StackTrace}\n\n";

            // Записываем ошибку в файл
            try
            {
                File.AppendAllText(logFilePath, errorMessage);
            }
            catch (Exception logEx)
            {
                // Если не удалось записать в файл, выводим сообщение в консоль
                Console.WriteLine("Не удалось записать ошибку в файл: " + logEx.Message);
            }
        }
    }
}