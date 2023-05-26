// Задание 1
// необходимо реализовать для массива(списка)
// подсчёт количества отрицательных, сумму положительных
// произведение чётных чисел с помощью библиотеки LINQ

// Задание 2
//Запросы:
//На выборку положительных
//На сумму отрицательных
//На количество кратных 5
//Запросы будут обрабатывать массив
//После обработки запросов в массиве удалить все чётные элементы.
//После этого прогнать ещё раз запросы 
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            string a = "";
            while (a != ".")
            {
                a = Console.ReadLine();
                if (a != ".") { nums.Add(int.Parse(a));}
            }
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t Задание № 1");
            Console.WriteLine();
            Console.WriteLine("Текущий массив: [" + String.Join(", ", nums.ToArray()) + "]");
            Console.WriteLine($"Количество отрицательных элементов: {(from p in nums where p < 0 select p).Count()}");
            Console.WriteLine($"Сумма положительных элементов: {(from p in nums where p > 0 select p).Sum()}");
            try
            {
                Console.WriteLine($"Произведение чётных элементов: {(from p in nums where p % 2 == 0 select p).Aggregate((x, y) => x * y)}");
            }
            catch
            {
                Console.WriteLine("Четных элементов нет в массиве");
            }
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t Задание № 2");
            for (int i = 0;i < 2; i++)
            {
                var posNums = from n in nums
                              where n > 0
                              select n;
                int sum_minus = nums.Where(p => p < 0).Sum();
                int cnt_del5 = nums.Count(p => p % 5 == 0);
                Console.WriteLine();
                Console.WriteLine("Текущий массив: [" + String.Join(", ", nums.ToArray()) + "]");
                Console.WriteLine("Положительные элементы: [" + String.Join(", ", posNums.ToArray()) + "]");
                Console.WriteLine($"Сумма отрицательных: {sum_minus}");
                Console.WriteLine($"Количество элементов кратных 5: {cnt_del5}");
                nums = (from n in nums
                       where n % 2 != 0
                       select n).ToList();
            }
        }
    }
}
