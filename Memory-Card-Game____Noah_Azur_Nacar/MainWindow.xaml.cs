using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory_Card_Game____Noah_Azur_Nacar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Einstellungen spielEinstellungen;


        public MainWindow()
        {
            InitializeComponent();
            spielEinstellungen = new Einstellungen(10,10,0,0);
            

        }
        public MainWindow(Einstellungen _spielEinstellungen)
        {
            InitializeComponent();
            spielEinstellungen = _spielEinstellungen;

        }

        private void btnSpielBeenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSpielBestenListe_Click(object sender, RoutedEventArgs e)
        {
            BestenlisteWindow bestenliste = new BestenlisteWindow(spielEinstellungen);
            bestenliste.Show();
            this.Close();
        }

        private void btnSpielOptionen_Click(object sender, RoutedEventArgs e)
        {
            OptionenWindow optionenWindow = new OptionenWindow(spielEinstellungen);
            optionenWindow.Show();
            this.Close();

        }

        private void btnSpielStarten_Click(object sender, RoutedEventArgs e)
        {

            if(spielEinstellungen.spielKartenAnzahl == 20)
            {
                SpielZwanzigKartenWindow spielzwanzigkartenWindow = new SpielZwanzigKartenWindow(spielEinstellungen);
                spielzwanzigkartenWindow.Show();
                this.Close();
            }
            else if(spielEinstellungen.spielKartenAnzahl==10)
            {
                SpielZehnKartenWindow spielZehnKartenWindow = new SpielZehnKartenWindow(spielEinstellungen);
                spielZehnKartenWindow.Show();
                this.Close();
            }


        }
    }
}