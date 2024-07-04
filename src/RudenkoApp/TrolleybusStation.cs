using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RudenkoApp
{
    public class TrolleybusStation
    {
        public List<Route> Routes = new List<Route>();

        public void Add(int size)
        {
            for (int i = 0; i < size; i++)
            {
                string num = "";
                int count = 0;
                int time = 0 ;
                bool flag = true;
                while (flag)
                {
                    Console.Clear();
                    Console.Write($"Введите номер для {i + 1} маршрута: ");
                    num = Console.ReadLine();
                    if (num.Replace(" ", "") == "")
                    {
                        Console.WriteLine("Введите номер!");
                        Console.ReadKey();
                    }
                    else
                        flag = false;
                }
                flag = true;
                while (flag)
                {
                    Console.Write($"Введите кол-во остановок для {i + 1} маршрута: ");
                    if (!(int.TryParse(Console.ReadLine(), out count) && count > 0))
                    {
                        Console.WriteLine("Введите целое положительное число!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                        flag = false;
                }
                flag = true;
                while (flag)
                {
                    Console.Write($"Введите время в пути (мин.) для {i + 1} маршрута: ");
                    if (!(int.TryParse(Console.ReadLine(), out time) && time > 0))
                    {
                        Console.WriteLine("Введите целое положительное число!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        flag = false;
                        Route route = new Route
                        {
                            NumRoute = num,
                            CountStop = count,
                            TimeRoute = time
                        };
                        Routes.Add(route);
                    }
                }
            }
            Console.Clear();
            Console.WriteLine($"Вы успешно добавили маршруты в кол-ве {Routes.Count}");
        }

        public void Sort()
        {
            Routes.Sort((x,y) => string.Compare($"{y.CountStop} {y.TimeRoute}", $"{x.CountStop} {x.TimeRoute}"));
        }

        public bool JsonWrite(string fileName)
        {
            string json = JsonConvert.SerializeObject(Routes, Formatting.Indented);
            File.WriteAllText(@$"..\..\..\{fileName}", json);
            string fileContetn = File.ReadAllText(@$"..\..\..\{fileName}");
            if (fileContetn.Replace(" ", "") == "")
                return false;
            else
                return true;
        }
    }
}
