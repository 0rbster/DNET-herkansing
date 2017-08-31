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
using UrenregistratieClient.UrenregistratieService;

namespace UrenregistratieClient
{
    /// <summary>
    /// Interaction logic for UrenToekennen.xaml
    /// </summary>
    public partial class UrenToekennen : Window
    {
        private string task { get; set; }
        private string huidigeGebruiker { get; set; }
        private string huidigeWachtwoord { get; set; }

        public UrenToekennen(string taak, string gebruikersnaam, string wachtwoord)
        {
            InitializeComponent();
            task = taak;
            huidigeGebruiker = gebruikersnaam;
            huidigeWachtwoord = wachtwoord;
            TaakBox.Text = task;
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                GewerkteUren.Text = uProxy.GewerkteUrenOphalen(task, huidigeGebruiker, huidigeWachtwoord).ToString();
            }
                 
        }

        private void Opslaan_Click(object sender, RoutedEventArgs e)
        {
            int gewerkteUren;
            bool isNumeric = int.TryParse(GewerkteUren.Text, out gewerkteUren);
            if (!isNumeric)
            {
                MessageBox.Text = "Voer een nummer in A.U.B.";
            } else
            {
                using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
                {

                    uProxy.UrenOpslaan(task, Convert.ToInt32(GewerkteUren.Text), huidigeGebruiker, huidigeWachtwoord);
                    Project p = new Project(huidigeGebruiker, huidigeWachtwoord);
                    p.Show();
                    this.Close();
                }
            }
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            Project p = new Project(huidigeGebruiker, huidigeWachtwoord);
            p.Show();
            this.Close();
        }

        private void Verwijderen_Click(object sender, RoutedEventArgs e)
        {
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                uProxy.TaakVerwijderen(task, huidigeGebruiker, huidigeWachtwoord);
                Project p = new Project(huidigeGebruiker, huidigeWachtwoord);
                p.Show();
                this.Close();
            }
        }
    }
}
