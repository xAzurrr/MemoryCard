using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memory_Card_Game____Noah_Azur_Nacar
{
    public partial class OptionenWindow : Window
    {
        private Einstellungen spielEinstellungen;

        public void aktualisierenOptionenBenutzeroberfläche()
        {
            if (spielEinstellungen.optionenSchalter_SpielLeben == 3)
            {
                spielEinstellungen.optionenSchalter_SpielLeben = 0;
            }

            if (spielEinstellungen.optionenSchalter_SpielLeben == 0)
            {
                spielEinstellungen.spielLeben   = 10;
                btnSpielLebenAnzahl.Content     = "10";
            }
            else if (spielEinstellungen.optionenSchalter_SpielLeben == 1)
            {
                spielEinstellungen.spielLeben   = 20;
                btnSpielLebenAnzahl.Content     = "20";
            }
            else if (spielEinstellungen.optionenSchalter_SpielLeben == 2)
            {
                spielEinstellungen.spielLeben   = 30;
                btnSpielLebenAnzahl.Content     = "30";
            }

            if (spielEinstellungen.optionenSchalter_SpielKartenAnzahl == 2)
            {
                spielEinstellungen.optionenSchalter_SpielKartenAnzahl = 0;
            }

            if (spielEinstellungen.optionenSchalter_SpielKartenAnzahl == 0)
            {
                spielEinstellungen.spielKartenAnzahl = 10;
                btnSpielKartenAnzahl.Content = "10";
            }
            else if (spielEinstellungen.optionenSchalter_SpielKartenAnzahl == 1)
            {
                spielEinstellungen.spielKartenAnzahl = 20;
                btnSpielKartenAnzahl.Content = "20";
            }
        }


        public OptionenWindow(Einstellungen _spielEinstellungen)
        {
            InitializeComponent();
            spielEinstellungen = _spielEinstellungen;
            aktualisierenOptionenBenutzeroberfläche();
        }

        private void btnSpielMenue_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(spielEinstellungen);
            mainWindow.Show();
            this.Close();
        }

        private void btnSpielKartenAnzahl_Click(object sender, RoutedEventArgs e)
        {
            spielEinstellungen.optionenSchalter_SpielKartenAnzahl++;
            aktualisierenOptionenBenutzeroberfläche();
        }

        private void btnSpielLebenAnzahl_Click(object sender, RoutedEventArgs e)
        {
            spielEinstellungen.optionenSchalter_SpielLeben++;
            aktualisierenOptionenBenutzeroberfläche();
        }
    }
}
