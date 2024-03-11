using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsgagyakKonyves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1-3. feladat
            List<Book> list = new List<Book>();
            string[] lines = File.ReadAllLines("books.txt");
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Book obj = new Book(values[0], values[1], values[2], values[3], values[4]);
                list.Add(obj);
            }

            //4.feladat
            Console.WriteLine("4.Feladat");
            foreach (var i in list)
            {
                Console.WriteLine($"{i.id} {i.kategoria} {i.cim} {i.ar} {i.db}");
            }

            //5.feladat
            Console.WriteLine("\n5.Feladat");
            int osszDb = 0;
            foreach (var i in list)
            {
                osszDb += i.db;
            }
            Console.WriteLine($"Az össz darabszám: {osszDb} db");

            //6.feladat
            Console.WriteLine("\n6.Feladat");
            foreach (var i in list)
            {
                if (i.kategoria == "Regény")
                {
                    Console.WriteLine($"{i.cim} {i.ar}");
                }
            }

            //7.feladat
            Console.WriteLine("\n7.Feladat");
            Dictionary<string, int> dict= new Dictionary<string, int>();

            foreach (var i in list)
            {
                if (dict.ContainsKey(i.kategoria))
                {
                    dict[i.kategoria]++;
                }
                else
                {
                    dict[i.kategoria] = 1;
                }
            }

            foreach (var i in dict)
            {
                Console.WriteLine($"{i.Key}: {i.Value} termék");
            }

            //8.feladat
            Console.WriteLine("\n8.Feladat");
            List<Book> legolcsobbak = new List<Book>();
            Book legolcsobb = list[0];
            legolcsobbak.Add(legolcsobb);

            foreach (var termek in list)
            {
                if (termek.ar < legolcsobb.ar)
                {
                    legolcsobb = termek;
                    legolcsobbak.Clear();
                    legolcsobbak.Add(legolcsobb);
                }
                else if (termek.ar == legolcsobb.ar)
                {
                    legolcsobbak.Add(termek);
                }
            }

            Console.WriteLine("\nLegolcsóbb termek(ek) adatai:");
            foreach (var legolcsobbTermek in legolcsobbak)
            {
                Console.WriteLine($"Kategória: {legolcsobbTermek.kategoria},Cím: {legolcsobbTermek.cim}, Ár: {legolcsobbTermek.ar}");
            }


            Console.ReadKey();
        }
    }
}
