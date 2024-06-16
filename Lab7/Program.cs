using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Lab7
{
    internal class Program
    {
        static List<Bicycle> Bicycles;

        static void PrintBicycles()
        {
            foreach (var bicycl in Bicycles)
            {
                Console.WriteLine(bicycl.Info());
                Console.WriteLine();    
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Bicycles = new List<Bicycle>();
            FileStream fs = new FileStream("Bicycles.bicycles", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                Console.WriteLine("Читаємо дані з файлу...\n");
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    Bicycle bicycle1 = new Bicycle();
                    for (int i = 0; i < 8; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                bicycle1.Model = br.ReadString();
                                break;
                            case 2:
                                bicycle1.Frame = br.ReadString();
                                break;
                            case 3:
                                bicycle1.Broadcast = br.ReadInt32();
                                break;
                            case 4:
                                bicycle1.Fork = br.ReadString();
                                break;
                            case 5:
                                bicycle1.Handlebars = br.ReadString();
                                break;
                            case 6:
                                bicycle1.Ring = br.ReadBoolean();
                                break;
                            case 7:
                                bicycle1.Has3Wheels = br.ReadBoolean();
                                break;
                        }
                    }
                    Bicycles.Add(bicycle1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                br.Close();
            }
            Console.WriteLine($"Несортований перелік велосипедів: {Bicycles.Count}");
            PrintBicycles();
            Bicycles.Sort();
            Console.WriteLine($"Сортований перелік велосипедів: {Bicycles.Count}");
            PrintBicycles();
            Bicycle bicycle = new Bicycle("AndreanoCaruano", "Diamond", 25, "rigid", "Aero Bars", true, false);
            Bicycles.Add(bicycle);
            Bicycles.Sort();
            Console.WriteLine($"Перелік велосипедів: {Bicycles.Count}");
            PrintBicycles();
            Console.WriteLine("Видаляємо останнє значення");
            Bicycles.RemoveAt(Bicycles.Count - 1);
            Console.WriteLine($"Перелік велосипедів: {Bicycles.Count}");
            PrintBicycles();
            Console.ReadKey();
        }
    }
}
