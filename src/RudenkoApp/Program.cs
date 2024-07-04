using System;

namespace RudenkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TrolleybusStation trolleybusStation = new TrolleybusStation();
            int count = 0;
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Введите число маршрутов, которое хотите добавить: ");
                if (!int.TryParse(Console.ReadLine(), out count) && count > 0)
                {
                    Console.WriteLine("Введите целое положительное число!");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    flag = false;
                }
            }
            trolleybusStation.Add(count);

            Console.WriteLine("Остсортированный список маршрутов по числу остановок + время в пути (по возрастанию):");
            trolleybusStation.Sort();
            foreach(Route route in trolleybusStation.Routes)
            {
                Console.WriteLine($"[{route.NumRoute}] {route.CountStop} остановок ({route.TimeRoute} мин.)");
            }

            string fileName = "route.json";
            if(trolleybusStation.JsonWrite(fileName))
                Console.WriteLine($"Отсортированный список маршрутов успешно сохранет в файле {fileName}");
            else
                Console.WriteLine("Не удалорсь сохранить данные в файл.");
        }
    }
}
