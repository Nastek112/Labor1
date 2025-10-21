using System;
using System.Globalization;

namespace MobileApp
{
    public class mobile_dev
    {
        public const int MinBat = 1000, MaxBat = 11000, DefBat = 5000;
        public const double MinSize = 2.0, MaxSize = 15.0, DefSize = 5.0;

        private string firm_ = "firm";
        private double size_ = DefSize;
        private int bat_capacity_ = DefBat;

        public string Firm
        {
            get => firm_;
            set => firm_ = string.IsNullOrWhiteSpace(value) ? "firm" : value;
        }

        public double Size
        {
            get => size_;
            set => size_ = (value < MinSize || value > MaxSize) ? DefSize : value;
        }

        public int BatCapacity
        {
            get => bat_capacity_;
            set => bat_capacity_ = (value < MinBat || value > MaxBat) ? DefBat : value;
        }

        public mobile_dev() { }
        public mobile_dev(string firm, int bat, double size)
        {
            Firm = firm;
            BatCapacity = bat;
            Size = size;
        }

        public virtual void print()
        {
            Console.Write(
                "\n\nФирма: " + Firm +
                "\nЁмкость батареи: " + BatCapacity + " мА·ч" +
                "\nРазмер экрана: " + Size.ToString("0.0", CultureInfo.InvariantCulture) + "\""
            );
        }
    }

    public class Smart : mobile_dev
    {
        public const int MinRam = 2, MaxRam = 1024, DefRam = 6;
        private int ram_ = DefRam;

        public int RAM
        {
            get => ram_;
            set => ram_ = (value < MinRam || value > MaxRam) ? DefRam : value;
        }

        public Smart() { }
        public Smart(int RAM, string firm, int bat, double size)
            : base(firm, bat, size)
        {
            this.RAM = RAM;
        }

        public override void print()
        {
            base.print();
            Console.Write("\nОперативная память: " + RAM + " ГБ");
        }
    }

    public class Ebook : mobile_dev
    {
        public bool Backlight { get; set; } = false;

        public Ebook() { }
        public Ebook(bool backlight, string firm, int bat, double size)
            : base(firm, bat, size)
        {
            Backlight = backlight;
        }

        public override void print()
        {
            base.print();
            Console.Write("\nПодсветка экрана: " + (Backlight ? "Есть" : "Отсутствует"));
        }
    }
}
