using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Bejegyzes
    {
        private string szerzo;
        private string tartalom;
        private int likeok;
        private DateTime letrejott;
        private DateTime szerkesztve;
        private bool szerkesztvevan;

        public Bejegyzes(string szerzo, string tartalom)
        {
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            this.letrejott = DateTime.Today;
            this.szerkesztve = DateTime.Now;
            this.szerkesztvevan = false;
        }

        public string Szerzo { get => szerzo; }
        public string Tartalom
        { 
            get => tartalom;
            set
            {
                tartalom = value;
                szerkesztve = DateTime.Now;
                szerkesztvevan = true;
            }
        }
        public int Likeok { get => likeok; }
        public DateTime Letrejott { get => letrejott; }
        public DateTime Szerkesztve { get => szerkesztve; }

        public void Like()
        {
            this.likeok++;
        }

        public override string ToString()
        {
            if (szerkesztvevan)
            {
                return $"{this.szerzo} - {this.likeok} - {this.letrejott}\nSzerkesztve: {this.szerkesztve}\n{this.tartalom}";
            }
            else
            {
                return $"{this.szerzo} - {this.likeok} - {this.letrejott}\n{this.tartalom}";
            }
        }
    }
}
