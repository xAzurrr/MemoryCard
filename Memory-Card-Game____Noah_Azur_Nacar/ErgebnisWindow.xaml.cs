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
    /// <summary>
    /// Interaction logic for ErgebnisWindow.xaml
    /// </summary>
    public partial class ErgebnisWindow : Window
    {
        private int leben;
        private string zeitGesamtMinutenUndSekunden;

        public ErgebnisWindow(int _leben, string _zeitGesamtMinutenUndSekunden)
        {
            InitializeComponent();
            leben                           = _leben;
            zeitGesamtMinutenUndSekunden    = _zeitGesamtMinutenUndSekunden;
            if (leben == 0)
            {
                tbErgebnisGewonnenVerloren.Text = "Verloren";
                btnOk.IsEnabled = true;
                txtName.IsEnabled = false;
                tbNameEingeben.Text = "Name kann nur beim gewinn eingegeben werden";
            }
            else
            {
                tbErgebnisGewonnenVerloren.Text = "Gewonnen";
            }

            this.zeitGesamtMinutenUndSekunden = zeitGesamtMinutenUndSekunden;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            if(leben > 0)
            {
                Bestenliste bestenliste = new Bestenliste();
                bestenliste.laden("MemoryCard_Bestenliste_byNoahAzurNacar.txt");

                Bestenliste neuesErgebnis = new Bestenliste();
                neuesErgebnis.set_spielername(txtName.Text);
                neuesErgebnis.set_verbleibendeLeben(leben);
                neuesErgebnis.set_noetigeZeit(zeitGesamtMinutenUndSekunden);

                bestenliste.ergebnisHinzufuegen(neuesErgebnis);
                bestenliste.speichern("MemoryCard_Bestenliste_byNoahAzurNacar.txt");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if(leben == 0)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnOk.IsEnabled = !string.IsNullOrEmpty(txtName.Text);
        }
    }
}
