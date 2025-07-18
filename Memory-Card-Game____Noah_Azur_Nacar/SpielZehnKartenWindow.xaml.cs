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
using System.Windows.Threading;

namespace Memory_Card_Game____Noah_Azur_Nacar
{
    /// <summary>
    /// Interaktionslogik für SpielZwanzigKartenWindow.xaml
    /// </summary>
    public partial class SpielZehnKartenWindow : Window
    {
        private Einstellungen spielEinstellungen;

        private Dictionary<Button, Brush> kartenFarben = new();

        Random rndFarbe = new Random();

        private DispatcherTimer kartenZurueckDrehen_Timer;
        private bool kartenKlickenGesperrt;
        private bool SpielLaeuft_ZeitMesser;

        private Button ersteKarte;
        private Button zweiteKarte;

        int i;
        private int leben;
        private int sekunden_Timer;
        private int minuten_Timer;
        private string zeitGesamtMinutenUndSekunden;


        public SpielZehnKartenWindow(Einstellungen _spielEinstellungen)
        {
            InitializeComponent();
            spielEinstellungen = _spielEinstellungen;
            leben = spielEinstellungen.spielLeben;
            tbLebenAnzahl.Text = "Leben: " + leben;
            SpielLaeuft_ZeitMesser = true;
            startSpielLaeuft_ZeitMesser();
            kartenVorbereiten();

        }

        private void kartenVorbereiten()
        {
            List<Brush> farben = new List<Brush>
            {//Brushes.Yellow, use sind vordefinierte farben in WPF
                Brushes.Yellow,     Brushes.Yellow,
                Brushes.Red,        Brushes.Red,
                Brushes.Green,      Brushes.Green,
                Brushes.Blue,       Brushes.Blue,
                Brushes.Purple,     Brushes.Purple,
                //Brushes.AliceBlue,  Brushes.AliceBlue,
                //Brushes.IndianRed,  Brushes.IndianRed,
                //Brushes.Brown,      Brushes.Brown,
                //Brushes.DarkKhaki,  Brushes.DarkKhaki,
                //Brushes.DarkOrchid, Brushes.DarkOrchid,
            };

            // OrderBy sortiert nach Zufallswert (farbe => [in*] rndFarbe) → mischt dadurch die Reihenfolge
            // ToList wandelt das Ergebnis zurück in eine List<Brush>
            farben = farben.OrderBy(farbe => rndFarbe.Next()).ToList();


            // Erstellen eine liste mit 10 buttons damit wir jeden buttons eine farbe geben können ohne das ich es 10x/20x/30x selber schreiben muss 
            List<Button> buttons = new List<Button>
            {
                btn0,   btn1,   btn2,   btn3,   btn4,
                btn5,   btn6,   btn7,   btn8,   btn9,
                //btn10,  btn11,  btn12,  btn13,  btn14,
                //btn15,  btn16,  btn17,  btn18,  btn19,
            };

            // Ich verbinde jede Karte (Button) mit einer bestimmten Farbe,
            // damit ich später weiß, welche Farbe zu welcher Karte gehört.
            kartenFarben[buttons[i]] = farben[i];
            for (i = 0; i < buttons.Count; i++)
            {
                kartenFarben[buttons[i]] = farben[i];
                Image memoryCardPointer = new Image();
                memoryCardPointer.Source = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/pointer/MemoryCardPointer.png"));
                memoryCardPointer.Stretch = Stretch.Uniform;
                buttons[i].Content = memoryCardPointer;
                buttons[i].Background = Brushes.MediumPurple;
                buttons[i].IsEnabled = true;
                buttons[i].Click += btnKarte_Click; // 
            }
        }

