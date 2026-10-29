using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Random rnd = new Random();  // Створюємо всі об'єкти один раз
            Service service = new Service();
            Vector vector = new Vector();
            Matrix matrix = new Matrix();

            service.RunMenu(vector, matrix, rnd);// Запускаємо меню
        }
    }
}