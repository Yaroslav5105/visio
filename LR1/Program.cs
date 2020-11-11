using System;
using static System.Console;
using static System.ConsoleKey;
using static System.Convert;

namespace LR1
{
    public class Program
    {
        private static int _counter = 0;

        public static void Main(string[] args)
        {
            WriteLine("     Вычисляем вариант № 15  ");
            WriteLine("        c * Math.tan(b+23))  ");
            WriteLine(" y = ------------------------------");
            WriteLine("               a/2 - 4*d           ");

#if DEBUG
            WriteLine(" ===================== Работает режим Debug =====================");
#endif

            var keyInfo = new ConsoleKeyInfo();

            do
            {
                WriteLine($"-------Тест № {++_counter}--------");

                try
                {
                    WriteLine($"Введите значение переменной A типа {typeof(float).FullName} ===> ");
                    var a = ToSingle(ReadLine());

                    WriteLine($"Введите значение переменной B типа {typeof(double).FullName} ===> ");
                    var b = ToDouble(ReadLine());


                    WriteLine($"Введите значение переменной C типа {typeof(int).Name} ===> ");
                    var c = ToInt32(ReadLine());

                    WriteLine($"Введите значение переменной D типа {typeof(double).Name} ===> ");
                    var d = ToDouble(ReadLine());


                    var calculator = new Calculator(a, b, c, d);
                    keyInfo = calculator.Show();
                }
                catch (FormatException)
                {
                    WriteLine("Вы ввели не корректное значение!");
                }
            } while (keyInfo.Key != Escape);

            ReadKey();
        }
    }
}