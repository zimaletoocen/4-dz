using System;
using System.Reflection.Emit;

namespace LABAKOTORAYAMENYAUBILA
{
    class pomogite
    {
        static void Main(string[] args)
        {
            // Задача 1: Вывести массив из 20 случайных чисел и поменять местами два числа.
            Console.WriteLine("Задача 1: Массив из 20 случайных чисел.");
            int[] randomArray = GenerateRandomArray(20);
            PrintArray(randomArray);

            Console.WriteLine("Введите индексы двух чисел для обмена (0-19):");
            int index1 = int.Parse(Console.ReadLine());
            int index2 = int.Parse(Console.ReadLine());

            SwapElements(randomArray, index1, index2);
            Console.WriteLine("Массив после обмена:");
            PrintArray(randomArray);

            // Задача 2: Метод для работы с массивом (params).
            Console.WriteLine("\nЗадача 2: Работа с массивом.");
            Console.WriteLine("Введите числа через пробел для создания массива:");
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = Array.ConvertAll(input, int.Parse);

            int sum = CalculateSum(numbers);
            int product = 1;
            double average;
            CalculateProductAndAverage(numbers, ref product, out average);

            Console.WriteLine($"Сумма элементов: {sum}");
            Console.WriteLine($"Произведение элементов: {product}");
            Console.WriteLine($"Среднее арифметическое: {average}");

            // Задача 3: Ввод чисел и рисование цифр или вывод ошибки.
            Console.WriteLine("\nЗадача 3: Ввод чисел и рисование цифр.");
            while (true)
            {
                Console.WriteLine("Введите число от 0 до 9 (или 'exit' для выхода):");
                string inputNumber = Console.ReadLine();

                if (inputNumber.ToLower() == "exit" || inputNumber.ToLower() == "закрыть")
                    break;

                if (int.TryParse(inputNumber, out int number))
                {
                    if (number >= 0 && number <= 9)
                    {
                        DrawNumber(number);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: число должно быть от 0 до 9.");
                        System.Threading.Thread.Sleep(3000);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: введено не число.");
                }
            }

            // Задача 4: Структура Дед.
            Console.WriteLine("\nЗадача 4: Структура Дед.");
            Grandpa[] grandpas = new Grandpa[5]
            {
                new Grandpa("Дедушка 1", Level.Cheerful, new string[] { "Гады!", "Проклятые!" }),
                new Grandpa("Дедушка 2", Level.Grumpy, new string[] { "Черт побери!", "Проститутки!" }),
                new Grandpa("Дедушка 3", Level.Cheerful, new string[] { "Эх!", "Как же тяжело!" }),
                new Grandpa("Дедушка 4", Level.Grumpy, new string[] { "Гадость!", "Негодяи!" }),
                new Grandpa("Дедушка 5", Level.Cheerful, new string[] { "Ох!", "Вот беда!" })
            };

            foreach (var grandpa in grandpas)
            {
                Console.WriteLine($"{grandpa.Name} говорит:");
                int bruises = grandpa.CheckForBadWords("гадость", "проклятые", "черт");
                Console.WriteLine($"Количество синяков у {grandpa.Name}: {bruises}");
            }
        }

        // Задача 1: Генерация массива случайных чисел.
        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1, 100); // Случайные числа от 1 до 99
            }
            return array;
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        static void SwapElements(int[] array, int index1, int index2)
        {
            if (index1 < array.Length && index2 < array.Length)
            {
                int temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
            }
        }

        // Задача 2: Метод для работы с массивом.
        static int CalculateSum(params int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
                sum += num;
            return sum;
        }

        static void CalculateProductAndAverage(int[] numbers, ref int product, out double average)
        {
            product = 1;
            double sum = 0;

            foreach (var num in numbers)
            {
                product *= num;
                sum += num;
            }

            average = sum / numbers.Length;
        }

        // Задача 3: Рисование цифр.
        static void DrawNumber(int number)
        {
            string[] digits = new string[]
            {
                "###\n# #\n# #\n# #\n###", // 0
                "  #\n  #\n  #\n  #\n  #", // 1
                "###\n  #\n###\n#  \n###", // 2
                "###\n  #\n###\n  #\n###", // 3
                "# #\n# #\n###\n  #\n  #", // 4
                "###\n#  \n###\n  #\n###", // 5
                "###\n#  \n###\n# #\n###", // 6
                "###\n  #\n  #\n  #\n  #", // 7
                "###\n# #\n###\n# #\n###", // 8
                "###\n# #\n###\n  #\n###"  // 9
            };

            Console.WriteLine(digits[number]);
        }

        // Задача 4: Структура Дед.
        enum Level { Cheerful, Grumpy }

        struct Grandpa
        {
            public string Name;
            public Level MoodLevel;
            public string[] BadWords;
            public int Bruises;

            public Grandpa(string name, Level moodLevel, string[] badWords)
            {
                Name = name;
                MoodLevel = moodLevel;
                BadWords = badWords;
                Bruises = 0;
            }

            public int CheckForBadWords(params string[] badWordsToCheck)
            {
                foreach (var badWord in badWordsToCheck)
                {
                    if (Array.Exists(BadWords, word => word.ToLower() == badWord.ToLower()))
                    {
                        Bruises++;
                    }
                }
                return Bruises;
            }
        }
    }
}
