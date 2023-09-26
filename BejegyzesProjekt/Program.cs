using System;
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

            Console.ReadKey();
        }
    }
}
