using System;

namespace Lab4
{
  public class Time
    {
        public byte Hours { get; }
        public byte Minutes { get; }

        // Конструктор для создания нового объекта времени с проверкой корректности
        public Time(byte hours, byte minutes)
        {
            if (hours >= 24 || minutes >= 60)
                throw new ArgumentException("Некорректное время"); 
            Hours = hours;
            Minutes = minutes;
        }

        // Оператор инкремента (+1 минута)
        public static Time operator ++(Time t)
        {
            int newMinutes = t.Minutes + 1;
            int newHours = t.Hours;

          
            if (newMinutes >= 60)
            {
                newMinutes = 0;
                newHours = (newHours + 1) % 24; // Переход через полночь
            }

            return new Time((byte)newHours, (byte)newMinutes);
        }

        // Оператор декремента (-1 минута)
        public static Time operator --(Time t)
        {
            int newMinutes = t.Minutes - 1;
            int newHours = t.Hours;

            if (newMinutes < 0)
            {
                newMinutes = 59;
                newHours = (newHours - 1 + 24) % 24; // Коррекция через полночь
            }
            return new Time((byte)newHours, (byte)newMinutes);
        }

        // Операторы сравнения через общее количество минут
        public static bool operator <(Time t1, Time t2) => t1.ToMinutes() < t2.ToMinutes();
        public static bool operator >(Time t1, Time t2) => t1.ToMinutes() > t2.ToMinutes();

        // Оператор вычитания времени с коррекцией через полночь
        public static Time operator -(Time t1, Time t2)
        {
            int diff = t1.ToMinutes() - t2.ToMinutes();

            // Если разница отрицательная, добавляем 24 часа (в минутах)
            if (diff < 0)
                diff += 24 * 60;

            return new Time((byte)(diff / 60), (byte)(diff % 60));
        }

        // Неявное приведение к int (общее количество минут)
        public static implicit operator int(Time t) => t.ToMinutes();

        // Явное приведение к bool (false если 00:00)
        public static explicit operator bool(Time t) => t.ToMinutes() > 0;

        // Возвращает общее количество минут
        private int ToMinutes() => Hours * 60 + Minutes;

        // Форматированный вывод времени в формате HH:MM
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
    }
}