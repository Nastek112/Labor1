using System;
using System.Collections.Generic;

namespace MobileApp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var a = new List<mobile_dev>();

            while (true)
            {
                Console.Write(
                    "\nВаш выбор:\n" +
                    "1 — ввод техники (базовый класс)\n" +
                    "2 — ввод смартфона\n" +
                    "3 — ввод электронной книги\n" +
                    "4 — вывод всех устройств\n" +
                    "0 — выход\n> "
                );

                int action = -1;
                {
                    string menu = io.read_line("");
                    if (!io.parse_int(menu, out action))
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        continue;
                    }
                }
                if (action == 0) break;

                switch (action)
                {
                    case 1:
                        {
                            string firm = io.read_line("Фирма: ");
                            int bat = io.read_int_in_range(
                                $"Ёмкость батареи (мА·ч, {mobile_dev.MinBat}..{mobile_dev.MaxBat}): ",
                                mobile_dev.MinBat, mobile_dev.MaxBat);
                            double sz = io.read_double_in_range(
                                $"Размер экрана (дюймы, {mobile_dev.MinSize}..{mobile_dev.MaxSize}): ",
                                mobile_dev.MinSize, mobile_dev.MaxSize);

                            a.Add(new mobile_dev(firm, bat, sz));
                            break;
                        }
                    case 2:
                        {
                            string firm = io.read_line("Фирма: ");
                            int bat = io.read_int_in_range(
                                $"Ёмкость батареи (мА·ч, {mobile_dev.MinBat}..{mobile_dev.MaxBat}): ",
                                mobile_dev.MinBat, mobile_dev.MaxBat);
                            double sz = io.read_double_in_range(
                                $"Размер экрана (дюймы, {mobile_dev.MinSize}..{mobile_dev.MaxSize}): ",
                                mobile_dev.MinSize, mobile_dev.MaxSize);
                            int ram = io.read_int_in_range(
                                $"Оперативная память (ГБ, {Smart.MinRam}..{Smart.MaxRam}): ",
                                Smart.MinRam, Smart.MaxRam);

                            a.Add(new Smart(ram, firm, bat, sz));
                            break;
                        }
                    case 3:
                        {
                            string firm = io.read_line("Фирма: ");
                            int bat = io.read_int_in_range(
                                $"Ёмкость батареи (мА·ч, {mobile_dev.MinBat}..{mobile_dev.MaxBat}): ",
                                mobile_dev.MinBat, mobile_dev.MaxBat);
                            double sz = io.read_double_in_range(
                                $"Размер экрана (дюймы, {mobile_dev.MinSize}..{mobile_dev.MaxSize}): ",
                                mobile_dev.MinSize, mobile_dev.MaxSize);
                            int bl = io.read_int_in_range("Подсветка (0 — нет, 1 — есть): ", 0, 1);

                            a.Add(new Ebook(bl != 0, firm, bat, sz));
                            break;
                        }
                    case 4:
                        {
                            if (a.Count == 0)
                            {
                                Console.WriteLine("Список пуст.");
                            }
                            else
                            {
                                foreach (var item in a)
                                {
                                    item.print();   // полиморфный вызов
                                    Console.WriteLine();
                                }
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}
