using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// <summary>
    /// Interaktionslogik für BestenlisteWindow.xaml
    /// </summary>
    public partial class BestenlisteWindow : Window
    {
        private Einstellungen spielEinstellungen;

        public BestenlisteWindow(Einstellungen _spielEinstellungen)
        {
            InitializeComponent();
            spielEinstellungen = _spielEinstellungen;

            Bestenliste bestenliste = new Bestenliste();
            bestenliste.laden("MemoryCard_Bestenliste_byNoahAzurNacar.txt");

            var ergebnisse = bestenliste.get_ganzeErgebnisse();

            lvBestenliste.ItemsSource = ergebnisse.Select(erg => new
            {
                Spielername         = erg.get_spielername(),
                VerbleibendeLeben   = erg.get_verbleibendeLeben(),
                Zeit                = erg.get_noetigeZeit(),
            }).ToList();

        }

        private void btnSpielMenue_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(spielEinstellungen);
            mainWindow.Show();
            this.Close();
        }
    }
}
