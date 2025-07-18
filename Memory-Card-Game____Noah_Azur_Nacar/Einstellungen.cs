using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Memory_Card_Game____Noah_Azur_Nacar
{
    public class Einstellungen
    {
        public int spielLeben;
        public int spielKartenAnzahl;
        public int optionenSchalter_SpielLeben;
        public int optionenSchalter_SpielKartenAnzahl;

        public Einstellungen(int _spielLeben, int _spielKartenAnzahl, int _optionenSchalter_SpielLeben, int _optionenSchalter_SpielKartenAnzahl) 
        { 

            spielLeben                          = _spielLeben;
            spielKartenAnzahl                   = _spielKartenAnzahl;
            optionenSchalter_SpielLeben         = _optionenSchalter_SpielLeben;
            optionenSchalter_SpielKartenAnzahl  = _optionenSchalter_SpielKartenAnzahl;

        }

    }
}
