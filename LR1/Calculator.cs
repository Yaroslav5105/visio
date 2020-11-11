using System;
using static System.Console;
using static System.Double;
using static System.Math;

namespace LR1
{
    /// <summary>
    ///     Класс для вычисления арифметического выражения
    /// </summary>
    public class Calculator
    {
        //Описания входных данных закрытые члены класса
        private readonly float A;
        private readonly double B;
        private readonly int C;
        private readonly double D;

        /// <summary>
        ///     Инициализация входных данных через конструктор
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public Calculator(float a, double b, int c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
#if DEBUG
            WriteLine("Создаю члены класса");
#endif
        }


        /// <summary>
        ///     Финализатор
        /// </summary>
        ~Calculator()
        {
#if DEBUG
            WriteLine("Уничтожаю члены класса");
#endif
        }

        /// <summary>
        ///     Интерфейс класса для вывода результатов вычисления
        /// </summary>
        /// <returns></returns>
        public ConsoleKeyInfo Show()
        {
            // Начало блока слежения за ошибками
            try
            {
                var result = Calculate(); // получаем результат вычисления и выводим
                WriteLine($"Результат = {result:F}");
                WriteLine("Нажмите любую клавишу для продолжения или ESC для выхода");
            } //Перехватываем все возможные исключения и выводим сообщение об ошибке
            catch (OverflowException overflowException)
            {
                WriteLine(overflowException.Message);
            }
            catch (DivideByZeroException divideByZeroException)
            {
                WriteLine(divideByZeroException.Message);
            }
            catch (NotFiniteNumberException notFiniteNumberException)
            {
                WriteLine(notFiniteNumberException.Message);
            }
            catch (ArithmeticException arithmeticException)
            {
                WriteLine(arithmeticException.Message);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            return ReadKey();
        }

        //Публичный метод для вычисления арифметического уравнения
        private double Calculate()
        {
            // Выводим данные введенные пользователем
            WriteLine($"a = {A} b = {B} c = {C} d = {D} ");


            if (C <= 0) throw new ArithmeticException("Нельзя вычислить корень из отрицательного числа!");

            //Вычисляем числитель
            var top = C * Math.Tan(B + 23);

            // Обрабабатываем ситуацию переполнения типа
            if (Abs(top) > MaxValue)
                throw new OverflowException("Числитель превышает диапазон double!");

            if (IsNaN(top))
                throw new ArithmeticException("Ошибка в результате числитель не число!");

            if (IsInfinity(top))
                throw new NotFiniteNumberException("Ошибка в результате числитель равен бесконечности");

            //В режиме отладки выводим результат промежуточных вычислений
#if DEBUG
            WriteLine($"Числитель = {top:F}");
#endif

            //Вычисляем знаменатель
            var bottom = A/2 - 4*D -1            ;

            //Обрабатываем ситуацию деления на 0
            if (bottom == 0)
                throw new DivideByZeroException("Ошибка! Попытка деления на 0 ");

            if (Abs(bottom) > MaxValue)
                throw new OverflowException("Знаменатель превышает диапазон double!");

            if (IsNaN(bottom))
                throw new ArithmeticException("Ошибка в результате знаменатель не число!");

            if (IsInfinity(bottom))
                throw new NotFiniteNumberException("Ошибка в результате знаменатель равен бесконечности");

#if DEBUG
            WriteLine($"Знаменатель = {bottom:F}");
#endif

            return top / bottom;
        }
    }
}