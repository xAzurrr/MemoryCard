using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Card_Game____Noah_Azur_Nacar
{
    internal class Bestenliste
    {
        private string  spielername;
        private int     verbleibendeLeben;
        private string  noetigeZeit;

        private List<Bestenliste> ergebnisse = new List<Bestenliste>();

        public string get_spielername()
        {
            return spielername;
        }

        public void set_spielername(string _spielername)
        {
            spielername = _spielername;
        }

        public int get_verbleibendeLeben()
        {
            return verbleibendeLeben;
        }

        public void set_verbleibendeLeben(int _verbleibendeLeben)
        {
            verbleibendeLeben = _verbleibendeLeben;
        }

        public string get_noetigeZeit()
        {
            return noetigeZeit;
        }

        public void set_noetigeZeit(string _noetigeZeit)
        {
            noetigeZeit = _noetigeZeit;
        }

        public void ergebnisHinzufuegen(Bestenliste ergebnis)
        {
            ergebnisse.Add(ergebnis);
        }

        public List<Bestenliste> get_ganzeErgebnisse()
        {
            return ergebnisse;
        }

        public void speichern(string dateipfad)
        {
            using (StreamWriter writer = new StreamWriter(dateipfad))
            {
                foreach (var erg in ergebnisse)
                {
                    writer.WriteLine(erg.get_spielername() + ";" + erg.get_verbleibendeLeben() + ";" + erg.get_noetigeZeit());
                }
            }
        }

        public void laden(string dateipfad)
        {
            ergebnisse.Clear();
            if (!File.Exists(dateipfad)) return;

            var zeilen = File.ReadAllLines(dateipfad);
            foreach (var zeile in zeilen)
            {
                var teile = zeile.Split(";");
                if (teile.Length == 3)
                {
                    var ergebnis = new Bestenliste();
                    ergebnis.set_spielername(teile[0]);
                    ergebnis.set_verbleibendeLeben(int.Parse(teile[1]));
                    ergebnis.set_noetigeZeit(teile[2]);
                    ergebnisse.Add(ergebnis);
                }
            }
        }
    }
}
