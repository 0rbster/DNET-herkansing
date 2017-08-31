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

        public UrenToekennen(string taak, string gebruikersnaam)
        {
            InitializeComponent();
            task = taak;
            huidigeGebruiker = gebruikersnaam;
            TaakBox.Text = task;
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                GewerkteUren.Text = uProxy.GewerkteUrenOphalen(task, huidigeGebruiker).ToString();
            }
                 
        }

        private void Opslaan_Click(object sender, RoutedEventArgs e)
        {
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {

                uProxy.UrenOpslaan(task, Convert.ToInt32(GewerkteUren.Text), huidigeGebruiker);
                this.Close();
            }
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
