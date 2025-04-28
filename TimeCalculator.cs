using System;
using System.Windows;

namespace Lab4
{
    public static class TimeCalculator
    {
        // Метод для создания объекта времени из часов и минут
        public static Time ReadTime(byte hours, byte minutes)
        {
            return new Time(hours, minutes); // Создаем новый объект времени
        }

        // Метод для выполнения операций над временем
        public static string PerformOperation(Time time1, Time time2, int operation)
        {
            switch (operation)
            {
                case 0:
                    // Инкремент времени (++)
                    var inc = new Time(time1.Hours, time1.Minutes);
                    inc++;
                    return $"{time1}++ = {inc}";

                case 1:
                    // Декремент времени (--)
                    var dec = new Time(time1.Hours, time1.Minutes);
                    dec--;
                    return $"{time1}-- = {dec}";

                case 2:
                    // Сравнение "меньше" (<)
                    // Проверяем, что время time2 корректно перед сравнением
                    if (time2.Hours == 0 && time2.Minutes == 0)
                        return "Второе время не инициализировано или равно 00:00";
                    return $"{time1} < {time2} = {time1 < time2}";

                case 3:
                    // Сравнение "больше" (>)
                    // Проверяем, что время time2 корректно перед сравнением
                    if (time2.Hours == 0 && time2.Minutes == 0)
                        return "Второе время не инициализировано или равно 00:00";
                    return $"{time1} > {time2} = {time1 > time2}";

                case 4:
                    // Вычитание времени
                    // Проверяем, что время time2 корректно перед вычитанием
                    if (time2.Hours == 0 && time2.Minutes == 0)
                        return "Второе время не инициализировано или равно 00:00";
                    return $"{time1} - {time2} = {time1 - time2}";

                case 5:
                    // Приведение времени к целому числу (в минутах)
                    return $"{(int)time1} минут";

                case 6:
                    // Приведение времени к логическому значению (true, если время не 00:00)
                    return $"{(bool)time1} (Не 00:00)";

                default:
                    return "Недостаточно данных для операции"; // Возвращаем сообщение об ошибке при некорректной операции
            }
        }
    }
}