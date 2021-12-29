using System;
using System.Globalization;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int handleNumber;
            Console.WriteLine("Введите номер дескриптора ОС: ");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.HexNumber, CultureInfo.InvariantCulture,
                out handleNumber))
                Console.WriteLine("Ошибка ввода, введите номер дескриптора ОС (формат 1b3): ");
            var osHandle = new OsHandle {Handle = new IntPtr(handleNumber)};
            Console.WriteLine(osHandle.Close() ? "Дескриптор удалось закрыть" : "Дескриптор не удалось закрыть");
            osHandle.Dispose();
        }
    }
}
