﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2. Feladat
            //a
            List<Bejegyzes> list = new List<Bejegyzes>();
            Bejegyzes bejegyzes1 = new Bejegyzes("Tóth Kevin", "Épp dolgozatot írok, nem leszek elérhető!");
            Bejegyzes bejegyzes2 = new Bejegyzes("Kiss Sára", "De szép a mai nap!");
            list.Add(bejegyzes1);
            list.Add(bejegyzes2);

            //b
            Console.Write("Kérem adja meg hány új bejegyzést szeretne posztolni: ");
            double newPost = double.Parse(Console.ReadLine());

            if (newPost % 1 != 0 || newPost < 0)
            {
                Console.WriteLine("Hibás értéket adott meg!");
            }
            else
            {
                for (int i = 0; i < newPost; i++)
                {
                    Console.WriteLine($"{i + 1}. bejegyzés:");
                    string post = Console.ReadLine();
                    Bejegyzes b = new Bejegyzes("Kiss Sára", post);
                    list.Add(b);
                }
            }

            //c
            string fileName = "bejegyzesek.csv";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    string szerzo = line[0];
                    string tartalom = line[1];
                    Bejegyzes p = new Bejegyzes(szerzo, tartalom);
                    list.Add(p);
                }
            }

            //d
            Random rnd = new Random();
            for (int i = 0; i < list.Count * 20; i++)
            {
                list[rnd.Next(0, list.Count)].Like();
            }

            //e
            Console.WriteLine("Kérem adja meg mire módosítja második posztját: ");
            list[1].Tartalom = Console.ReadLine();

            //f
            foreach (Bejegyzes item in list)
            {
                Console.WriteLine(item + "\n");
            }

            //3. Feladat
            //a
            Bejegyzes mostFamousPost = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (mostFamousPost.Likeok < list[i].Likeok)
                {
                    mostFamousPost = list[i];
                }
            }
            Console.WriteLine("Jelenlegi legnépszerűbb poszt like száma :" + mostFamousPost.Likeok + "\n");

            //b
            Console.WriteLine("35-nél több likeal rendelkező posztok:");
            bool exists35 = true;
            foreach (Bejegyzes item in list)
            {
                if (item.Likeok > 35)
                {
                    Console.WriteLine(item + "\n");
                    exists35 = false;
                }
            }
            if (exists35)
            {
                Console.WriteLine("Jelenleg nincs ilyen poszt.\n");
            }

            //c
            Console.WriteLine("15-nél kevesebb likeal rendelkező posztok:");
            bool exists15 = true;
            foreach (Bejegyzes item in list)
            {
                if (item.Likeok < 15)
                {
                    Console.WriteLine(item + "\n");
                    exists15 = false;
                }
            }
            if (exists15)
            {
                Console.WriteLine("Jelenleg nincs ilyen poszt.\n");
            }

            //d
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i].Likeok > list[j].Likeok)
                    {
                        Bejegyzes temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

            Console.WriteLine("Likeok szerint rendezve:");
            foreach (Bejegyzes item in list)
            {
                Console.WriteLine(item + "\n");
            }

            //fájlba írás
            using(StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt", false))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine(list[i] + "\n");
                }
            }
            Console.ReadKey();
        }
    }
}
