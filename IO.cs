using System;
using System.Globalization;
using System.Text;

namespace MobileApp
{
    public static class io
    {
        public static string read_line(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static bool parse_int(string s, out int value)
        {
            value = 0;
            var filtered = new StringBuilder();
            bool hasSign = false;

            foreach (char c in s)
            {
                if ((c == '+' || c == '-') && !hasSign && filtered.Length == 0)
                {
                    filtered.Append(c);
                    hasSign = true;
                    continue;
                }
                if (c >= '0' && c <= '9')
                {
                    filtered.Append(c);
                }
            }

            string f = filtered.ToString();
            if (string.IsNullOrEmpty(f) || f == "+" || f == "-") return false;

            if (long.TryParse(f, NumberStyles.Integer, CultureInfo.InvariantCulture, out long v))
            {
                if (v < int.MinValue || v > int.MaxValue) return false;
                value = (int)v;
                return true;
            }
            return false;
        }

        public static bool parse_double(string s, out double value)
        {
            value = 0.0;
            if (string.IsNullOrWhiteSpace(s)) return false;

            // 1) нормализуем запятую в точку и обрежем пробелы по краям
            s = s.Trim().Replace(',', '.');

            // 2) фильтруем строку. один знак в начале, одна точка, остальные цифры
            var filtered = new StringBuilder();
            bool hasSign = false, hasDot = false;

            foreach (char c in s)
            {
                if ((c == '+' || c == '-') && !hasSign && filtered.Length == 0)
                {
                    filtered.Append(c);
                    hasSign = true;
                    continue;
                }
                if (c == '.' && !hasDot)
                {
                    filtered.Append('.');
                    hasDot = true;
                    continue;
                }
                if (c >= '0' && c <= '9')
                {
                    filtered.Append(c);
                }
            }

            string f = filtered.ToString();
            if (string.IsNullOrEmpty(f) || f == "+" || f == "-" || f == "." || f == "+." || f == "-.")
                return false;

            // 3) парсим в инвариантной культуре (ждём точку)
            return double.TryParse(f, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }


        public static int read_int_in_range(string prompt, int lo, int hi)
        {
            while (true)
            {
                string s = read_line(prompt);
                if (parse_int(s, out int v) && v >= lo && v <= hi) return v;
                Console.WriteLine($"Введите целое число в диапазоне [{lo}..{hi}]");
            }
        }

        public static double read_double_in_range(string prompt, double lo, double hi)
        {
            while (true)
            {
                string s = read_line(prompt);
                if (parse_double(s, out double v) && v >= lo && v <= hi) return v;
                Console.WriteLine($"Введите число (можно с точкой/запятой) в диапазоне [{lo}..{hi}]");
            }
        }
    }
}
