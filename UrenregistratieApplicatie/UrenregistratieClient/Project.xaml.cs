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
    /// Interaction logic for Project.xaml
    /// </summary>
    public partial class Project : Window
    {
        public string huidigeGebruiker { get; set; }
        public string huidigeWachtwoord { get; }

        public Project(string gebruikersnaam, string wachtwoord)
        {
            InitializeComponent();
            huidigeGebruiker = gebruikersnaam;
            huidigeWachtwoord = wachtwoord;
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                var takenlijst = uProxy.TakenOphalen(huidigeGebruiker, huidigeWachtwoord);
                foreach (var t in takenlijst)
                {
                    TakenLijst.Items.Add(t.Split('|')[0]);
                    UrenLijst.Items.Add(t.Substring(t.LastIndexOf('|') + 1));
                }
            }
                
        }

        private void Aanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (TakenLijst.SelectedItem == null)
            {
                MessageBox.Text = "Selecteer een taak om aan te passen";
            } else
            {
                UrenToekennen ut = new UrenToekennen(TakenLijst.SelectedItem.ToString(), huidigeGebruiker, huidigeWachtwoord);
                ut.Show();
                this.Close();
            }
        }

        private void Uitloggen_Click(object sender, RoutedEventArgs e)
        {
            MainWindow l = new MainWindow();
            l.Show();
            this.Close();
        }
    }
}