        private void btnKarte_Click(object sender, RoutedEventArgs e)
        {

            ImageSource memoryCardWasRight = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/pointer/memoryCardWasRight.png"));

            Button gedrueckteKarte = (Button)sender;

            if (kartenKlickenGesperrt)
            {
                return; // check damit man während der timer transition keine weiteren karten anklicken kann 
            }

            if (gedrueckteKarte == ersteKarte)
            {
                return; // check damit man nicht die gleiche karte zweilmal anklicken kann, return sagt quasi hier stoppen und zurück
            }

            gedrueckteKarte.Background = kartenFarben[gedrueckteKarte];
            gedrueckteKarte.Content = "  ";

            if (ersteKarte == null)
            {
                ersteKarte = gedrueckteKarte;
            }
            else if (zweiteKarte == null)
            {
                zweiteKarte = gedrueckteKarte;

                if (kartenFarben[ersteKarte] == kartenFarben[zweiteKarte])
                {

                    ersteKarte.IsEnabled = false;
                    zweiteKarte.IsEnabled = false;

                    ersteKarte.Content = new Image
                    {
                        Source = memoryCardWasRight,
                        Stretch = Stretch.Uniform,
                    };
                    zweiteKarte.Content = new Image
                    {
                        Source = memoryCardWasRight,
                        Stretch = Stretch.Uniform,
                    };

                    ersteKarte = null;
                    zweiteKarte = null;

                    if (kartenFarben.Keys.All(b => !b.IsEnabled))
                    {
                        zeitGesamtMinutenUndSekunden = minuten_Timer.ToString("D2") + ":" + sekunden_Timer.ToString("D2");
                        SpielLaeuft_ZeitMesser = false;

                        ErgebnisWindow ergebnisWindow = new ErgebnisWindow(leben, zeitGesamtMinutenUndSekunden);
                        ergebnisWindow.Show();
                        this.Close();
                    }
                }
                else
                {
                    kartenKlickenGesperrt = true;
                    kartenZurueckDrehen_Timer = new DispatcherTimer();
                    kartenZurueckDrehen_Timer.Interval = TimeSpan.FromSeconds(0.6);
                    kartenZurueckDrehen_Timer.Tick += kartenZurueckDrehen;
                    kartenZurueckDrehen_Timer.Start();
                }
            }
        }

        private void kartenZurueckDrehen(object sender, EventArgs e)
        {

            /*Image memoryCardWasWrong = new Image();
            memoryCardWasWrong.Source = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/pointer/MemoryCardWasWrong.png"));
            memoryCardWasWrong.Stretch = Stretch.Uniform;*/

            ImageSource memoryCardWasWrongSource = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/pointer/MemoryCardWasWrong.png"));

            leben--;
            if (leben == 0)
            {
                SpielLaeuft_ZeitMesser = false;
                ErgebnisWindow ergebnisWindow = new ErgebnisWindow(leben, zeitGesamtMinutenUndSekunden);
                ergebnisWindow.Show();
                this.Close();
            }

            tbLebenAnzahl.Text = "Leben: " + leben;

            kartenZurueckDrehen_Timer.Stop();

            ersteKarte.Background = Brushes.LightGray;
            ersteKarte.Content = new Image
            {
                Source = memoryCardWasWrongSource,
                Stretch = Stretch.Uniform,
            };

            zweiteKarte.Background = Brushes.LightGray;
            zweiteKarte.Content = new Image
            {
                Source = memoryCardWasWrongSource,
                Stretch = Stretch.Uniform,
            };

            ersteKarte = null;
            zweiteKarte = null;

            kartenKlickenGesperrt = false;


        }

        private async void startSpielLaeuft_ZeitMesser()
        {
            await Task.Run(async () =>
            {
                while (SpielLaeuft_ZeitMesser)
                {
                    await Task.Delay(1000);
                    sekunden_Timer++;

                    if (sekunden_Timer == 60)
                    {
                        sekunden_Timer = 0;
                        minuten_Timer++;
                    }


                    Dispatcher.Invoke(() =>
                    {
                        txtZeitMesser.Text = "Zeit: " + (minuten_Timer.ToString("D2") + ":") + sekunden_Timer.ToString("D2");
                    });
                }

            });
        }

    }
}
