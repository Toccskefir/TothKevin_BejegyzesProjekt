using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2. Feladat
            //a
            List<Bejegyzes> lista = new List<Bejegyzes>();
            Bejegyzes bejegyzes1 = new Bejegyzes("Tóth Kevin", "Épp dolgozatot írok, nem leszek elérhető!");
            Bejegyzes bejegyzes2 = new Bejegyzes("Kiss Sára", "De szép a mai nap!");
            lista.Add(bejegyzes1);
            lista.Add(bejegyzes2);
        }
    }
}
