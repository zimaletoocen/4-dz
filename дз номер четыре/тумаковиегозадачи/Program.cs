using System;

class Program
{
    static void Main()
    {
        // Упражнение 5.1: Метод, возвращающий наибольшее из двух чисел.
        Console.WriteLine("Упражнение 5.1: Найти наибольшее из двух чисел.");
        Console.Write("Введите первое число: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int secondNumber = int.Parse(Console.ReadLine());

        int maxNumber = GetMax(firstNumber, secondNumber);
        Console.WriteLine($"Наибольшее число: {maxNumber}");

        // Упражнение 5.2: Метод, меняющий местами значения двух параметров.
        Console.WriteLine("\nУпражнение 5.2: Поменять местами два числа.");
        Console.Write("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());

        Swap(ref a, ref b);
        Console.WriteLine($"После обмена: a = {a}, b = {b}");

        // Упражнение 5.3: Метод вычисления факториала с проверкой на переполнение.
        Console.WriteLine("\nУпражнение 5.3: Вычисление факториала.");
        Console.Write("Введите число для вычисления факториала: ");
        int factorialInput = int.Parse(Console.ReadLine());
        bool isSuccess = TryCalculateFactorial(factorialInput, out long factorialResult);

        if (isSuccess)
        {
            Console.WriteLine($"Факториал {factorialInput} = {factorialResult}");
        }
        else
        {
            Console.WriteLine("Произошло переполнение при вычислении факториала.");
        }

        // Упражнение 5.4: Рекурсивный метод вычисления факториала.
        Console.WriteLine("\nУпражнение 5.4: Рекурсивное вычисление факториала.");
        Console.Write("Введите число для рекурсивного вычисления факториала: ");
        int recursiveInput = int.Parse(Console.ReadLine());
        long recursiveFactorialResult = RecursiveFactorial(recursiveInput);
        Console.WriteLine($"Рекурсивный факториал {recursiveInput} = {recursiveFactorialResult}");

        // Домашнее задание 5.1: НОД двух и трех натуральных чисел.
        Console.WriteLine("\nДомашнее задание 5.1: Вычисление НОД.");
        Console.Write("Введите первое натуральное число: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Введите второе натуральное число: ");
        int num2 = int.Parse(Console.ReadLine());

        int gcdTwo = GCD(num1, num2);
        Console.WriteLine($"НОД({num1}, {num2}) = {gcdTwo}");

        Console.Write("Введите третье натуральное число (или 0 для пропуска): ");
        int num3 = int.Parse(Console.ReadLine());

        if (num3 != 0)
        {
            int gcdThree = GCD(num1, num2, num3);
            Console.WriteLine($"НОД({num1}, {num2}, {num3}) = {gcdThree}");
        }

        // Домашнее задание 5.2: Рекурсивный метод для вычисления n-го числа Фибоначчи.
        Console.WriteLine("\nДомашнее задание 5.2: Вычисление n-го числа Фибоначчи.");
        Console.Write("Введите номер числа Фибоначчи (n): ");
        int fibonacciIndex = int.Parse(Console.ReadLine());

        long fibonacciResult = Fibonacci(fibonacciIndex);
        Console.WriteLine($"F({fibonacciIndex}) = {fibonacciResult}");
    }

    // Упражнение 5.1
    static int GetMax(int a, int b)
    {
        return a > b ? a : b;
    }

    // Упражнение 5.2
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Упражнение 5.3
    static bool TryCalculateFactorial(int number, out long result)
    {
        result = 1;

        try
        {
            checked
            {
                for (int i = 2; i <= number; i++)
                {
                    result *= i;
                }
            }
            return true;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    // Упражнение 5.4
    static long RecursiveFactorial(int number)
    {
        if (number <= 1) return 1;

        return number * RecursiveFactorial(number - 1);
    }

    // Домашнее задание 5.1 (двух чисел)
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Домашнее задание 5.1 (трех чисел)
    static int GCD(int a, int b, int c)
    {
        return GCD(GCD(a, b), c);
    }

    // Домашнее задание 5.2
    static long Fibonacci(int n)
    {
        if (n <= 0) return 0;
        if (n == 1 || n == 2) return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
